using RumahScarlett.Domain.Models.Barang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanReturnDetailModel
   {
      uint id { get; set; }
      uint penjualan_return_id { get; set; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; set; }
      string barang_kode { get; }
      string barang_nama { get; }
      int qty { get; set; }
      string satuan_nama { get; }
      decimal hpp { get; set; }
      decimal harga_jual { get; set; }
      int status { get; set; }
      string status_nama { get; }
      decimal sub_total { get; }
      string keterangan { get; set; }
   }
}
