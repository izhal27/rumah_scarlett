﻿using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.User;
using RumahScarlett.Services.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.User
{
   public class UserRepository : BaseRepository<IUserModel>, IUserRepository
   {
      public UserRepository()
      {
         _modelName = "user";
      }

      public void Insert(IUserModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((UserModel)model), dataAccessStatus,
                  () => CheckAfterInsert(context, "SELECT COUNT(1) FROM user WHERE login_id = @login_id "
                                         + "AND id = (SELECT LAST_INSERT_ID())",
                                         new { model.login_id }));
         }
      }

      public void Update(IUserModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((UserModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public void Delete(IUserModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((UserModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IUserModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => context.Conn.GetAll<UserModel>(), dataAccessStatus);
         }
      }

      public IUserModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<UserModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      private void ValidateModel(DbContext context, IUserModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM user WHERE login_id = @login_id AND id != @id",
                                                             new { model.login_id, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("login id", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM user WHERE id = @id", new { id });
      }
   }
}