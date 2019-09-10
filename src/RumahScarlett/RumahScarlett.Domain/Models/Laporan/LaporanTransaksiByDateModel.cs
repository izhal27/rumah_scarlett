using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Laporan
{
   public class LaporanTransaksiByDateModel : ILaporanTransaksiByDateModel
   {
      public decimal kas_awal { get; set; }
      public decimal total_penjualan { get; set; }
      public decimal total_diskon { get; set; }
      public decimal total_pengeluaran { get; set; }
      public decimal selisih
      {
         get { return (kas_awal + total_penjualan) - total_diskon - total_pengeluaran; }
      }
   }
}
