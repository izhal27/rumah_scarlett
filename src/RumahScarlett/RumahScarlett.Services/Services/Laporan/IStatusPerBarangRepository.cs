using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public interface IStatusPerBarangRepository
   {
      IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear monthYear);
      IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear startMonthYear, MonthYear endMonthYear);
   }
}
