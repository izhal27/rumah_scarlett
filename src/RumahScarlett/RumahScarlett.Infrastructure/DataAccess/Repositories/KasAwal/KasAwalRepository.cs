using RumahScarlett.Services.Services.KasAwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.KasAwal;
using RumahScarlett.CommonComponents;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.KasAwal
{
   public class KasAwalRepository : BaseRepository<IKasAwalModel>, IKasAwalRepository
   {
      private DbContext _context;

      public KasAwalRepository()
      {
         _context = new DbContext();
         _modelName = "kas awal";
      }

      public void Insert(IKasAwalModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         try
         {
            _context.Conn.Insert((KasAwalModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Insert);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         try
         {
            RecordExistsCheck(model, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmInsert,
                              checkInsert: CheckInsert(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.AfterInsert);
            throw ex;
         }
      }

      public void Update(IKasAwalModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((KasAwalModel)model,
                              TypeOfExistenceCheck.DoesExistInDB, RequestType.Update,
                              checkUpdateDelete: CheckUpdateDelete(model));
         }
         catch (DataAccessException ex)
         {
            SetDataAccessValues(ex, ErrorMessageType.ModelNotFound);
            throw ex;
         }

         try
         {
            _context.Conn.Update((KasAwalModel)model);
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.Update);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }
      }

      public void Delete(IKasAwalModel model)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IKasAwalModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IKasAwalModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public IKasAwalModel GetByTanggal(object tanggal)
      {
         KasAwalModel model = null;
         var dataAccessStatus = new DataAccessStatus();
         var queryStr = "SELECT * FROM kas_awal WHERE tanggal=@tanggal";
         var tanggalFix = ((DateTime)tanggal).ToString("yyyy-MM-dd");

         try
         {
            model = _context.Conn.Query<KasAwalModel>(queryStr, new { tanggal = tanggalFix }).FirstOrDefault();
         }
         catch (MySqlException ex)
         {
            dataAccessStatus = SetDataAccessValues(ex, ErrorMessageType.GetById);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         if (model == null)
         {
            var kasAwal = new KasAwalModel
            {
               tanggal = ((DateTime)tanggal).Date,
               total = 0
            };

            Insert(kasAwal);

            return kasAwal;
         }

         return model;
      }

      private void ValidateModel(IKasAwalModel model, DataAccessStatus dataAccessStatus)
      {
         var exists = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM kas_awal WHERE tanggal=@tanggal AND id!=@id",
                                                                 new { model.tanggal, model.id });

         if (exists)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = $"{_modelName.FirstToUpper()} tanggal {model.tanggal} sudah ada di database !!!";

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(IKasAwalModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM kas_awal WHERE tanggal=@tanggal "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { tanggal = model.tanggal.Date.ToString("yyyy-MM-dd") });
      }

      private bool CheckUpdateDelete(IKasAwalModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM kas_awal WHERE id=@id",
                                                  new { model.id });
      }
   }
}
