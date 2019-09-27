using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianReturnReportModel : IPembelianReturnModel, IPembelianReturnDetailModel
   {
      new string barang_kode { get; set; }
      new string barang_nama { get; set; }
      new string satuan_nama { get; set; }
   }
}
