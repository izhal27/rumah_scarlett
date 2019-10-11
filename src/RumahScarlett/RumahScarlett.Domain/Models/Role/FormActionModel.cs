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
   [Table("form_action")]
   public class FormActionModel : IFormActionModel
   {
      [Required(AllowEmptyStrings = false, ErrorMessage = "Form Name harus diisi !!!")]
      public string form_name { get; set; }

      public string form_text { get; set; }

      public string act_1 { get; set; }

      public string act_2 { get; set; }

      public string act_3 { get; set; }

      public string act_4 { get; set; }

      public string act_5 { get; set; }

      public string act_6 { get; set; }

      public string act_7 { get; set; }

      public string act_8 { get; set; }

      public string act_9 { get; set; }

      public string act_10 { get; set; }

      public string act_11 { get; set; }

      public string act_12 { get; set; }

      public string act_13 { get; set; }

      public string act_14 { get; set; }

      public string act_15 { get; set; }
   }
}
