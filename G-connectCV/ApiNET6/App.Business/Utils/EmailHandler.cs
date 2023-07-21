using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Utils
{
    public static class EmailHandler
    {
        private static readonly string Email_User = AppSettingsProvider.Configuration.GetSection("Smtp")["Email"];
        private static readonly string Email_PassWord = AppSettingsProvider.Configuration.GetSection("Smtp")["Password"];
        private static readonly string EmailName = AppSettingsProvider.Configuration.GetSection("Smtp")["EmailName"];
        private static readonly string Host = AppSettingsProvider.Configuration.GetSection("Smtp")["Host"];
        private static readonly int Port = AppSettingsProvider.Configuration.GetSection("Smtp").GetValue<int>("Port");
        private static readonly bool EnableSsl = AppSettingsProvider.Configuration.GetSection("Smtp").GetValue<bool>("EnableSsl");
        public static void Send(string toMail, string ccMail, string subject, string body, List<AttachmentDTO> files=null)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory());
            if (toMail != null)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toMail);
                if (ccMail != null)
                {
                    mail.CC.Add(ccMail);
                }
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        Attachment attachment;
                        attachment = new Attachment(path + "\\" + file.path);
                        mail.Attachments.Add(attachment);
                    }
                }
                var fromAddress = new MailAddress(Email_User, EmailName);
                mail.From = fromAddress;
                mail.Subject = subject;
                
                mail.IsBodyHtml = true;
                mail.Body = body;
                SmtpClient clientsmtp = new SmtpClient
                {
                    Port = Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = Host,
                    EnableSsl = EnableSsl,
                    Credentials = new NetworkCredential(fromAddress.Address, Email_PassWord)
                };
                clientsmtp.Send(mail);
                
            }
        }
    }
    public class AttachmentDTO
    {
        public Guid id { get; set; }
        public string path { get; set; }
    }
}
