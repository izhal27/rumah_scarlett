using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pengeluaran
{
   [Table("pengeluaran")]
   public class Pengeluaran
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }
      
      [Browsable(false)]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama pengeluaran harus diisi !!!")]
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Nama pengeluaran harus diantara 3 sampai 100 karakter !!!")]
      [DisplayName("Nama")]
      public string nama { get; set; }
      public decimal jumlah { get; set; }
      public string keterangan { get; set; }
   }
}
