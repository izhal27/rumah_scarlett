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
   }
}
