using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanModel
   {
      uint id { get; set; }
      string no_nota { get; set; }
      string status_pembayaran_nama { get; }
      bool status_pembayaran { get; set; }
      uint pelanggan_id { get; set; }
      string pelanggan_nama { get; set; }
      DateTime tanggal { get; set; }
      decimal diskon { get; set; }
      IEnumerable<IPenjualanDetailModel> PenjualanDetails { get; set; }
   }
}