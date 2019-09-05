using RumahScarlett.Domain.Models.PenyesuaianStok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dp = Dapper.Contrib.Extensions;

namespace RumahScarlett.Domain.Models.Barang
{
   [Table("barang")]
   public class BarangModel : IBarangModel
   {
      [Browsable(false)]
      [Display(Name = "ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Tipe barang harus diisi !!!")]
      [Display(Name = "Tipe ID")]
      public uint tipe_id { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Sub Tipe barang harus diisi !!!")]
      [Display(Name = "Sub Tipe ID")]
      public uint sub_tipe_id { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Supplier barang harus diisi !!!")]
      [Display(Name = "Supplier ID")]
      public uint supplier_id { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Satuan barang harus diisi !!!")]
      [Display(Name = "Satuan ID")]
      public uint satuan_id { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Kode barang harus diisi !!!")]
      [StringLength(100, MinimumLength = 5, ErrorMessage = "Kode barang harus diantara 5 sampai 100 karakter !!!")]
      [RegularExpression(@"^[\w\d-]+$", ErrorMessage = "Format kode barang yang anda masukkan salah !!!")]
      [Display(Name = "Kode")]
      public string kode { get; set; }

      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama barang harus diisi !!!")]
      [StringLength(100, MinimumLength = 5, ErrorMessage = "Nama barang harus diantara 5 sampai 100 karakter !!!")]
      [Display(Name = "Nama")]
      public string nama { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [DefaultValue(0)]
      [Display(Name = "Stok")]
      public int stok { get; set; }

      [Dp.Write(false)]
      [Display(Name = "Satuan")]
      public string satuan_nama { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [DefaultValue(0)]
      [Display(Name = "HPP")]
      public decimal hpp { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [DefaultValue(0)]
      [Display(Name = "Harga Jual")]
      public decimal harga_jual { get; set; }
      
      [Browsable(false)]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      [DefaultValue(0)]
      [Display(Name = "Harga Lama")]
      public decimal harga_lama { get; set; }
      
      [DisplayFormat(DataFormatString = "{0:N0}")]
      [DefaultValue(0)]
      [Display(Name = "Minimal Stok")]
      public int minimal_stok { get; set; }

      [DisplayFormat(DataFormatString = "{0:N0}")]
      [Dp.Write(false)]
      [Display(Name = "Penyesuaian Stok")]
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

      [Dp.Write(false)]
      [Browsable(false)]
      public IEnumerable<IPenyesuaianStokDetailModel> PenyesuaianStokDetails { get; set; }

      public BarangModel()
      {
         PenyesuaianStokDetails = new List<PenyesuaianStokDetailModel>();
      }
   }
}
