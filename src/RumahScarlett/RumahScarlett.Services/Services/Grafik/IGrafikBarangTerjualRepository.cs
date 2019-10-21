using RumahScarlett.Domain.Models.Grafik;
using RumahScarlett.Services.Services.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Grafik
{
   public interface IGrafikBarangTerjualRepository
   {
      IEnumerable<IGrafikBarangTerjualModel> GetByMonthYear(MonthYear monthYear);
      IEnumerable<IGrafikBarangTerjualModel> GetByMonthYear(MonthYear startMonthYear, MonthYear endMonthYear);
   }
}
