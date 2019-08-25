using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Services.Services.PenyesuaianStok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.PenyesuaianStok
{
   public class PenyesuaianStokRepository : BaseRepository<IPenyesuaianStokModel>, IPenyesuaianStokRepository
   {
      private DbContext _context;
      private PenyesuaianStokDetailRepository _psdRepo;

      public PenyesuaianStokRepository()
      {
         _context = new DbContext();
         _modelName = "penyesuaian stok";
         _psdRepo = new PenyesuaianStokDetailRepository(_context);
      }

      public void Insert(IPenyesuaianStokModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         model.no_nota = DbHelper.GetMaxID("penyesuaian_stok", "no_nota");


         Insert(model, () =>
         {
            using (var transaction = _context.Conn.BeginTransaction())
            {
               var queryStr = "INSERT INTO penyesuaian_stok (no_nota, tanggal) " +
                              "VALUES (@no_nota, @tanggal);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = _context.Conn.Query<uint>(queryStr, new
               {
                  model.no_nota,
                  model.tanggal
               }, transaction).Single();

               if (insertedId > 0)
               {
                  model.id = insertedId;
                  model.PenyesuaianStokDetails = model.PenyesuaianStokDetails.Map(p => p.penyesuaian_stok_id = model.id).ToList();
                  model.PenyesuaianStokDetails = model.PenyesuaianStokDetails.Map(p => p.Barang = new BarangRepository().GetById(p.barang_id));

                  foreach (var pd in model.PenyesuaianStokDetails)
                  {
                     _psdRepo.Insert(pd, transaction);
                  }

                  foreach (var pd in model.PenyesuaianStokDetails)
                  {
                     var barang = _context.Conn.Get<BarangModel>(pd.barang_id, transaction);

                     if (barang != null && barang.stok > 0)
                     {
                        barang.stok -= pd.qty;

                        _context.Conn.Update(barang, transaction);
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Qty salah satu barang yang ingin ditambahkan ke dalam tabel Penyesuaian stok bernilai 0 (Nol).");
                        throw ex;
                     }
                  }
               }

               transaction.Commit();
            }
         }, dataAccessStatus, () => CheckInsert(model));
      }

      public void Update(IPenyesuaianStokModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPenyesuaianStokModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () =>
         {
            using (var transaction = _context.Conn.BeginTransaction())
            {
               var listPembelianDetails = _context.Conn.Query<PenyesuaianStokDetailModel>(
                                          "SELECT * FROM penyesuaian_stok_detail where penyesuaian_stok_id=@id",
                                          new { model.id }, transaction).ToList();

               var success = _context.Conn.Delete((PenyesuaianStokModel)model, transaction);
               model.PenyesuaianStokDetails = listPembelianDetails;

               if (success)
               {
                  foreach (var pd in model.PenyesuaianStokDetails)
                  {
                     var barang = _context.Conn.Get<BarangModel>(pd.barang_id, transaction);

                     if (barang != null)
                     {
                        barang.stok += pd.qty;

                        _context.Conn.Update(barang, transaction);
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin dicari dalam tabel penyesuiaian stok tidak ditemukan.");
                        throw ex;
                     }
                  }
               }

               transaction.Commit();
            }
         }, dataAccessStatus, () => CheckUpdateDelete(model));
      }

      public IEnumerable<IPenyesuaianStokModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPenyesuaianStokModel> GetByDate(object date)
      {
         var queryStr = StringHelper.QueryStringByDate("penyesuaian_stok", "tanggal");

         return GetByDate(queryStr, date);
      }

      public IEnumerable<IPenyesuaianStokModel> GetByDate(object startDate, object endDate)
      {
         var queryStr = StringHelper.QueryStringByBetweenDate("penyesuaian_stok", "tanggal");

         return GetByDate(queryStr, startDate: startDate, endDate: endDate);
      }

      private IEnumerable<IPenyesuaianStokModel> GetByDate(string queryStr, object date = null,
                                                           object startDate = null, object endDate = null)
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            if (date != null)
            {
               date = ((DateTime)date).ToMysqlDateFormat();
            }
            else if (startDate != null && endDate != null)
            {
               startDate = ((DateTime)startDate).ToMysqlDateFormat();
               endDate = ((DateTime)endDate).ToMysqlDateFormat();
            }

            var listPenyesuaianStoks = _context.Conn.Query<PenyesuaianStokModel>(queryStr, new { date, startDate, endDate }).ToList();

            if (listPenyesuaianStoks.Count > 0)
            {
               foreach (var p in listPenyesuaianStoks)
               {
                  var listPenyesuaianStokDetails = _psdRepo.GetAll(p).ToList();
                  p.PenyesuaianStokDetails = listPenyesuaianStokDetails;
               }
            }

            return listPenyesuaianStoks;
         }, dataAccessStatus);
      }

      public IPenyesuaianStokModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      private bool CheckInsert(IPenyesuaianStokModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penyesuaian_stok WHERE no_nota=@no_nota "
                                                  + "AND id=(SELECT id FROM penyesuaian_stok ORDER BY ID DESC LIMIT 1)",
                                                  new { model.no_nota });
      }

      private bool CheckUpdateDelete(IPenyesuaianStokModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM penyesuaian_stok WHERE id=@id",
                                                  new { model.id });
      }
   }
}
