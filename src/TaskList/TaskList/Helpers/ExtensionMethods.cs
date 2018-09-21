using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TaskList
{
    public static class ExtensionMethods
    {
        public static string FirstCapitalLetter(this string str)
        {
            try
            {
                var arr = str.Trim().Split(' ');
                var word = "";
                for (int i = 0; i < arr.Count(); i++)
                {
                    arr[i] = arr[i].ToLower();
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        var character = arr[i][j].ToString();
                        word += (j == 0) ? character.ToUpper() : character;
                    }
                    if (i < arr.Count() - 1)
                    {
                        word += " ";
                    }
                }
                return word;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            string descricao = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            return descricao;
        }

        public static string FormatDecimal(this decimal? number)
        {
            //Truncate
            if ( number == null)
            {
                return string.Format("{0:n0}", 0);
            }
            return string.Format("{0:n0}", Math.Round(number.Value));
        }

        public static string FormatDecimal(this decimal number)
        {
            //Truncate
            return string.Format("{0:n0}", Math.Round(number));
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static void SetPropertyAsString(this IReflectionExtension self, string propertyName, object value)
        {
            var property = TypeDescriptor.GetProperties(self)[propertyName];
            //var convertedValue = property.Converter.ConvertFrom(value);
            property.SetValue(self, value);
        }

        public static object GetPropertyAsObject(this IReflectionExtension self, string propertyName)
        {
            var property = TypeDescriptor.GetProperties(self)[propertyName];
            return property.GetValue(self);
        }

        public static string Crypt(this string input)
        {
            byte xorConstant = 0x53;

            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            return Convert.ToBase64String(data);

        }

        public static string Dercypt(this string input)
        {
            byte xorConstant = 0x53;
            byte[] data = Convert.FromBase64String(input);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            return System.Text.Encoding.UTF8.GetString(data);
        }

        public static string NameComp(this DateTime value)
        {
            var moonthName = DateTimeFormatInfo.GetInstance(null).GetMonthName(value.Month).FirstCapitalLetter().Substring(0,3);
            return moonthName + "/" + value.Year;
        }
    }

    public interface IReflectionExtension { }
}