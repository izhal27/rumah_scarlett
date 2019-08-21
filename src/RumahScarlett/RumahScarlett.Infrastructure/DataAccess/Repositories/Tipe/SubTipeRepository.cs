using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.CommonComponents;
using Dapper;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   public class SubTipeRepository : BaseRepositories<ISubTipeModel>, ISubTipeRepository
   {
      private DbContext _context;
      protected new static string _modelName = "sub tipe";

      public SubTipeRepository(string connStr)
      {
         _context = new DbContext(connStr);
      }

      public void Insert(ISubTipeModel model)
      {

      }

      public void Update(ISubTipeModel model)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         ValidateModel(model, dataAccessStatus);

         try
         {
            RecordExistsCheck((SubTipeModel)model,
                              TypeOfExistenceCheck.DoesExistInDB, RequestType.Update,
                              checkUpdateDelete: CheckUpdateDelete(model));
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.CustomMessage = $"{_modelName.FirstToUpper()} tidak dapat diubah, dikarenakan data {_modelName} " +
                                                     "tidak ditemukan di database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }

         try
         {
            _context.Conn.Update((TipeModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: $"Terjadi kesalahan saat menyimpan data {_modelName}.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public void Delete(ISubTipeModel model)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ISubTipeModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public ISubTipeModel GetById(object id)
      {
         throw new NotImplementedException();
      }


      private void ValidateModel(ISubTipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama AND id!=@id",
                                                                 new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(ISubTipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama",
                                                   new { model.nama });
      }

      private bool CheckUpdateDelete(ISubTipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE id=@id",
                                                  new { model.id });
      }
   }
}
