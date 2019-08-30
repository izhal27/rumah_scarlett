using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Satuan
{
   [Table("satuan")]
   public class SatuanModel : ISatuanModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama satuan harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama satuan harus diantara 3 sampai 100 karakter !!!")]
      [Display(Name = "Nama")]
      public string nama { get; set; }

      [DefaultValue("")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [Display(Name = "Keterangan")]
      public string keterangan { get; set; }
   }
}
