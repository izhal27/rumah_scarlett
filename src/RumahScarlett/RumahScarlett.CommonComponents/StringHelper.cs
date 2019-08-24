using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.CommonComponents
{
   public static class StringHelper
   {
      public static string DuplicateEntry(string key, string modelName)
      {
         return $"{key.FirstToUpper()} {modelName} sudah ada, " +
                $"silahkan ganti dengan {key} {modelName} yang lain.";
      }

      public static string GetStringByLength(int length)
      {
         var strBuild = new StringBuilder();

         for (int i = 0; i < length; i++)
         {
            strBuild.Append("a");
         }

         return strBuild.ToString();
      }

      public static string QueryStringByDate(string table, string columnDateName = "date",
                                             string dateParamName = "@date", params string[] columns)
      {
         var strBuilder = new StringBuilder();

         if (columns.Length != 0)
         {
            for (int i = 0; i < columns.Length; i++)
            {
               if (i != (columns.Length - 1))
               {
                  strBuilder.Append(columns[i]).Append(", ");
               }
               else
               {
                  strBuilder.Append(columns[i]);
               }
            }
         }

         var columnsFix = columns.Length == 0 ? "*" : strBuilder.ToString();
         var queryStr = $"SELECT {columnsFix} FROM {table} WHERE DATE({columnDateName})={dateParamName}";

         return queryStr;
      }

      public static string QueryStringByBetweenDate(string table, string columnDateName = "date",
                                                    string startDateParamName = "@startDate",
                                                    string endDateParamName = "@endDate", params string[] columns)
      {
         var strBuilder = new StringBuilder();

         if (columns.Length != 0)
         {
            for (int i = 0; i < columns.Length; i++)
            {
               if (i != (columns.Length - 1))
               {
                  strBuilder.Append(columns[i]).Append(", ");
               }
               else
               {
                  strBuilder.Append(columns[i]);
               }
            }
         }

         var columnsFix = columns.Length == 0 ? "*" : strBuilder.ToString();
         var queryStr = $"SELECT {columnsFix} FROM {table} WHERE DATE({columnDateName}) BETWEEN {startDateParamName} AND {endDateParamName}";

         return queryStr;
      }

   }
}
