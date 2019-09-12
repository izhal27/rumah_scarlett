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
      [Display(Name = "Stok Awal")]
      public int stok_awal
      {
         get
         {
            var temp = (stok_akhir + total_stok_keluar) - stok_masuk;

            if (temp < 0)
            {
               temp = temp * -1;
               stok_keluar += temp;

               return 0;
            }
            else
            {
               return temp;
            }

         }
      }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Total Stok Masuk")]
      public int stok_masuk { get; set; }

      [Browsable(false)]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Stok Keluar")]
      public int stok_keluar { get; set; }

      [Browsable(false)]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Total Penyesuaian Stok")]
      public int penyesuaian_stok { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Total Stok Keluar")]
      public int total_stok_keluar
      {
         get { return (stok_keluar + penyesuaian_stok); }
      }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Stok Akhir")]
      public int stok_akhir { get; set; }
   }
}
