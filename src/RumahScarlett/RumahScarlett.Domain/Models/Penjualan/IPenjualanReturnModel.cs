using RumahScarlett.Domain.Models.Barang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanReturnModel
   {
      uint id { get; set; }
      IPenjualanModel Penjualan { get; set; }
      uint penjualan_id { get; }
      IBarangModel Barang { get; set; }
      uint barang_id { get; }
      string barang_kode { get; }
      string barang_nama { get; }
      int qty { get; set; }
      decimal harga_jual { get; set; }
      int status { get; set; }
      decimal sub_total { get; }
      string keterangan { get; }
   }
}
