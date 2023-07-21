using System;
using TemplateEngine.Docx;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Reflection;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace App.Business.Utils
{
    public static class UtilsHandler
    {
        public static FieldContent ConvertToField(string field, string value)
        {
            FieldContent result = new FieldContent(field, "");
            if (!string.IsNullOrEmpty(value))
            {
                result = new FieldContent(field, value);
            }
            return result;

        }

        #region md5 GenerateKey object
        public static String GenerateKey(Object sourceObject)
        {
            String hashString;

            //Catch unuseful parameter values
            if (sourceObject == null)
            {
                throw new ArgumentNullException("Null as parameter is not allowed");
            }
            else
            {
                //We determine if the passed object is really serializable.
                try
                {
                    //Now we begin to do the real work.
                    hashString = ComputeHash(ObjectToByteArray(sourceObject));
                    return hashString;
                }
                catch (AmbiguousMatchException ame)
                {
                    throw new ApplicationException("Could not definitely decide if object is serializable.Message:" + ame.Message);
                }
            }
        }

        private static string ComputeHash(byte[] objectAsBytes)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            try
            {
                byte[] result = md5.ComputeHash(objectAsBytes);

                // Build the final string by converting each byte
                // into hex and appending it to a StringBuilder
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("X2"));
                }

                // And return it
                return sb.ToString();
            }
            catch (ArgumentNullException ane)
            {
                //If something occurred during serialization, 
                //this method is called with a null argument. 
                Console.WriteLine("Hash has not been generated.");
                return null;
            }
        }

        private static readonly Object locker = new Object();

        //private static byte[] ObjectToByteArray(Object objectToSerialize)
        //{
        //    MemoryStream fs = new MemoryStream();
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    try
        //    {
        //        //Here's the core functionality! One Line!
        //        //To be thread-safe we lock the object
        //        lock (locker)
        //        {
        //            formatter.Serialize(fs, objectToSerialize);
        //        }
        //        return fs.ToArray();
        //    }
        //    catch (SerializationException se)
        //    {
        //        Console.WriteLine("Error occurred during serialization. Message: " +
        //        se.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        fs.Close();
        //    }
        //}

        private static byte[] ObjectToByteArray(object objectToSerialize)
        {
            using (MemoryStream fs = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                lock (locker)
                {
                    formatter.Serialize(fs, objectToSerialize);
                }
                return fs.ToArray();
            }
        }
        #endregion

        public static string RevertMaDongToMaDuToan(string val)
        {
            try
            {
                if (!string.IsNullOrEmpty(val))
                {
                    var tokens = val.Split('.').ToList();
                    if (String.IsNullOrWhiteSpace(tokens.Last())) { tokens.Remove(""); }

                    List<string> lst_string_temp = new List<string>();

                    for (var ii = 0; ii < tokens.Count; ii++)
                    {
                        if (!string.IsNullOrEmpty(tokens[ii]))
                        {
                            int i = 0;
                            foreach (char item in tokens[ii])
                            {
                                if (item != '0')
                                    break;

                                i++;
                            }
                            string temp = tokens[ii].Substring(i);
                            lst_string_temp.Add(temp);
                        }
                    }
                    return string.Join(".", lst_string_temp);

                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeepCompare(this object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            //Compare two object's class, return false if they are difference
            if (obj.GetType() != another.GetType()) return false;

            var result = true;
            //Get all properties of obj
            //And compare each other
            foreach (var property in obj.GetType().GetProperties())
            {
                var objValue = property.GetValue(obj);
                var anotherValue = property.GetValue(another);
                if (objValue == anotherValue)
                    continue;
                else if (objValue == null && another != null) result = false;
                else if (objValue != null && !objValue.Equals(anotherValue)) result = false;
            }

            return result;
        }

        public static bool CompareEx(this object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            if (obj.GetType() != another.GetType()) return false;

            //properties: int, double, DateTime, etc, not class
            if (!obj.GetType().IsClass) return obj.Equals(another);

            var result = true;
            foreach (var property in obj.GetType().GetProperties())
            {
                var objValue = property.GetValue(obj);
                var anotherValue = property.GetValue(another);
                //Recursion
                if (DeepCompare(objValue, anotherValue) == false) result = false;
            }
            return result;
        }
    }
}
