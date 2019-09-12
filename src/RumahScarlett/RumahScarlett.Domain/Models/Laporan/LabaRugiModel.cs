using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Laporan
{
   public class LabaRugiModel : ILabaRugiModel
   {
      public decimal total_penjualan { get; set; }
      public decimal total_hpp { get; set; }
      public decimal total_pengeluaran { get; set; }
      public decimal total_diskon_penjualan { get; set; }
   }
}
