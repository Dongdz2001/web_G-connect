using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace App.Common.Base
{
    public static class StringExtention
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static string RemoveUnicode(this String s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public static string RemoveSpecialCharacters(this string input)
        {
            Regex r = new Regex(@"(@|,|-|&|'|\(|\)|<|>|#|!|%)");
            return r.Replace(input, "");
        }
        public static string RemoveMultipleSpace(this string input)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            var r = regex.Replace(input, " ");
            r = r.Trim();
            return r;
        }

        public static string RemoveAllSpaces(this string input)
        {
            Regex r = new Regex(@"\s+");
            return r.Replace(input, "");
        }

    }
}
