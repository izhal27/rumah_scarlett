using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Domain.Models.Satuan;
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
      public PenyesuaianStokRepository()
      {
         _modelName = "penyesuaian stok";
      }

      public void Insert(IPenyesuaianStokModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            Insert(model, () =>
            {
               var barang = context.Conn.Get<BarangModel>(model.barang_id);

               if (barang != null)
               {
                  model.Barang = barang;
               }
               else
               {
                  var ex = new DataAccessException(dataAccessStatus);
                  SetDataAccessValues(ex, "Salah satu barang yang ingin ditambahkan ke dalam tabel penyesuaian stok tidak ditemukan.");
                  throw ex;
               }

               if (barang.hpp == 0)
               {
                  var ex = new DataAccessException(dataAccessStatus);
                  SetDataAccessValues(ex, "Salah satu barang yang ingin dimasukan ke dalam tabel penyesuaian stok " +
                                          "belum memiliki hpp.");
                  throw ex;
               }
               else
               {
                  context.Conn.Insert((PenyesuaianStokModel)model, context.Transaction);

                  CheckBarangStok(model, dataAccessStatus);

                  context.Conn.Update((BarangModel)model.Barang, context.Transaction);

                  context.Commit();
               }
            }, dataAccessStatus,
            () => CheckAfterInsert(context, "SELECT COUNT(1) FROM penyesuaian_stok WHERE tanggal=@tanggal "
                                   + "AND id=(SELECT LAST_INSERT_ID())", new { model.tanggal }));
         }
      }

      public void Update(IPenyesuaianStokModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            context.BeginTransaction();

            Update(model, () =>
            {
               var barang = context.Conn.Get<BarangModel>(model.barang_id, context.Transaction);
               model.Barang = barang;

               var qtyOld = context.Conn.Get<PenyesuaianStokModel>(model.id, context.Transaction).qty;
               model.Barang.stok += qtyOld;

               context.Conn.Update((PenyesuaianStokModel)model, context.Transaction);

               CheckBarangStok(model, dataAccessStatus);

               context.Conn.Update((BarangModel)model.Barang, context.Transaction);

               context.Commit();
            }, dataAccessStatus, () => CheckModelExist(context, model.id));
         }
      }

      private void CheckBarangStok(IPenyesuaianStokModel model, DataAccessStatus dataAccessStatus)
      {
         model.Barang.stok -= model.qty;

         if (model.Barang.minimal_stok > model.Barang.stok)
         {
            var ex = new DataAccessException(dataAccessStatus);
            SetDataAccessValues(ex, "Salah satu qty barang yang ingin dimasukan ke dalam tabel penyesuaian stok " +
                                    "melebihi minimal stok dari barang tersebut.");
            throw ex;
         }
      }

      public void Delete(IPenyesuaianStokModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () =>
            {
               context.BeginTransaction();

               var success = context.Conn.Delete((PenyesuaianStokModel)model, context.Transaction);

               if (success)
               {
                  var barang = context.Conn.Get<BarangModel>(model.barang_id, context.Transaction);
                  model.Barang = barang;

                  model.Barang.stok += model.qty;

                  context.Conn.Update((BarangModel)model.Barang, context.Transaction);

                  context.Commit();
               }
            }, dataAccessStatus, () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IPenyesuaianStokModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() =>
            {
               var listObj = context.Conn.GetAll<PenyesuaianStokModel>();

               if (listObj != null && listObj.ToList().Count > 0)
               {
                  listObj = listObj.Map(ps => ps.Barang = context.Conn.Get<BarangModel>(ps.barang_id));
                  listObj = listObj.Map(ps => ps.Satuan = context.Conn.Get<SatuanModel>(ps.satuan_id));
               }

               return listObj;
            }, dataAccessStatus);
         }
      }
      
      public IPenyesuaianStokModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() =>
            {
               var model = context.Conn.Get<PenyesuaianStokModel>(id);

               if (model != null)
               {
                  model.Barang = context.Conn.Get<BarangModel>(model.barang_id);
                  model.Satuan = context.Conn.Get<SatuanModel>(model.satuan_id);
               }

               return model;
            }, dataAccessStatus, () => CheckModelExist(context, id));
         }
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM penyesuaian_stok WHERE id=@id",
                                new { id });
      }
   }
}
