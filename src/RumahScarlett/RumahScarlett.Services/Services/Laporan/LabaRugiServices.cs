using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public class LabaRugiServices : ILabaRugiServices
   {
      private ILabaRugiRepository _repo;

      public LabaRugiServices(ILabaRugiRepository repo)
      {
         _repo = repo;
      }

      public ILabaRugiModel GetByMonthYear(object month, object year)
      {
         return _repo.GetByMonthYear(month, year);
      }
   }
}
