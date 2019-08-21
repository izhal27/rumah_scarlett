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
   }
}
