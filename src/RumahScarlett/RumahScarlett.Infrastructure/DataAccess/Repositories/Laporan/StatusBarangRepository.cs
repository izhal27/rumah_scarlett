using Dapper;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Services.Services.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan
{
   public class StatusBarangRepository : IStatusBarangRepository
   {
      public IStatusBarangModel GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = "SELECT * FROM status_barang s WHERE DATE(tanggal) = @DATE ORDER BY id DESC LIMIT 1";

            return context.Conn.Query<StatusBarangModel>(queryStr, new { date }).FirstOrDefault();
         }
      }
   }
}
