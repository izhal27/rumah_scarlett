using RumahScarlett.Services.Services.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.CommonComponents;
using Dapper.Contrib.Extensions;
using Dapper;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using RumahScarlett.Services.CommonServices;
using System.Transactions;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian
{
   public class PembelianRepository : BaseRepository<IPembelianModel>, IPembelianRepository
   {
      private DbContext _context;

      public PembelianRepository()
      {
         _context = new DbContext();
         _modelName = "pembelian";
      }

      public void Insert(IPembelianModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         model.no_nota = DbHelper.GetMaxID("pembelian", "no_nota");

         Insert(model, () =>
         {
            using (var transaction = _context.Conn.BeginTransaction())
            {
               var queryStr = "INSERT INTO pembelian (supplier_id, no_nota, tanggal) VALUES (@supplier_id, @no_nota, @tanggal);" +
                                 "SELECT LAST_INSERT_ID();";

               var insertedId = _context.Conn.Query<uint>(queryStr, new
               {
                  model.supplier_id,
                  model.no_nota,
                  model.tanggal
               }, transaction).Single();

               if (insertedId > 0)
               {
                  var queryStr2 = "INSERT INTO pembelian_detail (pembelian_id, barang_id, qty, hpp) VALUES (@pembelian_id, @barang_id, @qty, @hpp)";

                  foreach (var pembelianDetail in model.PembelianDetails)
                  {
                     _context.Conn.Query<int>(queryStr2, new
                     {
                        pembelian_id = insertedId,
                        barang_id = pembelianDetail.barang_id,
                        qty = pembelianDetail.qty,
                        hpp = pembelianDetail.hpp
                     }, transaction);
                  }
               }

               transaction.Commit();
            }
         }, dataAccessStatus, () => CheckInsert(model));
      }

      public void Update(IPembelianModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPembelianModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () => _context.Conn.Delete(model), dataAccessStatus,
               () => CheckUpdateDelete(model));
      }

      public IEnumerable<IPembelianModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            return _context.Conn.GetAll<PembelianModel>().ToList();
         }, dataAccessStatus);
      }

      public IPembelianModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      private bool CheckInsert(IPembelianModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pembelian WHERE no_nota=@no_nota "
                                                  + "AND id=(SELECT id FROM pembelian ORDER BY ID DESC LIMIT 1)",
                                                  new { model.no_nota });
      }

      private bool CheckUpdateDelete(IPembelianModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pembelian WHERE id=@id",
                                                  new { model.id });
      }
   }
}
