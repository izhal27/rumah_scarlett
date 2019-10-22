using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Grafik;
using RumahScarlett.Services.Services.Laporan;

namespace RumahScarlett.Services.Services.Grafik
{
   public class GrafikBarangTerjualServices : IGrafikBarangTerjualServices
   {
      private IGrafikBarangTerjualRepository _repo;

      public GrafikBarangTerjualServices(IGrafikBarangTerjualRepository repo)
      {
         _repo = repo;
      }

      public IEnumerable<IGrafikBarangTerjualModel> GetByMonthYear(object month, object year)
      {
         return _repo.GetByMonthYear(month, year);
      }
      
   }
}
