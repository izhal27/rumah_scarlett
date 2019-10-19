using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public class StatusPerBarangServices : IStatusPerBarangServices
   {
      private IStatusPerBarangRepository _repo;

      public StatusPerBarangServices(IStatusPerBarangRepository repo)
      {
         _repo = repo;
      }

      public IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear monthYear)
      {
         return _repo.GetByMonthYear(monthYear);
      }

      public IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear startMonthYear, MonthYear endMonthYear)
      {
         return _repo.GetByMonthYear(startMonthYear, endMonthYear);
      }
   }
}
