//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Telerik Academy">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension methods for converting string representation.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the hexadecimal string representation of the input string.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>hexadecimal string representation of the input string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Returns the boolean representation of the input string if it is possible.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>boolean representation of the input string</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };

            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Returns the short representation of the input string if it is possible.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>short representation of the input string</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);

            return shortValue;
        }

        /// <summary>
        /// Returns the integer representation of the input string if it is possible.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>integer representation of the input string</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);

            return integerValue;
        }

        /// <summary>
        /// Returns the long representation of the input string if it is possible.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>long representation of the input string</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);

            return longValue;
        }

        /// <summary>
        /// Returns the DateTime representation of the input string if it is possible.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>DateTime representation of the input string</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);

            return dateTimeValue;
        }

        /// <summary>
        /// Returns new string representation of the input string with first letter as capital letter.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>string with first letter as capital letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns string between two strings in a string.
        /// </summary>
        /// <param name="input">input string to be searched in</param>
        /// <param name="startString">starting string</param>
        /// <param name="endString">ending string</param>
        /// <param name="startFrom">optional position to be started from, 
        /// if it is not chosen, it searches from the beginning of the input string</param>
        /// <returns>string between two strings</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;

            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;

            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);

            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts cyrillic to latin letters.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>converted string with latin letters instead of cyrillic letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };

            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };

            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts latin to cyrillic letters.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>converted string with cyrillic letters instead of latin letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts the input string to a valid username with latin letters.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>string which is a valid username</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();

            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts the input string to valid file name with latin letters.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>string which is a valid file name</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();

            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns the first characters in a string.
        /// </summary>
        /// <param name="input">input string to be searched in</param>
        /// <param name="charsCount">the amount of the first characters</param>
        /// <returns>the first characters with an amount of charsCount</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Return the extension of a file.
        /// </summary>
        /// <param name="fileName">the name of the file to be searched</param>
        /// <returns>the extension of the file with name fileName</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);

            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts the file extension to another file extension.
        /// </summary>
        /// <param name="fileExtension">the new extension of the file to be converted to</param>
        /// <returns>the converted extension of the file</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };

            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a string input to array of bytes.
        /// </summary>
        /// <param name="input">input string to be converted</param>
        /// <returns>the array of bytes of the converted string input</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);

            return bytesArray;
        }
    }
}
