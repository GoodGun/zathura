using System;
using System.Collections.Generic;
using System.Linq;

namespace Zathura.Core.Extension
{
    public static class CommonExtensions
    {
        public static readonly char[] comma = { ',' };
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();
            return source.Where(element => knownKeys.Add(keySelector(element)));
        }

        /// <summary>
        /// Extension Method To Apply ForEach on IList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="function"></param>
        public static void ForEach<T>(this IList<T> list, Action<T> function)
        {
            foreach (T item in list)
            {
                function(item);
            }
        }

        /// <summary>
        /// Extension Method To Apply ForEach on IEnumerable List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="function"></param>
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> function)
        {
            foreach (T item in list)
            {
                function(item);
            }
        }

        /// <summary>
        /// Null olsa da olmasa da string döndürür.
        /// </summary>
        /// <param name="str">parametre</param>
        /// <returns>null ise boş string, değilse .ToString()</returns>
        public static string NullToString(this object str, string defaultValue = "")
        {
            if (str == null) return defaultValue;
            string res = str.ToString();
            return string.IsNullOrEmpty(res) ? defaultValue : res;
        }

        /// <summary>
        /// Bir nesnenin null ya da boş string olup olmadığını döndürür.
        /// Öncesinde null kontrolü yapmaya gerek yoktur.
        /// </summary>
        /// <param name="str">parametre</param>
        /// <returns>Bir nesnenin null ya da boş string olup olmadığını döndürür.</returns>
        public static bool NullOrEmpty(this object str)
        {
            return str == null ? true : string.IsNullOrEmpty(str.ToString());
        }
        
        /// <summary>
        /// Herhangi bir nesneyi bit/bool'a çevirir.
        /// </summary>
        /// <param name="str">nesne</param>
        /// <returns>Herhangi bir nesneyi bit/bool'a çevirir.</returns>
        public static bool ToBool(this object str)
        {
            if (str == null) return false;
            bool result = false;
            if (bool.TryParse(str.ToString().Replace("1", "True").Replace("0", "False"), out result))
                return result;

            try
            {
                return str.ToInt32() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Herhangi bir nesneyi byte'a çevirir.
        /// </summary>
        /// <param name="str">nesne</param>
        /// <returns>Herhangi bir nesneyi bit/bool'a çevirir.</returns>
        public static byte ToByte(this object str)
        {
            if (str == null || string.IsNullOrEmpty(str.ToString()))
                return 0;

            try
            {
                return Convert.ToByte(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Herhangi bir nesneyi short'a çevirir.
        /// </summary>
        /// <param name="str">nesne</param>
        /// <returns>Herhangi bir nesneyi bit/bool'a çevirir.</returns>
        public static short ToShort(this object str)
        {
            if (str == null) return 0;
            short result = 0;
            short.TryParse(str.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Herhangi bir nesneyi int'e çevirir.
        /// </summary>
        /// <param name="str">nesne</param>
        /// <returns>Herhangi bir nesneyi bit/bool'a çevirir.</returns>
        public static int ToInt32(this object str)
        {
            if (str == null) return 0;
            int result = 0;
            try
            {
                result = Convert.ToInt32(str);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static Int64 ToInt64(this object str)
        {
            if (str == null) return 0;
            Int64 result = 0;
            try
            {
                result = Convert.ToInt64(str);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        /// <summary>
        /// Herhangi bir nesneyi long'a çevirir.
        /// </summary>
        /// <param name="str">nesne</param>
        /// <returns>Herhangi bir nesneyi bit/bool'a çevirir.</returns>
        public static long ToLong(this object str)
        {
            if (str == null) return 0;
            long result = 0;
            long.TryParse(str.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Herhangi bir nesneyi decimal'a çevirir.
        /// </summary>
        /// <param name="str">nesne</param>
        /// <returns>Herhangi bir nesneyi bit/bool'a çevirir.</returns>
        public static decimal ToDecimal(this object str)
        {
            if (str == null) return 0;
            decimal result = 0;
            decimal.TryParse(str.ToString(), out result);
            return result;
        }

        public static List<string> ToStringList(this string value, char[] seperator = null)
        {
            var arr = new List<string>();

            try
            {
                if (seperator == null) seperator = comma;
                if (!string.IsNullOrEmpty(value) && value != "%00")
                    arr.AddRange(value.Split(seperator, StringSplitOptions.RemoveEmptyEntries));
            }
            catch (Exception ex)
            {

            }

            return arr;
        }
    }
}
