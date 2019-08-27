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
using RumahScarlett.Domain.Models.PenyesuaianStok;

namespace RumahScarlett.Domain.Models.Barang
{
   [Table("barang")]
   public class BarangModel : IBarangModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Sub Tipe barang harus diisi !!!")]
      [DisplayName("Sub Tipe ID")]
      public uint sub_tipe_id { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Supplier barang harus diisi !!!")]
      [DisplayName("Supplier ID")]
      public uint supplier_id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Kode barang harus diisi !!!")]
      [StringLength(100, MinimumLength = 5, ErrorMessage = "Kode barang harus diantara 5 sampai 100 karakter !!!")]
      [RegularExpression(@"^[\w\d-]+$", ErrorMessage = "Format kode barang yang anda masukkan salah !!!")]
      [DisplayName("Kode")]
      public string kode { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama barang harus diisi !!!")]
      [StringLength(100, MinimumLength = 5, ErrorMessage = "Nama barang harus diantara 5 sampai 100 karakter !!!")]
      [DisplayName("Nama")]
      public string nama { get; set; }

      [DefaultValue(0)]
      [DisplayName("Stok")]
      public int stok { get; set; }

      [Dp.Write(false)]
      [DisplayName("Penyesuaian Stok")]
      public int penyesuaian_stok_qty
      {
         get
         {
            if (PenyesuaianStokDetails.ToList().Count > 0)
            {
               return PenyesuaianStokDetails.Cast<IPenyesuaianStokDetailModel>().Sum(pd => pd.qty);
            }

            return 0;
         }
      }

      [DefaultValue(0)]
      [DisplayName("HPP")]
      public decimal hpp { get; set; }

      [DefaultValue(0)]
      [DisplayName("Harga Jual")]
      public decimal harga_jual { get; set; }

      [DefaultValue(0)]
      [DisplayName("Harga Lama")]
      public decimal harga_lama { get; set; }

      [DefaultValue(0)]
      [DisplayName("Minimal Stok")]
      public int minimal_stok { get; set; }

      [Dp.Write(false)]
      [Browsable(false)]
      public IEnumerable<IPenyesuaianStokDetailModel> PenyesuaianStokDetails { get; set; }

      public BarangModel()
      {
         PenyesuaianStokDetails = new List<PenyesuaianStokDetailModel>();
      }
   }
}
