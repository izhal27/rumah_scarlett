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

namespace RumahScarlett.Domain.Models.Penjualan
{
   [Table("penjualan_detail")]
   public class PenjualanDetail : IPenjualanDetail
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public int id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Penjualan ID harus diisi !!!")]
      [DisplayName("Penjualan ID")]
      public int penjualan_id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Barang ID harus diisi !!!")]
      [DisplayName("Barang ID")]
      public int barang_id { get; set; }

      [Dp.Write(false)]
      [DisplayName("Barang")]
      public string barang_nama { get; set; }

      [Required(ErrorMessage = "Minimal Qty pembelian 1 !!!")]
      [IntegerValidator(MinValue = 1)]
      [DisplayName("Qty")]
      public int qty { get; set; }

      [Required(ErrorMessage = "Harga jual harus diisi !!!")]
      [IntegerValidator(MinValue = 1)]
      [DisplayName("Harga Jual")]
      public decimal harga_jual { get; set; }

      [Dp.Write(false)]
      [DisplayName("Total")]
      public decimal total { get; set; }
   }
}
