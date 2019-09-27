using RumahScarlett.Domain.Helper;
using RumahScarlett.Domain.Models.Barang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public class PenjualanReturnReportModel : IPenjualanReturnReportModel
   {
      public uint id { get; set; }

      public uint penjualan_return_id { get; set; }

      public DateTime tanggal { get; set; }

      public string no_nota { get; set; }

      public IBarangModel Barang { get; set; }

      public uint barang_id { get; set; }

      public string barang_kode { get; set; }

      public string barang_nama { get; set; }

      public IPenjualanModel Penjualan { get; set; }

      public uint penjualan_id { get; set; }

      public int qty { get; set; }

      public string satuan_nama { get; set; }

      public decimal hpp { get; set; }

      public decimal harga_jual { get; set; }

      public decimal sub_total
      {
         get { return qty > 0 ? (qty * harga_jual) : 0; }
      }

      public int status { get; set; }

      public string status_nama
      {
         get { return DataSourceHelper.StatusReturn.Where(sr => (int)sr.Key == status).FirstOrDefault().Value; }
      }

      public string keterangan { get; set; }

      public IEnumerable<IPenjualanReturnDetailModel> PenjualanReturnDetails { get; set; }
   }
}
