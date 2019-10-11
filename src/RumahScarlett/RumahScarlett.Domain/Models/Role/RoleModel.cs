﻿using System;
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
   [Table("role")]
   public class RoleModel : IRoleModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Kode harus diisi !!!")]
      [StringLength(50, MinimumLength = 3, ErrorMessage = "Kode harus diantara 3 sampai 50 karakter !!!")]
      [Display(Name = "Kode")]
      public string kode { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama harus diisi !!!")]
      [StringLength(50, MinimumLength = 5, ErrorMessage = "Nama harus diantara 5 sampai 50 karakter !!!")]
      [Display(Name = "Nama")]
      public string nama { get; set; }

      [Display(Name = "Keterangan")]
      public string keterangan { get; set; }
   }
}
