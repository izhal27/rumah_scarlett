namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanDetailModel
   {
      uint id { get; set; }
      uint penjualan_id { get; set; }
      uint barang_id { get; set; }
      string barang_nama { get; set; }
      uint qty { get; set; }
      decimal harga_jual { get; set; }
      decimal total { get; set; }
   }
}