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
      public uint id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Pembelian ID harus diisi !!!")]
      [DisplayName("Pembelian ID")]
      public uint pembelian_id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Barang ID harus diisi !!!")]
      [DisplayName("Barang ID")]
      public uint barang_id { get; set; }

      [Dp.Write(false)]
      [DisplayName("Barang")]
      public string barang_nama { get; set; }

      [Required(ErrorMessage = "Minimal Qty pembelian 1 !!!")]
      [IntegerValidator(MinValue = 0)]
      [DisplayName("Qty")]
      public uint qty { get; set; }

      [Required(ErrorMessage = "HPP harus diisi !!!")]
      [IntegerValidator(MinValue = 0)]
      [DisplayName("HPP")]
      public decimal hpp { get; set; }

      [Dp.Write(false)]
      [DisplayName("Total")]
      public decimal total { get; set; }
   }
}
