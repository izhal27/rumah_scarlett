using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanModel
   {
      uint id { get; set; }
      string no_nota { get; set; }
      DateTime tanggal { get; set; }
      decimal diskon { get; set; }
      IEnumerable<IPenjualanDetailModel> PenjualanDetails { get; set; }
   }
}