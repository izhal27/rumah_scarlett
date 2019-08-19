namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanDetail
   {
      int id { get; set; }
      int penjualan_id { get; set; }
      int barang_id { get; set; }
      string barang_nama { get; set; }
      int qty { get; set; }
      decimal harga_jual { get; set; }
      decimal total { get; set; }
   }
}