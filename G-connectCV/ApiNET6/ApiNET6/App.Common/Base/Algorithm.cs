using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace App.Common.Base
{

    public static class MD5algorithm
    {
        static public string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        static public string GetMd5Hash(string input, string salt)
        {
            MD5 md5Hash = MD5.Create();
            var result = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, input) + salt));
            return result;
        }
        // Verify a hash against a string.
        static public bool VerifyMd5Hash(string input, string hash, string salt)
        {

            MD5 md5Hash = MD5.Create();
            var result = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, input) + salt));
            // Hash the input.
            string hashOfInput = GetMd5Hash(input, salt);
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public static class SHA256algorithm
    {
        public static string GetSHA256Hash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
    }
    public static class Salt
    {
        public static string GetCode(int lengthOfByte)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[lengthOfByte];
            rng.GetBytes(buffer);
            string salt = BitConverter.ToString(buffer);
            salt = salt.Replace("-", string.Empty);
            return salt;
        }
    }
    public static class RandomString
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);
        public static string GenerateId(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
