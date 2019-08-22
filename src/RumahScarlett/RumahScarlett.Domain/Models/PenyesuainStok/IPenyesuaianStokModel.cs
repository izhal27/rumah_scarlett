using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.PenyesuainStok
{
   public interface IPenyesuaianStokModel
   {
      uint id { get; set; }
      string no_nota { get; set; }
      DateTime tanggal { get; set; }
      IEnumerable<IPenyesuaianStokDetailModel> PenyesuaianStokDetails { get; set; }
   }
}