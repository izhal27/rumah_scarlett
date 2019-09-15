using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Domain.Models.Pembelian
{
   public interface IPembelianReportModel : IPembelianModel, IPembelianDetailModel
   {
      new string supplier_nama { get; set; }
   }
}
