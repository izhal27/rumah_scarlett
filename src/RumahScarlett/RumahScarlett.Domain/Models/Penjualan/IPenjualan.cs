using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualan
   {
      uint id { get; set; }
      string no_nota { get; set; }
      DateTime tanggal { get; set; }
      decimal diskon { get; set; }
      IEnumerable<IPenjualanDetail> PenjualanDetails { get; set; }
   }
}