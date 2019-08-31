using RumahScarlett.Services.Services.Pelanggan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.CommonComponents;
using Dapper;
using Dapper.Contrib.Extensions;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pelanggan
{
   public class PelangganRepository : BaseRepository<IPelangganModel>, IPelangganRepository
   {
      public PelangganRepository()
      {
         _modelName = "pelanggan";
      }

      public void Insert(IPelangganModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((PelangganModel)model), dataAccessStatus,
                   () => CheckAfterInsert(context, "SELECT COUNT(1) FROM pelanggan WHERE id=@id",
                                          new { id = model.id }));
         }
      }

      public void Update(IPelangganModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((PelangganModel)model), dataAccessStatus,
                   () => CheckModelExist(context, model.id));
         }
      }

      public void Delete(IPelangganModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((PelangganModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IPelangganModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => { return context.Conn.GetAll<PelangganModel>().ToList(); }, dataAccessStatus);
         }
      }

      public IPelangganModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<PelangganModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      private void ValidateModel(DbContext context, IPelangganModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pelanggan WHERE nama=@nama AND id!=@id",
                                                           new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM pelanggan WHERE id=@id", new { id });
      }
   }
}
