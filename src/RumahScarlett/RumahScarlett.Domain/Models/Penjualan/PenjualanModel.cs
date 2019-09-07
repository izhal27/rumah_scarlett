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
   public class PenjualanModel : IPenjualanModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      //[StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [Display(Name = "No Nota")]
      public string no_nota { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Status Pembayaran")]
      public string status_pembayaran_nama
      {
         get { return !status_pembayaran ? "Cash" : "Transfer"; }
      }

      [Browsable(false)]
      [DefaultValue(0)]
      public bool status_pembayaran { get; set; }

      [Browsable(false)]
      [Display(Name = "Pelanggan ID")]
      public uint pelanggan_id { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Pelanggan")]
      public string pelanggan_nama { get; set; }

      //[Range(typeof(DateTime), "1945/08/17", "9999/01/01", ErrorMessage = "Minimal Tanggal 1945/08/17 !!!")]
      [Display(Name = "Tanggal")]
      public DateTime tanggal { get; set; }

      [DefaultValue(0)]
      [Display(Name = "Diskon")]
      public decimal diskon { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<IPenjualanDetailModel> PenjualanDetails { get; set; }

      public PenjualanModel()
      {
         PenjualanDetails = new List<PenjualanDetailModel>();
      }
   }
}
