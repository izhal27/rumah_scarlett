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

namespace RumahScarlett.Domain.Models.Pembelian
{
   [Table("pembelian_detail")]
   public class PembelianDetail : IPembelianDetail
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public int id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Pembelian ID harus diisi !!!")]
      [DisplayName("Pembelian ID")]
      public int pembelian_id { get; set; }

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

      [Required(ErrorMessage = "Harga beli harus diisi !!!")]
      [IntegerValidator(MinValue = 1)]
      [DisplayName("Harga Beli")]
      public decimal harga_beli { get; set; }

      [Dp.Write(false)]
      [DisplayName("Total")]
      public decimal total { get; set; }
   }
}
