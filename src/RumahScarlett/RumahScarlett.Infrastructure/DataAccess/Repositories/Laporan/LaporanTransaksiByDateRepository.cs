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
   public class LaporanTransaksiByDateRepository : ITransaksiByDateRepository
   {
      public ITransaksiByDateModel Get(object date)
      {
         using (var context = new DbContext())
         {
            var queryStr = "SELECT IFNULL(SUM(pd.qty * pd.harga_jual), 0) AS total_penjualan, " +
                       "IFNULL(SUM(p.diskon), 0) AS total_diskon, " +
                       "IFNULL((SELECT total FROM kas_awal WHERE tanggal=@DATE), 0) AS kas_awal, " +
                       "IFNULL((SELECT SUM(jumlah) FROM pengeluaran WHERE DATE(tanggal)=@DATE), 0) AS total_pengeluaran " +
                       "FROM penjualan p INNER JOIN penjualan_detail pd ON p.id=pd.penjualan_id WHERE DATE(p.tanggal) = @date;";
            
            return context.Conn.Query<TransaksiByDateModel>(queryStr, new { date }).FirstOrDefault();
         }
      }
   }
}
