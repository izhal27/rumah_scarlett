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
      public uint id { get; set; }

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

      public int _penyesuaian_stok;

      public int penyesuaian_stok
      {
         get { return PenyesuaianStok.id != default(uint) ? PenyesuaianStok.qty : _penyesuaian_stok; }
         set { _penyesuaian_stok = value; }
      }

      public int stok_akhir
      {
         get { return (stok_awal + stok_masuk) - (stok_terjual + penyesuaian_stok); }
      }

      public StatusBarangModel()
      {
         Pembelian = new PembelianModel();
         Penjualan = new PenjualanModel();
         PenyesuaianStok = new PenyesuaianStokModel();
      }
   }
}
