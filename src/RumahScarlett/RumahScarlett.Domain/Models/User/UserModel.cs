﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dp = Dapper.Contrib.Extensions;

namespace RumahScarlett.Domain.Models.User
{
   [Table("user")]
   public class UserModel : IUserModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Login ID harus diisi !!!")]
      [StringLength(50, MinimumLength = 5, ErrorMessage = "Login ID harus diantara 5 sampai 50 karakter !!!")]
      [Display(Name = "Login ID")]
      public string login_id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Password harus diisi !!!")]
      [StringLength(50, MinimumLength = 5, ErrorMessage = "Password harus diantara 5 sampai 50 karakter !!!")]
      [RegularExpression("@^[a-zA-Z0-9_]+$", ErrorMessage = "Maaf, Hanya karakter Abjad, Huruf dan Underscore yang diijinkan untuk Login ID !!!")]
      [Display(Name = "Login ID")]
      public string password { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Role harus diisi !!!")]
      public string role_kode { get; set; }
   }
}