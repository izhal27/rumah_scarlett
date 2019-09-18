using RumahScarlett.Domain.Models.Pelanggan;
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
      IPelangganModel Pelanggan { get; set; }
      uint pelanggan_id { get; set; }
      string pelanggan_nama { get; }
      DateTime tanggal { get; set; }
      decimal sub_total { get; }
      decimal diskon { get; set; }
      decimal grand_total { get; }
      decimal jumlah_bayar { get; set; }
      decimal kembali { get; }
      IEnumerable<IPenjualanDetailModel> PenjualanDetails { get; set; }
   }
}