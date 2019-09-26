using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Infrastructure.DataAccess.CommonRepositories;
using RumahScarlett.Services.Services.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan
{
   public class PenjualanReturnRepository : BaseRepository<IPenjualanReturnModel>, IPenjualanReturnRepository
   {
      public PenjualanReturnRepository()
      {
         _modelName = "return penjualan";
      }

      public void Insert(IPenjualanReturnModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            model.no_nota = DbHelper.GetMaxID(context, context.Transaction, "penjualan_return", "no_nota");
            model.tanggal = DateTime.Now;

            Insert(model, () =>
            {
               var queryStr = "INSERT INTO penjualan_return (tanggal, no_nota, penjualan_id) " +
                              "VALUES (@tanggal, @no_nota, @penjualan_id);" +
                              "SELECT LAST_INSERT_ID();";

               var insertedId = context.Conn.Query<uint>(queryStr, new
               {
                  model.tanggal,
                  model.no_nota,
                  model.penjualan_id
               }, context.Transaction).Single();

               if (insertedId > 0 && model.PenjualanReturnDetails.ToList().Count > 0)
               {
                  model.id = insertedId;
                  model.PenjualanReturnDetails = model.PenjualanReturnDetails.Map(p => p.penjualan_return_id = model.id).ToList();
                  model.PenjualanReturnDetails = model.PenjualanReturnDetails.Map(pd =>
                  {
                     var barang = context.Conn.Get<BarangModel>(pd.barang_id);

                     if (barang != null)
                     {
                        barang.Satuan = context.Conn.Get<SatuanModel>(barang.satuan_id);
                        pd.Barang = barang;
                     }
                     else
                     {
                        var ex = new DataAccessException(dataAccessStatus);
                        SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel penjualan return tidak ditemukan.");
                        throw ex;
                     }
                  });

                  var prdRepo = new PenjualanReturnDetailRepository(context);

                  var laporanStatusBarangModel = new StatusBarangModel();

                  queryStr = "SELECT SUM(stok) FROM barang";
                  var stokAwal = context.Conn.ExecuteScalar<int>(queryStr);

                  laporanStatusBarangModel.stok_awal = stokAwal;
                  laporanStatusBarangModel.tanggal = model.tanggal;
                  laporanStatusBarangModel.PenjualanReturn = model;

                  context.Conn.Insert(laporanStatusBarangModel, context.Transaction);

                  queryStr = "SELECT * FROM penjualan_detail WHERE penjualan_id = @penjualan_id";
                  var listPenjualanDetails = context.Conn.Query<PenjualanDetailModel>(queryStr, new { model.penjualan_id }).ToList();

                  foreach (var pd in listPenjualanDetails)
                  {
                     foreach (var prd in model.PenjualanReturnDetails)
                     {
                        if (pd.barang_id == prd.barang_id)
                        {
                           pd.qty_return += prd.qty;
                        }
                     }

                     context.Conn.Update(pd, context.Transaction);
                  }

                  if (listPenjualanDetails.Any(pd => pd.qty_return > pd.qty))
                  {
                     var ex = new DataAccessException(dataAccessStatus);
                     SetDataAccessValues(ex, "Salah satu qty return penjualan yang ingin disimpan melebihi qty yang terjual.");
                     throw ex;
                  }

                  foreach (var prd in model.PenjualanReturnDetails)
                  {
                     prdRepo.Insert(prd, context.Transaction);

                     prd.Barang.stok += prd.qty;

                     context.Conn.Update((BarangModel)prd.Barang, context.Transaction);
                  }

                  context.Commit();
               }
            }, dataAccessStatus,
            () => CheckAfterInsert(context, "SELECT COUNT(1) FROM penjualan_return WHERE no_nota = @no_nota "
                                   + "AND id = (SELECT id FROM penjualan_return ORDER BY ID DESC LIMIT 1)",
                                   new { model.no_nota }));
         }
      }

      public void Update(IPenjualanReturnModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPenjualanReturnModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            Delete(model, () =>
            {
               model.PenjualanReturnDetails = new PenjualanReturnDetailRepository(context).GetAll(model, context.Transaction);

               var queryStr = "SELECT * FROM penjualan_detail WHERE penjualan_id = @penjualan_id";
               var listPenjualanDetails = context.Conn.Query<PenjualanDetailModel>(queryStr, new { model.penjualan_id }).ToList();

               var success = context.Conn.Delete((PenjualanReturnModel)model, context.Transaction);

               if (success)
               {
                  if (model.PenjualanReturnDetails.ToList().Count > 0)
                  {
                     foreach (var pd in listPenjualanDetails)
                     {
                        foreach (var prd in model.PenjualanReturnDetails)
                        {
                           if (pd.barang_id == prd.barang_id)
                           {
                              pd.qty_return -= prd.qty;
                           }
                           
                           context.Conn.Update(pd, context.Transaction);
                        }
                     }

                     foreach (var prd in model.PenjualanReturnDetails)
                     {
                        var barangModel = context.Conn.Get<BarangModel>(prd.barang_id);

                        barangModel.stok -= prd.qty;

                        context.Conn.Update(barangModel, context.Transaction);
                     }

                     context.Commit();
                  }
               }
            }, dataAccessStatus, () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IPenjualanReturnModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IPenjualanReturnModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<PenjualanReturnModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      public IEnumerable<IPenjualanReturnModel> GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PenjualanReturnModel>(StringHelper.QueryStringByDate("penjualan_return"), new { date });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      public IEnumerable<IPenjualanReturnModel> GetByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            var listObjs = context.Conn.Query<PenjualanReturnModel>(StringHelper.QueryStringByBetweenDate("penjualan_return"), new { startDate, endDate });

            listObjs = MappingObjects(context, listObjs);

            return listObjs;
         }
      }

      private IEnumerable<PenjualanReturnModel> MappingObjects(DbContext context, IEnumerable<PenjualanReturnModel> listObj)
      {
         if (listObj != null && listObj.ToList().Count > 0)
         {
            var pdRepo = new PenjualanReturnDetailRepository(context);

            foreach (var p in listObj)
            {
               p.PenjualanReturnDetails = pdRepo.GetAll(p);
            }
         }

         return listObj;
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM penjualan_return WHERE id=@id",
                                new { id });
      }
   }
}
