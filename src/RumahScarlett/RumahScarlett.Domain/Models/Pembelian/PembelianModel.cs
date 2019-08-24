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
      public ISupplierModel Supplier { get; set; }

      private uint _supplier_id;

      [Browsable(false)]
      [Range(1, uint.MaxValue, ErrorMessage = "Supplier ID harus diisi !!!")]
      [DisplayName("Supplier ID")]
      public uint supplier_id
      {
         get { return Supplier.id != default(uint) ? Supplier.id : _supplier_id; }
         set { _supplier_id = value; }
      }

      [Dp.Write(false)]
      [DisplayName("Supplier")]
      public string supplier_nama { get { return Supplier != null ? Supplier.nama : string.Empty; } }

      [StringLength(255, ErrorMessage = "Panjang maksimal No Nota 255 karakter !!!")]
      [DisplayName("No Nota")]
      public string no_nota { get; set; }

      [Required(ErrorMessage = "Tanggal harus diisi !!!")]
      [Range(typeof(DateTime), "1945/08/17", "9999/01/01", ErrorMessage = "Minimal Tanggal 1945/08/17 !!!")]
      [DisplayName("Tanggal")]
      public DateTime tanggal { get; set; }

      [Browsable(false)]
      [Dp.Write(false)]
      public IEnumerable<IPembelianDetailModel> PembelianDetails { get; set; }

      public PembelianModel()
      {
         Supplier = new SupplierModel();
         PembelianDetails = new List<IPembelianDetailModel>();
      }
   }
}
