using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public class LaporanLabaRugiServices : ILaporanLabaRugiServices
   {
      private ILaporanLabaRugiRepository _repo;

      public LaporanLabaRugiServices(ILaporanLabaRugiRepository repo)
      {
         _repo = repo;
      }

      public ILabaRugiModel GetByMonthYear(object month, object year)
      {
         return _repo.GetByMonthYear(month, year);
      }
   }
}
