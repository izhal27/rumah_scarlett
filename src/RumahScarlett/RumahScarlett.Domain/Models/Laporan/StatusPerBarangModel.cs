using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Laporan
{
   public class StatusPerBarangModel : IStatusPerBarangModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Display(Name = "Kode")]
      public string kode { get; set; }
      
      [Display(Name = "Nama")]
      public string nama { get; set; }

      [Display(Name = "Satuan")]
      public string satuan { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Stok Masuk")]
      public long stok_masuk { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Stok Keluar")]
      public long stok_keluar { get; set; }
   }
}
