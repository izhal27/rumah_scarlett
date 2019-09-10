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
   public class LaporanStatusBarangRepository : ILaporanStatusBarangRepository
   {
      public LaporanStatusBarangRepository()
      {

      }

      public IEnumerable<ILaporanStatusBarangModel> GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var queryStr = "SELECT b.id, b.kode AS barang_kode, b.nama AS barang_nama, " +
                           "IFNULL((SELECT SUM(pbd.qty) FROM pembelian pb INNER JOIN pembelian_detail pbd ON " +
                           "pb.id = pbd.pembelian_id WHERE pbd.barang_id = b.id AND DATE(pb.tanggal)=@date), 0) AS stok_masuk, " +
                           "IFNULL((SELECT SUM(pjd.qty) FROM penjualan pj INNER JOIN penjualan_detail pjd ON pj.id = pjd.penjualan_id " +
                           "WHERE pjd.barang_id = b.id AND DATE(pj.tanggal)=@date), 0) AS stok_keluar FROM barang b ORDER BY id";
            
            return context.Conn.Query<LaporanStatusBarangModel>(queryStr, new { date });
         }
      }

      public IEnumerable<ILaporanStatusBarangModel> GetByDate(object startDate, object endDate)
      {
         using (var context = new DbContext())
         {
            var queryStr = "SELECT b.id, b.kode AS barang_kode, b.nama AS barang_nama, " +
                           "IFNULL((SELECT SUM(pbd.qty) FROM pembelian pb INNER JOIN pembelian_detail pbd ON " +
                           "pb.id = pbd.pembelian_id WHERE pbd.barang_id = b.id AND (DATE(pb.tanggal) >= @startDate AND DATE(pb.tanggal) <= @endDate)), 0) AS stok_masuk, " +
                           "IFNULL((SELECT SUM(pjd.qty) FROM penjualan pj INNER JOIN penjualan_detail pjd ON pj.id = pjd.penjualan_id " +
                           "WHERE pjd.barang_id = b.id AND (DATE(pj.tanggal) >= @startDate AND DATE(pj.tanggal) <= @endDate)), 0) AS stok_keluar FROM barang b ORDER BY id";

            return context.Conn.Query<LaporanStatusBarangModel>(queryStr, new { startDate, endDate });
         }
      }
   }
}
