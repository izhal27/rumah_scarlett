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
   public class LabaRugiRepository : ILabaRugiRepository
   {
      public ILabaRugiModel GetByMonthYear(object month, object year)
      {
         using (var context = new DbContext())
         {
            var queryStr = "SELECT IFNULL((SELECT SUM((pjd.qty * pjd.harga_jual)) FROM penjualan pj " +
                           "INNER JOIN penjualan_detail pjd ON pj.id = pjd.penjualan_id " +
                           "WHERE MONTH(pj.tanggal)=@MONTH AND YEAR(pj.tanggal) = @year), 0) AS total_penjualan, " +
                           "IFNULL((SELECT SUM((pjrd.qty * pjrd.harga_jual)) FROM penjualan_return pjr " +
                           "INNER JOIN penjualan_return_detail pjrd ON pjr.id = pjrd.penjualan_return_id " +
                           "WHERE MONTH(pjr.tanggal) = @MONTH AND YEAR(pjr.tanggal) = @year), 0) AS total_return_penjualan, " +
                           "IFNULL((SELECT SUM((pjd.qty * pjd.hpp)) FROM penjualan pj INNER JOIN penjualan_detail pjd " +
                           "ON pj.id = pjd.penjualan_id WHERE MONTH(pj.tanggal) = @MONTH AND " +
                           "YEAR(pj.tanggal) = @year), 0) AS total_hpp, " +
                           "IFNULL((SELECT SUM((pjrd.qty * pjrd.hpp)) FROM penjualan_return pjr " +
                           "INNER JOIN penjualan_return_detail pjrd ON pjr.id = pjrd.penjualan_return_id " +
                           "WHERE MONTH(pjr.tanggal) = @MONTH AND YEAR(pjr.tanggal) = @year), 0) AS total_return_hpp, " +
                           "IFNULL((SELECT SUM(p.jumlah) FROM pengeluaran p WHERE MONTH(p.tanggal) = @MONTH AND " +
                           "YEAR(p.tanggal) = @year), 0) AS total_pengeluaran, " +
                           "IFNULL((SELECT SUM(pj.diskon) FROM penjualan pj WHERE MONTH(pj.tanggal) = @MONTH AND " +
                           "YEAR(pj.tanggal) = @year), 0) AS total_diskon_penjualan";

            var model = context.Conn.Query<LabaRugiModel>(queryStr, new { month, year }).FirstOrDefault();

            return model;
         }
      }
   }
}
