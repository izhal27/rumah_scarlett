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
            var queryStr = "SELECT IFNULL((SELECT stok_awal FROM status_barang WHERE DATE(TANGGAL)=@DATE ORDER BY id LIMIT 1), " +
                           "(SELECT SUM(stok) FROM barang)) AS stok_awal, " +
                           "IFNULL(SUM(stok_masuk), 0) AS stok_masuk, IFNULL(SUM(stok_terjual), 0) AS stok_terjual, " +
                           "IFNULL(SUM(penyesuaian_stok), 0) AS penyesuaian_stok, " +
                           "IFNULL(SUM(pembelian_return_qty), 0) AS pembelian_return_qty, " +
                           "IFNULL(SUM(penjualan_return_qty), 0) AS penjualan_return_qty, " +
                           "IFNULL((SELECT stok_akhir FROM status_barang WHERE DATE(TANGGAL)=@DATE ORDER BY id DESC LIMIT 1), 0) AS stok_akhir " +
                           "FROM status_barang s WHERE DATE(tanggal) = @DATE ORDER BY id DESC LIMIT 1";

            return context.Conn.Query<StatusBarangModel>(queryStr, new { date }).FirstOrDefault();
         }
      }
   }
}
