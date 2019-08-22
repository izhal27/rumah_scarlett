﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.KasAwal
{
   [Table("kas_awal")]
   public class KasAwalModel : IKasAwalModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Required]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [DefaultValue(0)]
      [DisplayName("Total")]
      public decimal total { get; set; }

      public KasAwalModel()
      {
         tanggal = DateTime.Now;
      }
   }
}