using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianDetailModel
   {
      uint id { get; set; }
      uint pembelian_id { get; set; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; set;  }
      string barang_kode { get; }
      string barang_nama { get; }
      decimal hpp { get; set; }
      uint qty { get; set; }
      decimal total { get; }
   }
}