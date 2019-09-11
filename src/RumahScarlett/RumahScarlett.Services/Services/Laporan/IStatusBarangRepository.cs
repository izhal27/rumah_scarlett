using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public interface IStatusBarangRepository
   {
      IStatusBarangModel GetByDate(object date);
   }
}
