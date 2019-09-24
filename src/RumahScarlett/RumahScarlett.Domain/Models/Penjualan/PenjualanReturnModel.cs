using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public class PenjualanReturnModel : IPenjualanReturnModel
   {
      public uint id { get; set; }
      public uint penjualan_id { get; set; }
      public IPenjualanModel Penjualan { get; set; }
      public int qty_return { get; set; }
      public decimal harga_jual { get; set; }
      public StatusReturn StatusReturn { get; set; }
      public decimal sub_total { get; }
      public string keterangan { get; }
   }
}
