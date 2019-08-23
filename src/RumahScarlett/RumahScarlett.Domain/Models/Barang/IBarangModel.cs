﻿namespace RumahScarlett.Domain.Models.Barang
{
   public interface IBarangModel
   {
      uint id { get; set; }
      string kode { get; set; }
      string nama { get; set; }
      uint sub_tipe_id { get; set; }
      uint supplier_id { get; set; }
      decimal harga_jual { get; set; }
      decimal harga_lama { get; set; }
      decimal hpp { get; set; }
      uint minimal_stok { get; set; }
      uint stok { get; set; }
   }
}