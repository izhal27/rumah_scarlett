using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.PenyesuainStok
{
   [Table("penyesuaian_stok")]
   public class PenyesuaianStok : IPenyesuaianStok
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "No Nota harus diisi !!!")]
      [StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [DisplayName("No Nota")]
      public string no_nota { get; set; }

      [Required(ErrorMessage = "Tanggal harus diisi !!!")]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<IPenyesuaianStokDetail> PenyesuaianStokDetails { get; set; }

      public PenyesuaianStok()
      {
         PenyesuaianStokDetails = new List<IPenyesuaianStokDetail>();
      }
   }
}
