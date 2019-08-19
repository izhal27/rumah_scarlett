using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   [Table("penjualan")]
   public class Penjualan : IPenjualan
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public int id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "No Nota harus diisi !!!")]
      [StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [DisplayName("No Nota")]
      public string no_nota { get; set; }

      [Required(ErrorMessage = "Tanggal penjualan harus diisi !!!")]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [DefaultValue(0)]
      [DisplayName("Diskon")]
      public decimal diskon { get; set; }

      public IEnumerable<PenjualanDetail> PenjualanDetails { get; set; }

      public Penjualan()
      {
         PenjualanDetails = new List<PenjualanDetail>();
      }
   }
}
