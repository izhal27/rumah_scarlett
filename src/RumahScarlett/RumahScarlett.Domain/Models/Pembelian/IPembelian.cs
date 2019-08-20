using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelian
   {
      uint id { get; set; }
      uint supplier_id { get; set; }
      string supplier_nama { get; set; }
      string no_nota { get; set; }
      DateTime tanggal { get; set; }
      IEnumerable<IPembelianDetail> PembelianDetails { get; set; }
   }
}