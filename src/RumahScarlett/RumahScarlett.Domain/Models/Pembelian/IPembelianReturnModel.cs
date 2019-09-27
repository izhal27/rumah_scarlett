using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianReturnModel
   {
      uint id { get; set; }
      DateTime tanggal { get; set; }
      string no_nota { get; set; }
      IPembelianModel Pembelian { get; set; }
      uint pembelian_id { get; set; }
      IEnumerable<IPembelianReturnDetailModel> PembelianReturnDetails { get; set; }
   }
}
