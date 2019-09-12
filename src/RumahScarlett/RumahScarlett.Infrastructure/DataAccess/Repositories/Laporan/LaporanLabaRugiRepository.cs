using Dapper;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Services.Services.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan
{
   public class LaporanLabaRugiRepository : ILaporanLabaRugiRepository
   {
      public ILabaRugiModel GetByMonthYear(object month, object year)
      {
         using (var context = new DbContext())
         {
            var queryStr = "";

            var model = context.Conn.Query<LabaRugiModel>(queryStr, new { month, year }).FirstOrDefault();

            return model;
         }
      }
   }
}
