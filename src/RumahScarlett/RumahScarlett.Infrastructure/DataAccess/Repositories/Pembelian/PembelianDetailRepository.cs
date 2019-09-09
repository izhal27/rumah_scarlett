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
   internal interface IPembelianDetailRepository
   {
      void Insert(IPembelianDetailModel model, IDbTransaction transaction);
      IEnumerable<IPembelianDetailModel> GetAll(IPembelianModel pembelian, IDbTransaction transaction = null);
   }

   internal class PembelianDetailRepository : BaseRepository<IPembelianDetailModel>, IPembelianDetailRepository
   {
      private DbContext _context;

      public PembelianDetailRepository(DbContext context)
      {
         _context = context;
      }

      public void Insert(IPembelianDetailModel model, IDbTransaction transaction)
      {
         var queryStr = "INSERT INTO pembelian_detail (pembelian_id, barang_id, qty, hpp) " +
                        "VALUES (@pembelian_id, @barang_id, @qty, @hpp)";

         _context.Conn.Query<int>(queryStr, new
         {
            pembelian_id = model.pembelian_id,
            barang_id = model.barang_id,
            qty = model.qty,
            hpp = model.hpp > 0 ? model.hpp : model.Barang.hpp,
         }, transaction);
      }

      public IEnumerable<IPembelianDetailModel> GetAll(IPembelianModel pembelian, IDbTransaction transaction = null)
      {
         var dataAccessStatus = new DataAccessStatus();

         var queryStr = "SELECT * FROM pembelian_detail WHERE pembelian_id=@id";

         var listPembelianDetails = _context.Conn.Query<PembelianDetailModel>(queryStr, new { id = pembelian.id }, transaction);

         if (listPembelianDetails.ToList().Count > 0)
         {
            listPembelianDetails = listPembelianDetails.Map(pd =>
            {
               var barangModel = _context.Conn.Get<BarangModel>(pd.barang_id);

               if (barangModel != null)
               {
                  pd.Barang = barangModel;

                  var satuanModel = _context.Conn.Get<SatuanModel>(barangModel.satuan_id);

                  if (satuanModel != null)
                  {
                     pd.Barang.Satuan = satuanModel;
                  }
               }
               else
               {
                  var ex = new DataAccessException(dataAccessStatus);
                  SetDataAccessValues(ex, "Salah satu barang yang dicari dalam tabel pembelian tidak ditemukan.");
                  throw ex;
               }
            });
         }

         return listPembelianDetails;
      }
   }
}
