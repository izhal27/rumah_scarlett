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
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
using RumahScarlett.Domain.Models.Supplier;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pembelian
{
   public class PembelianRepository : BaseRepository<IPembelianModel>, IPembelianRepository
   {
      private DbContext _context;
      private IPembelianDetailRepository _pdRepo;

      public PembelianRepository()
      {
         _context = new DbContext();
         _modelName = "pembelian";
         _pdRepo = new PembelianDetailRepository(_context);
      }

      public void Insert(IPembelianModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         model.no_nota = DbHelper.GetMaxID("pembelian", "no_nota");

         Insert(model, () =>
         {
            using (var transaction = _context.Conn.BeginTransaction())
            {
               var queryStr = "INSERT INTO pembelian (supplier_id, no_nota, tanggal) " +
                              "VALUES (@supplier_id, @no_nota, @tanggal);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = _context.Conn.Query<uint>(queryStr, new
               {
                  model.supplier_id,
                  model.no_nota,
                  model.tanggal
               }, transaction).Single();

               if (insertedId > 0)
               {
                  model.id = insertedId;
                  model.PembelianDetails = model.PembelianDetails.Map(p => p.pembelian_id = model.id).ToList();

                  foreach (var pd in model.PembelianDetails)
                  {
                     _pdRepo.Insert(pd, transaction);
                  }

                  foreach (var pd in model.PembelianDetails)
                  {
                     var barang = _context.Conn.Get<BarangModel>(pd.barang_id, transaction);

                     if (barang != null)
                     {
                        barang.stok += pd.qty;

                        if (pd.hpp > 0)
                        {
                           barang.hpp = pd.hpp;
                        }

                        _context.Conn.Update(barang, transaction);
                     }
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

         Delete(model, () =>
         {
            using (var transaction = _context.Conn.BeginTransaction())
            {
               var listPembelianDetails = _context.Conn.Query<PembelianDetailModel>(
                                          "SELECT * FROM pembelian_detail where pembelian_id=@id",
                                          new { model.id }, transaction).ToList();

               var success = _context.Conn.Delete((PembelianModel)model, transaction);

               if (success)
               {
                  foreach (var pd in listPembelianDetails)
                  {
                     var barang = _context.Conn.Get<BarangModel>(pd.barang_id, transaction);

                     if (barang != null)
                     {
                        barang.stok -= pd.qty;

                        _context.Conn.Update(barang, transaction);
                     }
                  }
               }

               transaction.Commit();
            }
         }, dataAccessStatus, () => CheckUpdateDelete(model));
      }

      public IEnumerable<IPembelianModel> GetAll()
      {
         throw new NotImplementedException();
      }


      public IEnumerable<IPembelianModel> GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            date = ((DateTime)date).ToMysqlDateFormat();

            var queryStr = StringHelper.QueryStringByDate("pembelian", "tanggal");

            var listPembelians = _context.Conn.Query<PembelianModel>(queryStr, new { date }).ToList();

            if (listPembelians.Count > 0)
            {
               listPembelians = listPembelians.Map(p => p.Supplier = new SupplierRepository()
                                                                     .GetById(p.supplier_id)).ToList();

               foreach (var p in listPembelians)
               {
                  var listPembeliadDetails = _pdRepo.GetAll(p).ToList();
                  p.PembelianDetails = listPembeliadDetails;
               }
            }

            return listPembelians;
         }, dataAccessStatus);
      }

      public IEnumerable<IPembelianModel> GetByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            startDate = ((DateTime)startDate).ToMysqlDateFormat();
            endDate = ((DateTime)endDate).ToMysqlDateFormat();

            var queryStr = StringHelper.QueryStringByBetweenDate("pembelian", "tanggal");

            var listPembelians = _context.Conn.Query<PembelianModel>(queryStr, new { startDate, endDate }).ToList();

            if (listPembelians.Count > 0)
            {
               listPembelians = listPembelians.Map(p => p.Supplier = new SupplierRepository()
                                                                     .GetById(p.supplier_id)).ToList();

               foreach (var p in listPembelians)
               {
                  var listPembeliadDetails = _pdRepo.GetAll(p).ToList();
                  p.PembelianDetails = listPembeliadDetails;
               }
            }

            return listPembelians;
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
