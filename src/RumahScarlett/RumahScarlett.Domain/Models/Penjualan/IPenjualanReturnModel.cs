using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanReturnModel
   {
      uint id { get; set; }
      uint penjualan_id { get; set; }
      IPenjualanModel Penjualan { get; set; }
      int qty_return { get; set; }
      decimal harga_jual { get; set; }
      StatusReturn StatusReturn { get; set; }
      decimal sub_total { get; }
      string keterangan { get; }
   }

   public enum StatusReturn
   {
      [Description("Barang Rusak atau Cacat")]
      Rusak = 1,
      [Description("Barang salah")]
      BarangSalah,
      [Description("Qty lebih")]
      QtyLebih
   }
}
