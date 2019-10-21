using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Grafik
{
   public class GrafikBarangTerjualModel : IGrafikBarangTerjualModel
   {
      public string barang_nama { get; set; }
      public long stok_terjual { get; set; }
   }
}
