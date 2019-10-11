using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Role;
using RumahScarlett.Services.Services.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Role
{
   public class FormActionRepository : BaseRepository<IFormActionModel>, IFormActionRepository
   {
      public FormActionRepository()
      {
         _modelName = "form action";
      }

      public void Insert(IFormActionModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            using (var context = new DbContext())
            {
               ValidateModel(context, model, dataAccessStatus);

               context.Conn.Insert((FormActionModel)model);
            }
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Insert);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public void Update(IFormActionModel model)
      {
         throw new NotImplementedException();
      }
      public void Delete(IFormActionModel model)
      {
         throw new NotImplementedException();
      }

      public void DeleteAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            using (var context = new DbContext())
            {
               context.Conn.DeleteAll<FormActionModel>();
            }
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Insert);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public IEnumerable<IFormActionModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IFormActionModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      private void ValidateModel(DbContext context, IFormActionModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM form_action WHERE form_name = @form_name",
                                                             new { model.form_name });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("form name", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }
   }
}
