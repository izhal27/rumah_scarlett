using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Helper
{
   public static class DataSourceHelper
   {
      public static List<KeyValuePair<int, string>> StatusReturn = new List<KeyValuePair<int, string>>
      {
         new KeyValuePair<int, string>(0, "Barang Rusak atau Cacat"),
         new KeyValuePair<int, string>(1, "Barang salah"),
         new KeyValuePair<int, string>(2, "Qty lebih")
      };
   }
}
