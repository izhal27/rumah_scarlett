using RumahScarlett.Domain.Helper;
using RumahScarlett.Domain.Models.Barang;
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
   [Table("penjualan_return")]
   public class PenjualanReturnModel : IPenjualanReturnModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Dp.Write(false)]
      public IPenjualanModel Penjualan { get; set; }

      [Dp.Write(false)]
      [Browsable(false)]
      [Display(Name = "Penjualan ID")]
      public uint penjualan_id
      {
         get { return Penjualan.id != default(uint) ? Penjualan.id : default(uint); }
      }

      [Dp.Write(false)]
      [Display(Name = "Barang")]
      public IBarangModel Barang { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Kode Barang")]
      public string barang_kode
      {
         get { return Barang.id != default(uint) ? Barang.kode : string.Empty; }
      }

      [Dp.Write(false)]
      [Display(Name = "Nama Barang")]
      public string barang_nama
      {
         get { return Barang.id != default(uint) ? Barang.nama : string.Empty; }
      }

      [Display(Name = "Qty Return")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      public int qty_return { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Harga jual")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      public decimal harga_jual { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Sub Total")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      public decimal sub_total
      {
         get { return qty_return > 0 ? (qty_return * harga_jual) : 0; }
      }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Status return harus diisi !!!")]
      public int status_return { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Status Return")]
      public string status_return_nama
      {
         get { return DataSourceHelper.StatusReturn.Where(sr => sr.Key == status_return).FirstOrDefault().Value; }
      }

      [Display(Name = "Keterangan")]
      public string keterangan { get; }

      public PenjualanReturnModel()
      {
         Penjualan = new PenjualanModel();
         Barang = new BarangModel();
      }
   }
}
