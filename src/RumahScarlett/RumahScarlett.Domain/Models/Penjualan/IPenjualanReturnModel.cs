using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanReturnModel
   {
      uint id { get; set; }
      DateTime tanggal { get; set; }
      string no_nota { get; set; }
      IPenjualanModel Penjualan { get; set; }
      uint penjualan_id { get; set; }
      IEnumerable<IPenjualanReturnDetailModel> PenjualanReturnDetails { get; set; }
   }
}
