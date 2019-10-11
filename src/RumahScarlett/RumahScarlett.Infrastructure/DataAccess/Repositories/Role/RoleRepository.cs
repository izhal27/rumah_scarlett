using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.Services.Services.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Role;
using RumahScarlett.CommonComponents;
using MySql.Data.MySqlClient;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Role
{
   public class RoleRepository : BaseRepository<IRoleModel>, IRoleRepository
   {
      public RoleRepository()
      {
         _modelName = "role";
      }

      public void Insert(IRoleModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((RoleModel)model), dataAccessStatus,
                  () => CheckAfterInsert(context, "SELECT COUNT(1) FROM role WHERE kode = @kode "
                                         + "AND id=(SELECT LAST_INSERT_ID())",
                                         new { model.kode }));
         }
      }

      public void Update(IRoleModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Update(model, () => context.Conn.Update((RoleModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public void Delete(IRoleModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((RoleModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IRoleModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => context.Conn.GetAll<RoleModel>(), dataAccessStatus);
         }
      }

      public IRoleModel GetById(object id)
      {
         using (var context = new DbContext())
         {
            var model = context.Conn.Get<RoleModel>(id);

            if (model != null)
            {
               var queryStr = "SELECT * FROM role_detail WHERE role_kode = @kode";
               var roleDetails = context.Conn.Query<RoleDetailModel>(queryStr, new { model.kode });

               if (roleDetails != null && roleDetails.ToList().Count > 0)
               {
                  model.RoleDetails = roleDetails;
               }
            }

            return model;
         }
      }

      public void Update(IRoleDetailModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            using (var context = new DbContext())
            {
               context.BeginTransaction();

               var queryStr = "DELETE FROM role_detail WHERE role_kode = @role_kode AND menu_name = @menu_name";
               context.Conn.Query<int>(queryStr, new
               {
                  model.role_kode,
                  model.menu_name
               });

               queryStr = "INSERT INTO role_detail (role_kode, menu_name, menu_parent, form_action, tag) "
                              + "VALUES (@role_kode, @menu_name, @menu_parent, @form_action, @tag)";
               context.Conn.Query<int>(queryStr, new
               {
                  model.role_kode,
                  model.menu_name,
                  model.menu_parent,
                  model.form_action,
                  model.tag
               });

               context.Commit();
            }
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Update);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      private void ValidateModel(DbContext context, IRoleModel model, DataAccessStatus dataAccessStatus)
      {
         var existsKode = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM role WHERE kode = @kode AND id != @id",
                                                             new { model.kode, model.id });

         if (existsKode)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("kode", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM role WHERE id = @id",
                                                  new { id });
      }
   }
}
