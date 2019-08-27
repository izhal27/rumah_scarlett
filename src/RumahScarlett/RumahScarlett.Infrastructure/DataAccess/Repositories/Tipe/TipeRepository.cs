using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   public class TipeRepository : BaseRepository<ITipeModel>, ITipeRepository
   {
      public TipeRepository()
      {
         _modelName = "tipe";
      }

      public void Insert(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((TipeModel)model), dataAccessStatus,
                  () => CheckInsert(context, model));
         }
      }

      public void Update(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((TipeModel)model), dataAccessStatus,
                  () => CheckUpdateDelete(context, model));
         }
      }

      public void Delete(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((TipeModel)model), dataAccessStatus,
                () => CheckUpdateDelete(context, model));
         }
      }

      public IEnumerable<ITipeModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() =>
            {
               var listObj = context.Conn.GetAll<TipeModel>();

               var stRepo = new SubTipeRepository(context);

               if (listObj != null && listObj.ToList().Count > 0)
               {
                  listObj = listObj.Map(t => t.SubTipes = stRepo.GetAll(t));
               }

               return listObj;
            }, dataAccessStatus);
         }
      }

      public ITipeModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<TipeModel>(id), dataAccessStatus);
         }
      }

      private void ValidateModel(DbContext context, ITipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE nama=@nama AND id!=@id",
                                                             new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(DbContext context, ITipeModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(DbContext context, ITipeModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE id=@id",
                                                  new { model.id });
      }

      public void Insert(ISubTipeModel model)
      {
         using (var context = new DbContext())
         {
            new SubTipeRepository(context).Insert(model);
         }
      }

      public void Update(ISubTipeModel model)
      {
         using (var context = new DbContext())
         {
            new SubTipeRepository(context).Update(model);
         }
      }

      public void Delete(ISubTipeModel model)
      {
         using (var context = new DbContext())
         {
            new SubTipeRepository(context).Delete(model);
         }
      }
      
      public IEnumerable<ISubTipeModel> GetAllSubTipe()
      {
         using (var context = new DbContext())
         {
            return new SubTipeRepository(context).GetAll();
         }
      }

      public ISubTipeModel GetSubTipeById(object id)
      {
         using (var context = new DbContext())
         {
            return new SubTipeRepository(context).GetById(id);
         }
      }
   }
}
