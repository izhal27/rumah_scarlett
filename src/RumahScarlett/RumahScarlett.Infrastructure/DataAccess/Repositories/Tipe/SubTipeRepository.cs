using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   public class SubTipeRepository : BaseRepository<ISubTipeModel>, ISubTipeRepository
   {
      public SubTipeRepository()
      {
         _modelName = "sub tipe";
      }

      public void Insert(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((SubTipeModel)model), dataAccessStatus,
                  () => CheckAfterInsert(context, "SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama "
                                          + "AND id=(SELECT LAST_INSERT_ID())",
                                          new { model.nama }));
         }
      }

      public void Update(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((SubTipeModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public void Delete(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((SubTipeModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<ISubTipeModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => { return context.Conn.GetAll<SubTipeModel>(); }, dataAccessStatus);
         }
      }
      
      public ISubTipeModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => { return context.Conn.Get<SubTipeModel>(id); },
                         dataAccessStatus, () => CheckModelExist(context, id));
         }
      }

      private void ValidateModel(DbContext context, ISubTipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama AND id!=@id",
                                                            new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus);
         }
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM sub_tipe WHERE id=@id", new { id });
      }
   }
}
