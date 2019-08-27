using RumahScarlett.Domain.Models.Barang;
using System;

namespace RumahScarlett.Domain.Models.PenyesuaianStok
{
   public interface IPenyesuaianStokDetailModel
   {
      uint id { get; set; }
      uint penyesuaian_stok_id { get; set; }
      string penyesuaian_stok_no_nota { get; set; }
      DateTime penyesuaian_stok_tanggal { get; set; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; set; }
      string barang_kode { get; }
      string barang_nama { get; }
      int qty { get; set; }
      decimal hpp { get; }
      string keterangan { get; set; }
   }
}