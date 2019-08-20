using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pembelian
{
   [Table("pembelian")]
   public class Pembelian : IPembelian
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Supplier harus diisi !!!")]
      [DisplayName("Supplier ID")]
      public uint supplier_id { get; set; }

      [Dp.Write(false)]
      [DisplayName("Supplier")]
      public string supplier_nama { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama No Nota harus diisi !!!")]
      [StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [DisplayName("No Nota")]
      public string no_nota { get; set; }

      [Required(ErrorMessage = "Tanggal pembelian harus diisi !!!")]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<IPembelianDetail> PembelianDetails { get; set; }

      public Pembelian()
      {
         PembelianDetails = new List<IPembelianDetail>();
      }
   }
}
