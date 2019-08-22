using System;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianModel
   {
      uint id { get; set; }
      uint supplier_id { get; set; }
      string supplier_nama { get; set; }
      string no_nota { get; set; }
      DateTime tanggal { get; set; }
      IEnumerable<IPembelianDetailModel> PembelianDetails { get; set; }
   }
}