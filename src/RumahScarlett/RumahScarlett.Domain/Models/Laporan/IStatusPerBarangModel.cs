namespace RumahScarlett.Domain.Models.Laporan
{
   public interface IStatusPerBarangModel
   {
      uint id { get; set; }
      string kode { get; set; }
      string nama { get; set; }
      string satuan { get; set; }
      long stok_keluar { get; set; }
      long stok_masuk { get; set; }
   }
}