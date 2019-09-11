using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Penjualan;
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

      public int stok_awal { get; set; }

      private int _stok_masuk;

      public int stok_masuk
      {
         get
         {
            return Pembelian.id != default(uint) ? Pembelian.PembelianDetails.Sum(pd => pd.qty) : _stok_masuk;
         }
         set { _stok_masuk = value; }
      }

      private int _stok_keluar;

      public int stok_keluar
      {
         get
         {
            return Penjualan.id != default(uint) ? Penjualan.PenjualanDetails.Sum(pd => pd.qty) : _stok_keluar;
         }
         set { _stok_keluar = value; }
      }

      public int stok_akhir
      {
         get { return (stok_awal + stok_masuk) - stok_keluar; }
      }

      public StatusBarangModel()
      {
         Pembelian = new PembelianModel();
         Penjualan = new PenjualanModel();
      }
   }
}
