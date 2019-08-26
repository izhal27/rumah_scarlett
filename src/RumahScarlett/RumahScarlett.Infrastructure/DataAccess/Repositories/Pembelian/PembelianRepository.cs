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

               if (insertedId > 0 && model.PembelianDetails.ToList().Count > 0)
               {
                  model.id = insertedId;
                  model.PembelianDetails = model.PembelianDetails.Map(p => p.pembelian_id = model.id).ToList();
                  model.PembelianDetails = model.PembelianDetails.Map(pd =>
                  {
                     var barang = _context.Conn.Get<BarangModel>(pd.barang_id);

                     if (barang != null)
                     {
                        pd.Barang = barang;
                     }
                     else
                     {
                        transaction.Rollback();
                        _context.Dispose();

                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel pembelian tidak ditemukan.");
                        throw ex;
                     }
                  });

                  foreach (var pd in model.PembelianDetails)
                  {
                     _pdRepo.Insert(pd, transaction);
                     pd.Barang.stok += pd.qty;

                     if (pd.hpp > 0)
                     {
                        pd.Barang.hpp = pd.hpp;
                     }

                     _context.Conn.Update((BarangModel)pd.Barang, transaction);
                  }

                  transaction.Commit();
               }
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
               model.PembelianDetails = _pdRepo.GetAll(model, transaction).ToList();

               var success = _context.Conn.Delete((PembelianModel)model, transaction);

               if (success)
               {
                  if (model.PembelianDetails.ToList().Count > 0)
                  {
                     foreach (var pd in model.PembelianDetails)
                     {
                        pd.Barang.stok -= pd.qty;

                        _context.Conn.Update((BarangModel)pd.Barang, transaction);
                     }

                     transaction.Commit();
                  }
               }
            }
         }, dataAccessStatus, () => CheckUpdateDelete(model));
      }

      public IEnumerable<IPembelianModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            var listPembelians = _context.Conn.GetAll<PembelianModel>().ToList();

            if (listPembelians.Count > 0)
            {
               listPembelians = listPembelians.Map(p => p.Supplier =_context.Conn.Get<SupplierModel>(p.supplier_id)).ToList();

               foreach (var p in listPembelians)
               {
                  p.PembelianDetails = _pdRepo.GetAll(p);
               }
            }

            return listPembelians;
         }, dataAccessStatus);
      }

      public IEnumerable<IPembelianModel> GetByDate(object date)
      {
         return GetAll().Where(p => p.tanggal.Date == ((DateTime)date).Date);
      }

      public IEnumerable<IPembelianModel> GetByDate(object startDate, object endDate)
      {
         return GetAll().Where(p => p.tanggal.Date >= ((DateTime)startDate).Date && p.tanggal.Date <= ((DateTime)endDate).Date);
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
