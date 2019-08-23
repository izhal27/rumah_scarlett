using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianDetailModel
   {
      uint id { get; set; }
      IPembelianModel Pembelian { get; set; }
      uint pembelian_id { get; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; }
      string kode_barang { get; }
      string nama_barang { get; }
      decimal hpp { get; set; }
      uint qty { get; set; }
      decimal total { get; }
   }
}