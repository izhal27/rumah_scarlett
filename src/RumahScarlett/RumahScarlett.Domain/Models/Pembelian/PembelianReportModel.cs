using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public class PembelianReportModel : IPembelianReportModel
   {
      public uint id { get; set; }

      public uint pembelian_id { get; set; }

      public DateTime tanggal { get; set; }

      public string no_nota { get; set; }

      public ISupplierModel Supplier { get; set; }

      public uint supplier_id { get; set; }

      public string supplier_nama { get; set; }

      public IBarangModel Barang { get; set; }

      public uint barang_id { get; set; }

      public string barang_kode { get; set; }

      public string barang_nama { get; set; }

      public int qty { get; set; }
      public int qty_return { get; set; }

      public string barang_satuan { get; set; }

      public decimal hpp { get; set; }

      public decimal sub_total
      {
         get { return qty > 0M ? decimal.Parse((qty * hpp).ToString()) : 0M; }
      }

      public decimal diskon { get; set; }

      public decimal total { get; }

      public decimal grand_total { get; }

      public IEnumerable<IPembelianDetailModel> PembelianDetails { get; set; }      
   }
}
