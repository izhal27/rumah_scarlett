using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanDetailModel
   {
      uint id { get; set; }
      uint penjualan_id { get; set; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; set; }
      string barang_kode { get; }
      string barang_nama { get; }
      int qty { get; set; }
      decimal harga_jual { get; set; }
      decimal total { get; }
   }
}