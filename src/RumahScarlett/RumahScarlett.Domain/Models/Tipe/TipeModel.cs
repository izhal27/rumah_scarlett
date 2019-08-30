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
   [Table("tipe")]
   public class TipeModel : ITipeModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama tipe harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama tipe harus diantara 3 sampai 100 karakter !!!")]
      [Display(Name = "Nama")]
      public string nama { get; set; }

      [DefaultValue("")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [Display(Name = "Keterangan")]
      public string keterangan { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<ISubTipeModel> SubTipes
      {
         get;
         set;
      }

      public TipeModel()
      {
         SubTipes = new List<ISubTipeModel>();
      }
   }
}
