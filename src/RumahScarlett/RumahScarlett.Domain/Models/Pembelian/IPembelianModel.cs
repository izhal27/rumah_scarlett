using System;
using RumahScarlett.Domain.Models.Supplier;
using System.Collections.Generic;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianModel
   {
      uint id { get; set; }
      DateTime tanggal { get; set; }
      string no_nota { get; set; }
      ISupplierModel Supplier { get; set; }
      uint supplier_id { get; set; }
      string supplier_nama { get; }
      decimal sub_total { get; }
      decimal diskon { get; set; }
      decimal grand_total { get; }
      IEnumerable<IPembelianDetailModel> PembelianDetails { get; set; }
   }
}