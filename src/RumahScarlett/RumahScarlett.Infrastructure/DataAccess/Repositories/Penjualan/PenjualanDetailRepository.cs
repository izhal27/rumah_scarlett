using Dapper;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan
{
   internal interface IPenjualanDetailRepository
   {
      void Insert(IPenjualanDetailModel model, IDbTransaction transaction);
      IEnumerable<IPenjualanDetailModel> GetAll(IPenjualanModel penjualan);
   }

   internal class PenjualanDetailRepository : IPenjualanDetailRepository
   {
      private DbContext _context;

      public PenjualanDetailRepository(DbContext context)
      {
         _context = context;
      }
      
      public void Insert(IPenjualanDetailModel model, IDbTransaction transaction)
      {
         var queryStr = "INSERT INTO penjualan_detail (penjualan_id, barang_id, qty, harga_jual) " +
                        "VALUES (@penjualan_id, @barang_id, @qty, @harga_jual)";

         _context.Conn.Query<int>(queryStr, new
         {
            penjualan_id = model.penjualan_id,
            barang_id = model.barang_id,
            qty = model.qty,
            harga_jual = model.harga_jual
         }, transaction);
      }

      public IEnumerable<IPenjualanDetailModel> GetAll(IPenjualanModel penjualan)
      {
         var queryStr = "SELECT * FROM penjualan_detail WHERE penjualan_id=@id";

         var listPembelianDetails = _context.Conn.Query<PenjualanDetailModel>(queryStr, new { id = penjualan.id }).ToList();

         if (listPembelianDetails.Count > 0)
         {
            listPembelianDetails = listPembelianDetails.Map(pd => pd.Barang = new BarangRepository().GetById(pd.barang_id)).ToList();
         }

         return listPembelianDetails;
      }
   }
}
