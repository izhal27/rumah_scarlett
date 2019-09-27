using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using System;

namespace RumahScarlett.Domain.Models.Laporan
{
   public interface IStatusBarangModel
   {
      long id { get; set; }
      DateTime tanggal { get; set; }
      IPembelianModel Pembelian { get; set; }
      uint? pembelian_id { get; }
      IPenjualanModel Penjualan { get; set; }
      uint? penjualan_id { get; }
      IPenyesuaianStokModel PenyesuaianStok { get; set; }
      uint? penyesuaian_stok_id { get; }
      IPenjualanReturnModel PenjualanReturn { get; set; }
      uint? penjualan_return_id { get; }
      IPembelianReturnModel PembelianReturn { get; set; }
      uint? pembelian_return_id { get; }
      int stok_awal { get; set; }
      int stok_masuk { get; set; }
      int stok_terjual { get; set; }
      int penyesuaian_stok { get; set; }
      int pembelian_return_qty { get; set; }
      int penjualan_return_qty { get; set; }
      int stok_akhir { get; }
   }
}