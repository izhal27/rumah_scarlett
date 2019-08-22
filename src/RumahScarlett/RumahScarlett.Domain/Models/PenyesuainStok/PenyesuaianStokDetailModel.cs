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

namespace RumahScarlett.Domain.Models.PenyesuainStok
{
   [Table("penyesuaian_stok_detail")]
   public class PenyesuaianStokDetailModel : IPenyesuaianStokDetailModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Penyesuaian stok ID harus diisi !!!")]
      [DisplayName("Penyesuaian Stok ID")]
      public uint penyesuaian_stok_id { get; set; }

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
      
      [DefaultValue("")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [DisplayName("Keterangan")]
      public string keterangan { get; set; }
   }
}
