using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanDetailModel
   {
      uint id { get; set; }
      uint penjualan_id { get; set; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; set; }
      string barang_kode { get; set; }
      string barang_nama { get; set; }
      int qty { get; set; }
      string barang_satuan { get; }
      decimal hpp { get; set; }
      decimal harga_jual { get; set; }
      decimal total { get; }
   }
}