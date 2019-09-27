using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Satuan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian
{
   internal interface IPembelianReturnDetailRepository
   {
      void Insert(IPembelianReturnDetailModel model, IDbTransaction transactio);
      IEnumerable<IPembelianReturnDetailModel> GetAll(IPembelianReturnModel pembelianReturn, IDbTransaction transaction = null);
   }

   internal class PembelianReturnDetailRepository : BaseRepository<IPembelianReturnDetailModel>, IPembelianReturnDetailRepository
   {
      private DbContext _context;

      public PembelianReturnDetailRepository(DbContext context)
      {
         _context = context;
      }

      public void Insert(IPembelianReturnDetailModel model, IDbTransaction transaction)
      {
         var queryStr = "INSERT INTO pembelian_return_detail (pembelian_return_id, barang_id, qty, hpp, status, keterangan) " +
                        "VALUES (@pembelian_return_id, @barang_id, @qty, @hpp, @status, @keterangan)";

         _context.Conn.Query<int>(queryStr, new
         {
            model.pembelian_return_id,
            model.barang_id,
            model.qty,
            model.hpp,
            model.status,
            model.keterangan
         }, transaction);
      }

      public IEnumerable<IPembelianReturnDetailModel> GetAll(IPembelianReturnModel pembelianReturn, IDbTransaction transaction = null)
      {
         var dataAccessStatus = new DataAccessStatus();

         var queryStr = "SELECT * FROM pembelian_return_detail WHERE pembelian_return_id=@id";

         var listPembelianReturnDetails = _context.Conn.Query<PembelianReturnDetailModel>(queryStr, new { pembelianReturn.id }, transaction);

         if (listPembelianReturnDetails.ToList().Count > 0)
         {
            listPembelianReturnDetails = listPembelianReturnDetails.Map(prd =>
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
                  SetDataAccessValues(ex, "Salah satu barang yang dicari dalam tabel return pembelian tidak ditemukan.");
                  throw ex;
               }
            });
         }

         return listPembelianReturnDetails;
      }
   }
}
