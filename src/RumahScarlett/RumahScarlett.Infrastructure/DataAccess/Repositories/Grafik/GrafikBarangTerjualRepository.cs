using Dapper;
using RumahScarlett.Domain.Models.Grafik;
using RumahScarlett.Services.Services.Grafik;
using RumahScarlett.Services.Services.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Grafik
{
   public class GrafikBarangTerjualRepository : IGrafikBarangTerjualRepository
   {
      private static string _queryStr = "SELECT CONCAT(MONTH(pj.tanggal), '/', YEAR(pj.tanggal)) AS bulan_tanggal, " +
                                        "b.nama AS barang_nama, SUM(pjd.qty) AS stok_terjual FROM barang b " +
                                        "INNER JOIN penjualan_detail pjd ON b.id = pjd.barang_id " +
                                        "INNER JOIN penjualan pj ON pjd.penjualan_id = pj.id AND " +
                                        "({MonthYear}) " +
                                        "GROUP BY b.id, MONTH(pj.tanggal), YEAR(pj.tanggal) ORDER BY stok_terjual DESC LIMIT 10";

      public IEnumerable<IGrafikBarangTerjualModel> GetByMonthYear(MonthYear monthYear)
      {
         using (var context = new DbContext())
         {
            var queryStr = _queryStr.Replace("{MonthYear}", "MONTH(pj.tanggal) = @MONTH AND YEAR(pj.tanggal) = @year");
            return context.Conn.Query<GrafikBarangTerjualModel>(queryStr, new { monthYear.Month, monthYear.Year });
         }
      }

      public IEnumerable<IGrafikBarangTerjualModel> GetByMonthYear(MonthYear startMonthYear, MonthYear endMonthYear)
      {
         using (var context = new DbContext())
         {
            var queryStr = _queryStr.Replace("{MonthYear}", "(MONTH(pj.tanggal) >= @startMonth AND YEAR(pj.tanggal) >= @startYear AND " +
                                             "MONTH(pj.tanggal) <= @endMonth AND YEAR(pj.tanggal) <= @endYear)");

            return context.Conn.Query<GrafikBarangTerjualModel>(queryStr, new
            {
               startMonth = startMonthYear.Month,
               startYear = startMonthYear.Year,
               endMonth = endMonthYear.Month,
               endYear = endMonthYear.Year
            });
         }
      }
   }
}
