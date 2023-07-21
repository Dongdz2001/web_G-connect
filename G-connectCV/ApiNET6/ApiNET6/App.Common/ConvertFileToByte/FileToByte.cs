using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Common
{
    public class FileToByte
    {
        public static byte[] ConvertByteToFile(string link)
        {
            var path = "wwwroot/" + link;
            var folder_file = Path.Combine(Directory.GetCurrentDirectory(), path);
            byte[] bytes = File.ReadAllBytes(folder_file);
            return bytes;
        }
        public static byte[] ConvertByteToFile2(string link)
        {
            var folder_file = Path.Combine(Directory.GetCurrentDirectory(), link);
            byte[] bytes = File.ReadAllBytes(folder_file);
            return bytes;
        }
    }
}
