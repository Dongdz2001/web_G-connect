using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using NetOffice;
using NetOffice.WordApi;
using NetOffice.WordApi.Enums;
using NetOffice.ExcelApi;
using NetOffice.ExcelApi.Enums;
using WordApplication = NetOffice.WordApi.Application;
using ExcelApplication = NetOffice.ExcelApi.Application;

namespace App.Business.Utils
{
    public static class DocxHanlder
    {
        /// <summary>
        /// Chuyển đổi docx sang pdf và lưu lại file pdf vào folder
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="pathPdf"></param>
        /// <param name="filePdf"></param>
        /// <returns>pathFilePdf</returns>
        /// 

        public static string ConvertToPdf(string pathDocx, string folderPdf, string filePdf)
        {
            try
            {
                if (!Directory.Exists(folderPdf))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPdf);
                }

                WordApplication ap = new WordApplication
                {
                    DisplayAlerts = WdAlertLevel.wdAlertsNone
                };
                Document document = ap.Documents.Open(pathDocx, false , true);
                string pathFilePdf = folderPdf + "\\" + filePdf + ".pdf";
                try
                {
                    document.ExportAsFixedFormat(pathFilePdf, WdExportFormat.wdExportFormatPDF);
                }
                catch (Exception)
                {

                }
                finally
                {
                    document.Close();
                    ap.Quit();

                    document.Dispose();
                    ap.Dispose();
                }
                
               
                

                return pathFilePdf;
            }
            catch (Exception ex)
            {
                return "Error convert docx to pdf: "+ ex.Message;
            }
        }


        public static byte[] ConvertToPdf(string pathDocx)
        {
            byte[] dataBytes = null;
            string pathtempPdf = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\temp\\";

            try
            {
                if (!Directory.Exists(pathtempPdf))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathtempPdf);
                }
                WordApplication ap = new WordApplication();
                ap.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                Document document = ap.Documents.Open(pathDocx, false, true);
                string pathFilePdf = pathtempPdf + Guid.NewGuid().ToString()+ ".pdf";
                try
                {
                    document.ExportAsFixedFormat(pathFilePdf, WdExportFormat.wdExportFormatPDF);

                    dataBytes = File.ReadAllBytes(pathFilePdf);

                    if (dataBytes != null)
                    {
                        File.Delete(pathFilePdf);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    document.Close();
                    ap.Quit();

                    document.Dispose();
                    ap.Dispose();

                }

                return dataBytes;
            }
            catch (Exception )
            {
                return null;
            }

            
        }


        public static byte[] ConvertWordToPdf(string pathDocx)
        {
            byte[] dataBytes = null;
            string pathtempPdf = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\temp\\";

            try
            {
                if (!Directory.Exists(pathtempPdf))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathtempPdf);
                }
                WordApplication ap = new WordApplication();
                ap.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                Document document = ap.Documents.Open(pathDocx, false, true);
                string pathFilePdf = pathtempPdf + Guid.NewGuid().ToString() + ".pdf";
                try
                {
                    document.ExportAsFixedFormat(pathFilePdf, WdExportFormat.wdExportFormatPDF);

                    dataBytes = File.ReadAllBytes(pathFilePdf);

                    if (dataBytes != null)
                    {
                        File.Delete(pathFilePdf);
                    }
                }
                catch (Exception)
                {
                    File.Delete(pathDocx);
                }
                finally
                {
                    document.Close();
                    ap.Quit();

                    document.Dispose();
                    ap.Dispose();

                }

                return dataBytes;
            }
            catch (Exception)
            {
                File.Delete(pathDocx);
                return dataBytes;
            }


        }

        public static byte[] WriteFile(byte[] byteArray)
        {
            string pathtempDocx = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\temp\\";
            try
            {
                string pathFileDocx = "";
                if (!Directory.Exists(pathtempDocx))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathtempDocx);
                }
                using (MemoryStream stream = new MemoryStream())
                {
                    pathFileDocx = pathtempDocx + Guid.NewGuid().ToString() + ".docx";
                    stream.Write(byteArray, 0, (int)byteArray.Length);
                    File.WriteAllBytes(pathFileDocx, stream.ToArray());
                }
                if (pathFileDocx != null)
                {
                    var bytes = ConvertWordToPdf(pathFileDocx);
                    File.Delete(pathFileDocx);
                    return bytes;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static byte[] PdfToDocx(byte[] byteArray)
        {
            string pathtempDocx = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\temp\\";
            try
            {
                if (!Directory.Exists(pathtempDocx))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathtempDocx);
                }
                using (MemoryStream stream = new MemoryStream())
                {
                    string pathFileDocx = pathtempDocx + Guid.NewGuid().ToString() + ".docx";
                    stream.Write(byteArray, 0, (int)byteArray.Length);
                    File.WriteAllBytes(pathFileDocx, stream.ToArray());
                    var bytes = File.ReadAllBytes(pathFileDocx);
                    File.Delete(pathFileDocx);
                    return bytes;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static byte[] ExcelToPdf(string pathExcel)
        {
            byte[] dataBytes = null;
            string pathtempPdf = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\temp\\";

            try
            {
                if (!Directory.Exists(pathtempPdf))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathtempPdf);
                }
                ExcelApplication ap = new ExcelApplication();               
                ap.DisplayAlerts = false;
                ap.Visible = false;
                Workbook wb = ap.Workbooks.Open(pathExcel, false, true);
                string pathFilePdf = pathtempPdf + Guid.NewGuid().ToString() + ".pdf";
                try
                {
                    wb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, pathFilePdf, XlFixedFormatQuality.xlQualityStandard, true, false);                   
                    dataBytes = File.ReadAllBytes(pathFilePdf);

                    if (dataBytes != null)
                    {
                        File.Delete(pathFilePdf);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    wb.Close();
                    ap.Quit();

                    wb.Dispose();
                    ap.Dispose();

                }

                return dataBytes;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        
    }
}
