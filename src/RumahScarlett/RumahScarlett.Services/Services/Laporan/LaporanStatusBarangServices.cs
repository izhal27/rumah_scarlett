using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public class LaporanStatusBarangServices : ILaporanStatusBarangServices
   {
      private ILaporanStatusBarangRepository _repo;

      public LaporanStatusBarangServices(ILaporanStatusBarangRepository repo)
      {
         _repo = repo;
      }

      public IEnumerable<ILaporanStatusBarangModel> GetByDate(object date)
      {
         return _repo.GetByDate(date);
      }

      public IEnumerable<ILaporanStatusBarangModel> GetByDate(object startDate, object endDate)
      {
         return _repo.GetByDate(startDate, endDate);
      }
   }
}
