namespace RumahScarlett.Domain.Models.Laporan
{
   public interface IStatusPerBarangModel
   {
      uint id { get; set; }
      string kode { get; set; }
      string nama { get; set; }
      string satuan { get; set; }
      string stok_keluar { get; set; }
      string stok_masuk { get; set; }
   }
}