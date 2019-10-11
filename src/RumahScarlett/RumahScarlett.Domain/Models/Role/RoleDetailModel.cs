using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dp = Dapper.Contrib.Extensions;

namespace RumahScarlett.Domain.Models.Role
{
   [Table("role_detail")]
   public class RoleDetailModel : IRoleDetailModel
   {
      [Required(AllowEmptyStrings = false, ErrorMessage = "Kode Role harus diisi !!!")]
      public string role_kode { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Menu Name harus diisi !!!")]
      public string menu_name { get; set; }

      public string menu_parent { get; set; }

      public string form_action { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Tag harus diisi !!!")]
      public string tag { get; set; }
   }
}
