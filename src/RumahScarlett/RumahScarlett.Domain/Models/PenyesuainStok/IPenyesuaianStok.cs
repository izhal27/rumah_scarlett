using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.PenyesuainStok
{
   public interface IPenyesuaianStok
   {
      uint id { get; set; }
      string no_nota { get; set; }
      DateTime tanggal { get; set; }
      IEnumerable<IPenyesuaianStokDetail> PenyesuaianStokDetails { get; set; }
   }
}