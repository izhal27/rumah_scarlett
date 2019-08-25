﻿using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.PenyesuaianStok
{
   [Table("penyesuaian_stok")]
   public class PenyesuaianStokModel : IPenyesuaianStokModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }
      
      [StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [DisplayName("No Nota")]
      public string no_nota { get; set; }
      
      [Range(typeof(DateTime), "1945/08/17", "9999/01/01", ErrorMessage = "Minimal Tanggal 1945/08/17 !!!")]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<IPenyesuaianStokDetailModel> PenyesuaianStokDetails { get; set; }

      public PenyesuaianStokModel()
      {
         PenyesuaianStokDetails = new List<IPenyesuaianStokDetailModel>();
      }
   }
}