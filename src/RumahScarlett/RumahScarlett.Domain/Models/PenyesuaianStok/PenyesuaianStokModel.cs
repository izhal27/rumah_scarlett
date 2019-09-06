using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Satuan;

namespace RumahScarlett.Domain.Models.PenyesuaianStok
{
   [Table("penyesuaian_stok")]
   public class PenyesuaianStokModel : IPenyesuaianStokModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Range(typeof(DateTime), "1945/08/17", "9999/01/01", ErrorMessage = "Minimal Tanggal 1945/08/17 !!!")]
      [Display(Name = "Tanggal")]
      public DateTime tanggal { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IBarangModel Barang { get; set; }

      private uint _barang_id;

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Barang harus diisi !!!")]
      [Display(Name = "Barang ID")]
      public uint barang_id
      {
         get { return Barang.id != default(uint) ? Barang.id : _barang_id; }
         set { _barang_id = value; }
      }

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

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Range(1, int.MaxValue, ErrorMessage = "Qty harus diisi !!!")]
      [Display(Name = "Qty")]
      public int qty { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public ISatuanModel Satuan { get; set; }

      private uint _satuan_id;

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Satuan harus diisi !!!")]
      [Display(Name = "Satuan ID")]
      public uint satuan_id
      {
         get { return Satuan.id != default(uint) ? Satuan.id : _satuan_id; }
         set { _satuan_id = value; }
      }

      [Dp.Write(false)]
      [Display(Name = "Satuan")]
      public string satuan_nama
      {
         get { return Satuan.id != default(uint) ? Satuan.nama : string.Empty; }
      }
      
      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Display(Name = "HPP")]
      public decimal hpp { get; set; }

      [Required(ErrorMessage = "Keterangan harus diisi !!!")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [Display(Name = "Keterangan")]
      public string keterangan { get; set; }

      public PenyesuaianStokModel()
      {
         Barang = new BarangModel();
         Satuan = new SatuanModel();
      }
   }
}
