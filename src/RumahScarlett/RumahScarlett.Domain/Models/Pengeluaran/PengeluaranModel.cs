using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pengeluaran
{
   [Table("pengeluaran")]
   public class PengeluaranModel : IPengeluaranModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }
      
      [Browsable(false)]
      [Range(typeof(DateTime), "1945/08/17", "9999/01/01", ErrorMessage = "Minimal Tanggal 1945/08/17 !!!")]
      [Display(Name = "Tanggal")]
      public DateTime tanggal { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama pengeluaran harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama pengeluaran harus diantara 3 sampai 100 karakter !!!")]
      [Display(Name = "Nama")]
      public string nama { get; set; }
      
      [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Jumlah harus diisi !!!")]
      [Display(Name = "Jumlah")]
      public decimal jumlah { get; set; }

      [DefaultValue("")]
      [Display(Name = "Keterangan")]
      public string keterangan { get; set; }
   }
}
