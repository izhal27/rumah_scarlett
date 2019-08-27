using RumahScarlett.Domain.Models.PenyesuaianStok;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Barang
{
   public interface IBarangModel
   {
      uint id { get; set; }
      string kode { get; set; }
      string nama { get; set; }
      uint sub_tipe_id { get; set; }
      int penyesuaian_stok_qty { get; }
      uint supplier_id { get; set; }
      decimal harga_jual { get; set; }
      decimal harga_lama { get; set; }
      decimal hpp { get; set; }
      int stok { get; set; }
      int minimal_stok { get; set; }
      IEnumerable<IPenyesuaianStokDetailModel> PenyesuaianStokDetails { get; set; }
   }
}