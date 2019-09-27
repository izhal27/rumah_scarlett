using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dp = Dapper.Contrib.Extensions;

namespace RumahScarlett.Domain.Models.Laporan
{
   [Table("status_barang")]
   public class StatusBarangModel : IStatusBarangModel
   {
      public long id { get; set; }

      public DateTime tanggal { get; set; }

      [Dp.Write(false)]
      public IPembelianModel Pembelian { get; set; }

      public uint? pembelian_id
      {
         get { return Pembelian.id != default(uint) ? Pembelian.id : (uint?)null; }
      }

      [Dp.Write(false)]
      public IPenjualanModel Penjualan { get; set; }

      public uint? penjualan_id
      {
         get { return Penjualan.id != default(uint) ? Penjualan.id : (uint?)null; }
      }

      [Dp.Write(false)]
      public IPenyesuaianStokModel PenyesuaianStok { get; set; }

      public uint? penyesuaian_stok_id
      {
         get { return PenyesuaianStok.id != default(uint) ? PenyesuaianStok.id : (uint?)null; }
      }

      [Dp.Write(false)]
      public IPenjualanReturnModel PenjualanReturn { get; set; }

      public uint? penjualan_return_id
      {
         get { return PenjualanReturn.id != default(uint) ? PenjualanReturn.id : (uint?)null; }
      }

      [Dp.Write(false)]
      public IPembelianReturnModel PembelianReturn { get; set; }

      public uint? pembelian_return_id
      {
         get { return PembelianReturn.id != default(uint) ? PembelianReturn.id : (uint?)null; }
      }

      public int stok_awal { get; set; }

      private int _stok_masuk;

      public int stok_masuk
      {
         get { return Pembelian.id != default(uint) ? Pembelian.PembelianDetails.Sum(pd => pd.qty) : _stok_masuk; }
         set { _stok_masuk = value; }
      }

      private int _stok_terjual;

      public int stok_terjual
      {
         get { return Penjualan.id != default(uint) ? Penjualan.PenjualanDetails.Sum(pd => pd.qty) : _stok_terjual; }
         set { _stok_terjual = value; }
      }

      private int _penyesuaian_stok;

      public int penyesuaian_stok
      {
         get { return PenyesuaianStok.id != default(uint) ? PenyesuaianStok.qty : _penyesuaian_stok; }
         set { _penyesuaian_stok = value; }
      }

      private int _pembelian_return_qty;

      public int pembelian_return_qty
      {
         get { return PembelianReturn.id != default(uint) ? PembelianReturn.PembelianReturnDetails.Sum(prd => prd.qty) : _pembelian_return_qty; }
         set { _pembelian_return_qty = value; }
      }

      private int _penjualan_return_qty;

      public int penjualan_return_qty
      {
         get { return PenjualanReturn.id != default(uint) ? PenjualanReturn.PenjualanReturnDetails.Sum(prd => prd.qty) : _penjualan_return_qty; }
         set { _penjualan_return_qty = value; }
      }

      public int stok_akhir
      {
         get { return (stok_awal + stok_masuk + penjualan_return_qty) - (stok_terjual + penyesuaian_stok); }
      }

      public StatusBarangModel()
      {
         Pembelian = new PembelianModel();
         Penjualan = new PenjualanModel();
         PenyesuaianStok = new PenyesuaianStokModel();
         PenjualanReturn = new PenjualanReturnModel();
         PembelianReturn = new PembelianReturnModel();
      }
   }
}
