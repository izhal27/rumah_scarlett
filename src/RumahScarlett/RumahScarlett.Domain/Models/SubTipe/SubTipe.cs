using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.SubTipe
{
   [Table("sub_tipe")]
   public class SubTipe : ISubTipe
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public int id { get; set; }

      [Browsable(false)]
      [DisplayName("Tipe ID")]
      [Required(ErrorMessage = "Tipe harus diisi !!!")]
      public int tipe_id { get; set; }

      [Dp.Write(false)]
      [DisplayName("Tipe")]
      public string tipe_nama { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama tipe harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama tipe harus diantara 3 sampai 100 karakter !!!")]
      [DisplayName("Nama")]
      public string nama { get; set; }

      [DefaultValue("")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [DisplayName("Keterangan")]
      public string keterangan { get; set; }
   }
}
