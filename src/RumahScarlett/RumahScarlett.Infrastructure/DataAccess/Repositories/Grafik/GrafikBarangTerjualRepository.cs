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
      public IEnumerable<IGrafikBarangTerjualModel> GetByMonthYear(object month, object year)
      {
         using (var context = new DbContext())
         {
            var queryStr = "SELECT CONCAT(MONTHNAME(pj.tanggal), ' ', @YEAR) AS bulan_tahun, " +
                           "b.nama AS barang_nama, SUM(pjd.qty) AS stok_terjual FROM penjualan pj " +
                           "INNER JOIN penjualan_detail pjd ON pj.id = pjd.penjualan_id " +
                           "INNER JOIN barang b ON pjd.barang_id = b.id AND " +
                           "(MONTH(pj.tanggal) = @month AND YEAR(pj.tanggal) = @year) " +
                           "GROUP BY b.id ORDER BY stok_terjual DESC LIMIT 10";

            return context.Conn.Query<GrafikBarangTerjualModel>(queryStr, new { month, year });
         }
      }      
   }
}
