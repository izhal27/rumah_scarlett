using RumahScarlett.Domain.Models.Barang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianReturnDetailModel
   {
      uint id { get; set; }
      uint pembelian_return_id { get; set; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; set; }
      string barang_kode { get; }
      string barang_nama { get; }
      int qty { get; set; }
      string satuan_nama { get; }
      decimal hpp { get; set; }
      int status { get; set; }
      string status_nama { get; }
      decimal sub_total { get; }
      string keterangan { get; set; }
   }
}
