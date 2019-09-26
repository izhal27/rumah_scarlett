using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Domain.Models.Satuan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan
{
   internal interface IPenjualanReturnDetailRepository
   {
      void Insert(IPenjualanReturnDetailModel model, IDbTransaction transactio);
      IEnumerable<IPenjualanReturnDetailModel> GetAll(IPenjualanReturnModel penjualanReturn, IDbTransaction transaction = null);
   }

   internal class PenjualanReturnDetailRepository : BaseRepository<IPenjualanReturnDetailModel>, IPenjualanReturnDetailRepository
   {
      private DbContext _context;

      public PenjualanReturnDetailRepository(DbContext context)
      {
         _context = context;
      }

      public void Insert(IPenjualanReturnDetailModel model, IDbTransaction transaction)
      {
         var queryStr = "INSERT INTO penjualan_return_detail (penjualan_return_id, barang_id, qty, hpp, harga_jual, status, keterangan) " +
                        "VALUES (@penjualan_return_id, @barang_id, @qty, @hpp, @harga_jual, @status, @keterangan)";

         _context.Conn.Query<int>(queryStr, new
         {
            model.penjualan_return_id,
            model.barang_id,
            model.qty,
            model.hpp,
            model.harga_jual,
            model.status,
            model.keterangan
         }, transaction);
      }

      public IEnumerable<IPenjualanReturnDetailModel> GetAll(IPenjualanReturnModel penjualanReturn, IDbTransaction transaction = null)
      {
         var dataAccessStatus = new DataAccessStatus();

         var queryStr = "SELECT * FROM penjualan_return_detail WHERE penjualan_return_id=@id";

         var listPenjualanReturnDetails = _context.Conn.Query<PenjualanReturnDetailModel>(queryStr, new { penjualanReturn.id }, transaction);

         if (listPenjualanReturnDetails.ToList().Count > 0)
         {
            listPenjualanReturnDetails = listPenjualanReturnDetails.Map(prd =>
            {
               var barangModel = _context.Conn.Get<BarangModel>(prd.barang_id, transaction);

               if (barangModel != null)
               {
                  prd.Barang = barangModel;

                  var satuanModel = _context.Conn.Get<SatuanModel>(prd.Barang.satuan_id);

                  if (satuanModel != null)
                  {
                     prd.Barang.Satuan = satuanModel;
                  }
               }
               else
               {
                  var ex = new DataAccessException(dataAccessStatus);
                  SetDataAccessValues(ex, "Salah satu barang yang dicari dalam tabel return penjualan tidak ditemukan.");
                  throw ex;
               }
            });
         }

         return listPenjualanReturnDetails;
      }
   }
}
