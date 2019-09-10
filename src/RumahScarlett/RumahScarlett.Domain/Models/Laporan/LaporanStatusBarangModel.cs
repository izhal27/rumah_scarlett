using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Laporan
{
   public class LaporanStatusBarangModel : ILaporanStatusBarangModel
   {
      [Browsable(false)]
      [Display(Name = "ID Barang")]
      public uint id { get; set; }
      
      [Display(Name = "Kode Barang")]
      public string barang_kode { get; set; }

      [Display(Name = "Nama Barang")]
      public string barang_nama { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Stok Masuk")]
      public int stok_masuk { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Stok Keluar")]
      public int stok_keluar { get; set; }
   }
}
