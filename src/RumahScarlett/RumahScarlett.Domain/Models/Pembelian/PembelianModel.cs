using Dp = Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Supplier;

namespace RumahScarlett.Domain.Models.Pembelian
{
   [Table("pembelian")]
   public class PembelianModel : IPembelianModel
   {
      [Browsable(false)]
      [DisplayName("ID")]
      public uint id { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public SupplierModel Supplier { get; set; }

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Supplier ID harus diisi !!!")]
      [DisplayName("Supplier ID")]
      public uint supplier_id { get { return Supplier.id; } }

      [Dp.Write(false)]
      [DisplayName("Supplier")]
      public string supplier_nama { get { return Supplier.nama; } }

      [Required(AllowEmptyStrings = false, ErrorMessage = "No Nota harus diisi !!!")]
      [StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [DisplayName("No Nota")]
      public string no_nota { get; set; }

      [Required(ErrorMessage = "Tanggal harus diisi !!!")]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [MinLength(1, ErrorMessage = "Data barang harus diisi !!!")]
      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<IPembelianDetailModel> PembelianDetails { get; set; }

      public PembelianModel()
      {
         PembelianDetails = new List<IPembelianDetailModel>();
      }
   }
}
