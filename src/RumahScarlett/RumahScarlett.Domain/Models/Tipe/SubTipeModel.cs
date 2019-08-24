using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Tipe
{
   [Table("sub_tipe")]
   public class SubTipeModel : ISubTipeModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Tipe harus diisi !!!")]
      [DisplayName("Tipe ID")]
      public uint tipe_id { get; set; } 

      [Dp.Write(false)]
      [DisplayName("Tipe")]
      public string tipe_nama { get; set;  }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama Sub tipe harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama Sub tipe harus diantara 3 sampai 100 karakter !!!")]
      [DisplayName("Nama")]
      public string nama { get; set; }

      [DefaultValue("")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [DisplayName("Keterangan")]
      public string keterangan { get; set; }
   }
}
