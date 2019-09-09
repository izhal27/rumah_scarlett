using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Domain.Models.Penjualan
{
   [Table("penjualan_detail")]
   public class PenjualanDetailModel : IPenjualanDetailModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Penjualan ID harus diisi !!!")]
      [Display(Name = "Penjualan ID")]
      public uint penjualan_id { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IBarangModel Barang { get; set; }

      private uint _barang_id;

      [Browsable(false)]
      [Required(ErrorMessage = "Barang harus diisi !!!")]
      [Display(Name = "Barang ID")]
      public uint barang_id
      {
         get { return Barang.id != default(uint) ? Barang.id : _barang_id; }
         set { _barang_id = value; }
      }

      private string _barang_kode;

      [Dp.Write(false)]
      [Display(Name = "Kode Barang")]
      public string barang_kode
      {
         get { return Barang.id != default(uint) ? Barang.kode : _barang_kode; }
         set { _barang_kode = value; }
      }

      private string _barang_nama;

      [Dp.Write(false)]
      [Display(Name = "Nama Barang")]
      public string barang_nama
      {
         get { return Barang.id != default(uint) ? Barang.nama : _barang_nama; }
         set { _barang_nama = value; }
      }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Range(1, int.MaxValue, ErrorMessage = "Qty harus diisi !!!")]
      [Display(Name = "Qty")]
      public int qty { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Satuan")]
      public string barang_satuan
      {
         get { return Barang.id != default(uint) ? Barang.satuan_nama : string.Empty; }
      }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "Harga Jual")]
      public decimal harga_jual { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Dp.Write(false)]
      [Display(Name = "Total")]
      public decimal total
      {
         get { return qty > 0M ? decimal.Parse((qty * harga_jual).ToString()) : 0M; }
      }

      public PenjualanDetailModel()
      {
         Barang = new BarangModel();
      }
   }
}
