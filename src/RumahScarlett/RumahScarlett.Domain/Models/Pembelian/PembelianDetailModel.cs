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

namespace RumahScarlett.Domain.Models.Pembelian
{
   [Table("pembelian_detail")]
   public class PembelianDetailModel : IPembelianDetailModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public PembelianModel Pembelian { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Pembelian ID harus diisi !!!")]
      [DisplayName("Pembelian ID")]
      public uint pembelian_id { get { return Pembelian.id; } }

      [Browsable(false)]
      [Dp.Write(false)]
      public BarangModel Barang { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Barang ID harus diisi !!!")]
      [DisplayName("Barang ID")]
      public uint barang_id { get { return Barang.id; } }

      [Dp.Write(false)]
      [DisplayName("Kode Barang")]
      public string kode_barang { get { return Barang.kode; } }

      [Dp.Write(false)]
      [DisplayName("Nama Barang")]
      public string nama_barang { get { return Barang.nama; } }

      [Range(1, uint.MaxValue, ErrorMessage = "Qty harus diisi !!!")]
      [DisplayName("Qty")]
      public uint qty { get; set; }

      [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "HPP harus diisi !!!")]
      [DisplayName("HPP")]
      public decimal hpp { get { return Barang.hpp; } }

      [Dp.Write(false)]
      [DisplayName("Total")]
      public decimal total
      {
         get
         {
            return qty > 0M ? decimal.Parse((qty * hpp).ToString()) : 0M;
         }
      }
   }
}
