using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Penjualan
{
   public interface IPenjualanReportModel : IPenjualanModel, IPenjualanDetailModel
   {
      new string barang_satuan { get; set; }
      new decimal kembali { get; set; }
   }
}
