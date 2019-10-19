using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public interface IStatusPerBarangServices
   {
      IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear monthYear);
      IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear startMonthYear, MonthYear endMonthYear);
   }

   public class MonthYear
   {
      public object Month { get; private set; }
      public object Year { get; private set; }

      public MonthYear(object month, object year)
      {
         Month = month;
         Year = year;
      }
   }
}
