using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.Penjualan
{
   [Table("penjualan_detail")]
   public class PenjualanDetailModel : IPenjualanDetailModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Penjualan ID harus diisi !!!")]
      [DisplayName("Penjualan ID")]
      public uint penjualan_id { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IBarangModel Barang { get; set; }

      private uint _barang_id;

      [Browsable(false)]
      [Required(ErrorMessage = "Barang ID harus diisi !!!")]
      [DisplayName("Barang ID")]
      public uint barang_id
      {
         get { return Barang.id != default(uint) ? Barang.id : _barang_id; }
         set { _barang_id = value; }
      }

      [Dp.Write(false)]
      [DisplayName("Kode Barang")]
      public string barang_kode { get { return Barang != null ? Barang.kode : string.Empty; } }

      [Dp.Write(false)]
      [DisplayName("Nama Barang")]
      public string barang_nama { get { return Barang != null ? Barang.nama : string.Empty; } }

      [Range(1, uint.MaxValue, ErrorMessage = "Qty harus diisi !!!")]
      [DisplayName("Qty")]
      public int qty { get; set; }

      private decimal _harga_jual;

      [DisplayName("Harga Jual")]
      public decimal harga_jual
      {
         get { return Barang.harga_jual != default(decimal) ? Barang.harga_jual : _harga_jual; }
         set { _harga_jual = value; }
      }

      [Dp.Write(false)]
      [DisplayName("Total")]
      public decimal total
      {
         get
         {
            return qty > 0M ? decimal.Parse((qty * harga_jual).ToString()) : 0M;
         }
      }

      public PenjualanDetailModel()
      {
         Barang = new BarangModel();
      }
   }
}
