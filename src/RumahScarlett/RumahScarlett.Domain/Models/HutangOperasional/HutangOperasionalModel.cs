using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.HutangOperasional
{
   [Table("hutang_operasional")]
   public class HutangOperasionalModel : IHutangOperasionalModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Range(typeof(DateTime), "1945/08/17", "9999/01/01", ErrorMessage = "Minimal Tanggal 1945/08/17 !!!")]
      [Display(Name = "Tanggal")]
      public DateTime tanggal { get; set; }

      [Display(Name = "Jumlah")]
      public decimal jumlah { get; set; }

      [Display(Name = "Keterangan")]
      public string keterangan { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Status Hutang")]
      public string status_hutang_nama
      {
         get { return status_hutang ? "Lunas" : "Belum Lunas"; }
      }

      [DefaultValue(0)]
      [Browsable(false)]
      [Display(Name = "Status Hutang")]
      public bool status_hutang { get; set; }
   }
}
