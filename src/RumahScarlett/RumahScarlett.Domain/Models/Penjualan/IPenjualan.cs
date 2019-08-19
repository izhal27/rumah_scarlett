using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualan
   {
      int id { get; set; }
      string no_nota { get; set; }
      DateTime tanggal { get; set; }
      decimal diskon { get; set; }
      IEnumerable<PenjualanDetail> IPenjualanDetails { get; set; }
   }
}