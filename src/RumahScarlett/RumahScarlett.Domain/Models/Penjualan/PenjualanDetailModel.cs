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
      [Required(ErrorMessage = "Barang ID harus diisi !!!")]
      [DisplayName("Barang ID")]
      public uint barang_id { get; set; }

      [Dp.Write(false)]
      [DisplayName("Barang")]
      public string barang_nama { get; set; }
      
      [Range(1, uint.MaxValue, ErrorMessage = "Qty harus diisi !!!")]
      [DisplayName("Qty")]
      public uint qty { get; set; }
      
      [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Harga jual harus diisi !!!")]
      [DisplayName("Harga Jual")]
      public decimal harga_jual { get; set; }

      [Dp.Write(false)]
      [DisplayName("Total")]
      public decimal total { get; set; }
   }
}
