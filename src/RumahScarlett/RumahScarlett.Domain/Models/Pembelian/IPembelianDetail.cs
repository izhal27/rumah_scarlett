namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianDetail
   {
      int id { get; set; }
      int pembelian_id { get; set; }
      int barang_id { get; set; }
      string barang_nama { get; set; }
      int qty { get; set; }
      decimal harga_beli { get; set; }
      decimal total { get; set; }
   }
}