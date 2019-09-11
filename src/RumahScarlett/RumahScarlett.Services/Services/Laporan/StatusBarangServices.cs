using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public class StatusBarangServices : IStatusBarangServices
   {
      private IStatusBarangRepository _repo;

      public StatusBarangServices(IStatusBarangRepository repo)
      {
         _repo = repo;
      }

      public IStatusBarangModel GetByDate(object date)
      {
         return _repo.GetByDate(date);
      }      
   }
}
