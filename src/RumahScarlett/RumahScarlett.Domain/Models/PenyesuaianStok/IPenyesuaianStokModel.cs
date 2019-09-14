using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Satuan;
using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.PenyesuaianStok
{
   public interface IPenyesuaianStokModel
   {
      uint id { get; set; }
      DateTime tanggal { get; set; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; set; }
      string barang_kode { get; }
      string barang_nama { get; }
      int qty { get; set; }
      ISatuanModel Satuan { get; set; }
      uint satuan_id { get; set; }
      string satuan_nama { get; set; }
      decimal hpp { get; set; }
      decimal total_hpp { get; }
      string keterangan { get; set; }
   }
}