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
   public class StatusPerBarangRepository : IStatusPerBarangRepository
   {
      private static string _queryStr = "SELECT b.id, b.kode, b.nama, s.nama AS satuan, " +
                                        "IFNULL((SELECT SUM(pbd.qty) FROM pembelian pb " +
                                        "INNER JOIN pembelian_detail pbd ON pb.id = pbd.pembelian_id AND " +
                                        "{MonthYearPembelian} " +
                                        "WHERE pbd.barang_id = b.id), 0) AS stok_masuk, " +
                                        "IFNULL((SELECT SUM(pjd.qty) FROM penjualan pj " +
                                        "INNER JOIN penjualan_detail pjd ON pj.id = pjd.penjualan_id AND " +
                                        "{MonthYearPenjualan} " +
                                        "WHERE pjd.barang_id = b.id), 0) AS stok_keluar " +
                                        "FROM barang b INNER JOIN satuan s ON b.satuan_id = s.id";

      public IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear monthYear)
      {
         using (var context = new DbContext())
         {
            var queryStr = _queryStr.Replace("{MonthYearPembelian}", "MONTH(pb.tanggal) = @month AND YEAR(pb.tanggal) = @year");
            queryStr = queryStr.Replace("{MonthYearPenjualan}", "MONTH(pj.tanggal) = @month AND YEAR(pj.tanggal) = @year");

            return context.Conn.Query<StatusPerBarangModel>(queryStr, new { monthYear.Month, monthYear.Year });
         }
      }

      public IEnumerable<IStatusPerBarangModel> GetByMonthYear(MonthYear startMonthYear, MonthYear endMonthYear)
      {
         using (var context = new DbContext())
         {
            var queryStr = _queryStr.Replace("{MonthYearPembelian}", "(MONTH(pb.tanggal) >= @startMonth AND YEAR(pb.tanggal) >= @startYear AND " +
                                             "MONTH(pb.tanggal) <= @endMonth AND YEAR(pb.tanggal) <= @endYear)");
            queryStr = queryStr.Replace("{MonthYearPenjualan}", "(MONTH(pj.tanggal) >= @startMonth AND YEAR(pj.tanggal) >= @startYear AND " +
                                        "MONTH(pj.tanggal) <= @endMonth AND YEAR(pj.tanggal) <= @endYear)");

            return context.Conn.Query<StatusPerBarangModel>(queryStr, new { startMonth = startMonthYear.Month, startYear = startMonthYear.Year,
                                                            endMonth = endMonthYear.Month, endYear = endMonthYear.Year});
         }
      }
   }
}
