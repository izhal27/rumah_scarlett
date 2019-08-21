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
      [DisplayName("ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama tipe harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama tipe harus diantara 3 sampai 100 karakter !!!")]
      [DisplayName("Nama")]
      public string nama { get; set; }

      [DefaultValue("")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [DisplayName("Keterangan")]
      public string keterangan { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<ISubTipeModel> SubTipeModels
      {
         get;
         set;
      }

      public TipeModel()
      {
         SubTipeModels = new List<ISubTipeModel>();
      }
   }
}
