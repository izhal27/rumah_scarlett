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

namespace RumahScarlett.Domain.Models.PenyesuaianStok
{
   [Table("penyesuaian_stok_detail")]
   public class PenyesuaianStokDetailModel : IPenyesuaianStokDetailModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Required(ErrorMessage = "Penyesuaian stok ID harus diisi !!!")]
      [DisplayName("Penyesuaian Stok ID")]
      public uint penyesuaian_stok_id { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IBarangModel Barang { get; set; }

      private uint _barang_id;

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Barang ID harus diisi !!!")]
      [DisplayName("Barang ID")]
      public uint barang_id
      {
         get { return Barang.id != default(uint) ? Barang.id : _barang_id; }
         set { _barang_id = value; }
      }

      [Dp.Write(false)]
      [DisplayName("Kode Barang")]
      public string barang_kode { get { return Barang != null ? Barang.kode : string.Empty; } }

      [Dp.Write(false)]
      [DisplayName("Nama Barang")]
      public string barang_nama { get { return Barang != null ? Barang.nama : string.Empty; } }

      [Range(1, uint.MaxValue, ErrorMessage = "Qty harus diisi !!!")]
      [DisplayName("Qty")]
      public int qty { get; set; }

      [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "HPP harus diisi !!!")]
      [DisplayName("HPP")]
      public decimal hpp
      {
         get { return Barang.id != default(uint) ? Barang.hpp : default(uint); }
      }

      [Required(ErrorMessage = "Keterangan harus diisi !!!")]
      [StringLength(255, ErrorMessage = "Panjang maksimal keterangan 255 karakter !!!")]
      [DisplayName("Keterangan")]
      public string keterangan { get; set; }

      public PenyesuaianStokDetailModel()
      {
         Barang = new BarangModel();
      }
   }
}
