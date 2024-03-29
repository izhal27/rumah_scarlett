﻿using RumahScarlett.Domain.Models.Pelanggan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dp = Dapper.Contrib.Extensions;

namespace RumahScarlett.Domain.Models.Penjualan
{
   [Table("penjualan")]
   public class PenjualanModel : IPenjualanModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      //[Range(typeof(DateTime), "1945/08/17", "9999/01/01", ErrorMessage = "Minimal Tanggal 1945/08/17 !!!")]
      [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm")]
      [Display(Name = "Tanggal")]
      public DateTime tanggal { get; set; }

      //[StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [Display(Name = "No Nota")]
      public string no_nota { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IPelangganModel Pelanggan { get; set; }

      private uint _pelanggan_id;

      [Browsable(false)]
      [Display(Name = "Pelanggan ID")]
      public uint pelanggan_id
      {
         get { return Pelanggan.id != default(uint) ? Pelanggan.id : _pelanggan_id; }
         set { _pelanggan_id = value; }
      }

      [Dp.Write(false)]
      [Display(Name = "Pelanggan")]
      public string pelanggan_nama
      {
         get { return Pelanggan.id != default(uint) ? Pelanggan.nama : string.Empty; }
      }

      [Dp.Write(false)]
      [Display(Name = "Pembayaran")]
      public string status_pembayaran_nama
      {
         get { return status_pembayaran ? "Cash" : "Transfer"; }
      }

      [Browsable(false)]
      [DefaultValue(0)]
      public bool status_pembayaran { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Dp.Write(false)]
      [Display(Name = "Sub Total")]
      public decimal sub_total
      {
         get
         {
            if (PenjualanDetails.ToList().Count > 0)
            {
               return PenjualanDetails.Cast<PenjualanDetailModel>().Sum(pd => pd.total);
            }

            return 0;
         }
      }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [DefaultValue(0)]
      [Display(Name = "Diskon")]
      public decimal diskon { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Dp.Write(false)]
      [Display(Name = "Grand Total")]
      public decimal grand_total
      {
         get { return (sub_total - diskon) >= 0 ? (sub_total - diskon) : 0; }
      }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [DefaultValue(0)]
      [Display(Name = "Jumlah Bayar")]
      public decimal jumlah_bayar { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Kembali")]
      public decimal kembali
      {
         get
         {
            var uangKembali = jumlah_bayar - grand_total;
            return uangKembali > 0 ? uangKembali : 0M;
         }
      }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<IPenjualanDetailModel> PenjualanDetails { get; set; }

      public PenjualanModel()
      {
         Pelanggan = new PelangganModel();
         PenjualanDetails = new List<PenjualanDetailModel>();
      }
   }
}
