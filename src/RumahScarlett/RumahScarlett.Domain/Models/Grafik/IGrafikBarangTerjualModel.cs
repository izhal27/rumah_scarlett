﻿namespace RumahScarlett.Domain.Models.Grafik
{
   public interface IGrafikBarangTerjualModel
   {
      string barang_nama { get; set; }
      long stok_terjual { get; set; }
   }
}