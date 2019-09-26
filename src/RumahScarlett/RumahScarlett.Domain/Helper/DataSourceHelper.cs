using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Helper
{
   public static class DataSourceHelper
   {
      public static List<KeyValuePair<object, string>> StatusReturn = new List<KeyValuePair<object, string>>
      {
         new KeyValuePair<object, string>(1, "Barang Rusak atau Cacat"),
         new KeyValuePair<object, string>(2, "Barang salah"),
         new KeyValuePair<object, string>(3, "Qty lebih")
      };
   }
}
