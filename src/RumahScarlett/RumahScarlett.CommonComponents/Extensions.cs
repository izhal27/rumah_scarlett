using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.CommonComponents
{
   public static class Extensions
   {
      public static string FirstToUpper(this string str)
      {
         return str.First().ToString().ToUpper() + str.Substring(1);
      }

      public static string ToMysqlDateFormat(this DateTime date)
      {
         return date.ToString("yyyy-MM-dd");
      }

      public static string ToMysqlDateTimeFormat(this DateTime date)
      {
         return date.ToString("yyyy-MM-dd HH:mm:ss");
      }

      /// <summary>
      /// Extension yang digunakan untuk melakukan suatu action
      /// terhadap property yang ada di dalam list
      /// </summary>
      /// <typeparam name="T">Type source</typeparam>
      /// <param name="source">List source</param>
      /// <param name="action">Delegate action</param>
      /// <returns></returns>
      public static IEnumerable<T> Map<T>(this IEnumerable<T> source, Action<T> action)
      {
         foreach (var item in source)
         {
            action(item);
            yield return item;
         }
      }
   }
}
