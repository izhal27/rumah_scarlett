namespace RumahScarlett.Domain.Models.PenyesuainStok
{
   public interface IPenyesuaianStokDetailModel
   {
      uint id { get; set; }
      uint penyesuaian_stok_id { get; set; }
      uint barang_id { get; set; }
      string barang_nama { get; set; }
      uint qty { get; set; }
      string keterangan { get; set; }
   }
}