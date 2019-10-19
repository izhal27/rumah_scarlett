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
   public class TransaksiByDateRepository : ITransaksiByDateRepository
   {
      public ITransaksiByDateModel Get(object date)
      {
         using (var context = new DbContext())
         {
            var queryStr = "SELECT IFNULL((SELECT total FROM kas_awal WHERE tanggal = @date), 0) AS kas_awal, " +
               "IFNULL((SELECT SUM(pd.qty * pd.harga_jual) FROM penjualan p INNER JOIN penjualan_detail pd ON p.id = pd.penjualan_id " +
               "WHERE date(p.tanggal) = @date), 0) AS total_penjualan, " +
               "IFNULL((SELECT SUM(diskon) FROM penjualan WHERE date(tanggal) = @date), 0) AS total_diskon, " +
               "IFNULL((SELECT SUM(jumlah) FROM pengeluaran WHERE date(tanggal) = @date), 0) AS total_pengeluaran, " +
               "IFNULL((SELECT SUM(pjrd.qty * pjrd.harga_jual) FROM penjualan_return pjr " +
               "INNER JOIN penjualan_return_detail pjrd ON pjr.id = pjrd.penjualan_return_id " +
               "WHERE date(pjr.tanggal) = @date), 0) AS total_return_penjualan";

            return context.Conn.Query<TransaksiByDateModel>(queryStr, new { date }).FirstOrDefault();
         }
      }
   }
}
