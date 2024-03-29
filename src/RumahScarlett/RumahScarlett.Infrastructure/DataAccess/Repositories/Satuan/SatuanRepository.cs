﻿using RumahScarlett.Services.Services.Satuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.CommonComponents;
using Dapper;
using Dapper.Contrib.Extensions;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Satuan
{
   public class SatuanRepository : BaseRepository<ISatuanModel>, ISatuanRepository
   {
      public SatuanRepository()
      {
         _modelName = "satuan";
      }

      public void Insert(ISatuanModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((SatuanModel)model), dataAccessStatus,
                  () => CheckAfterInsert(context, "SELECT COUNT(1) FROM satuan WHERE nama=@nama "
                                         + "AND id=(SELECT LAST_INSERT_ID())", new { model.nama }));
         }
      }

      public void Update(ISatuanModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((SatuanModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public void Delete(ISatuanModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((SatuanModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<ISatuanModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => { return context.Conn.GetAll<SatuanModel>().ToList(); }, dataAccessStatus);
         }
      }

      public ISatuanModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<SatuanModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      private void ValidateModel(DbContext context, ISatuanModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM satuan WHERE nama=@nama AND id!=@id",
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
         return CheckModelExist(context, "SELECT COUNT(1) FROM satuan WHERE id=@id",
                                new { id });
      }
   }
}
