using RumahScarlett.Domain.Models.PenyesuaianStok;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Barang
{
   public interface IBarangModel
   {
      uint id { get; set; }
      uint sub_tipe_id { get; set; }
      uint supplier_id { get; set; }
      uint satuan_id { get; set; }
      string kode { get; set; }
      string nama { get; set; }
      int penyesuaian_stok_qty { get; }
      decimal harga_jual { get; set; }
      decimal harga_lama { get; set; }
      decimal hpp { get; set; }
      int stok { get; set; }
      int minimal_stok { get; set; }
      string satuan_nama { get; set; }
      IEnumerable<IPenyesuaianStokDetailModel> PenyesuaianStokDetails { get; set; }
   }
}