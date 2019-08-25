using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.PenyesuaianStok
{
   public interface IPenyesuaianStokDetailModel
   {
      uint id { get; set; }
      uint penyesuaian_stok_id { get; set; }
      IBarangModel Barang { get; set; }
      string barang_kode { get; }
      uint barang_id { get; }
      string barang_nama { get; }
      uint qty { get; set; }
      decimal hpp { get; }
      string keterangan { get; set; }
   }
}