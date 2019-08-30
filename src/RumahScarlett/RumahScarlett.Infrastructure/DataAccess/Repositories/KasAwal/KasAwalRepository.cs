using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.KasAwal;
using RumahScarlett.Services.Services.KasAwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.KasAwal
{
   public class KasAwalRepository : BaseRepository<IKasAwalModel>, IKasAwalRepository
   {
      public KasAwalRepository()
      {
         _modelName = "kas awal";
      }

      public void Insert(IKasAwalModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            ValidateModel(context, model, dataAccessStatus);

            Insert(model, () => context.Conn.Insert((KasAwalModel)model), dataAccessStatus,
                  () => CheckAfterInsert(context, "SELECT COUNT(1) FROM kas_awal WHERE tanggal=@tanggal "
                                         + "AND id=(SELECT LAST_INSERT_ID())",
                                         new { tanggal = model.tanggal.Date.ToString("yyyy-MM-dd") }));
         }
      }

      public void Update(IKasAwalModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Update(model, () => context.Conn.Update((KasAwalModel)model), dataAccessStatus,
                  () => CheckModelExist(context, "SELECT COUNT(1) FROM kas_awal WHERE id=@id",
                                       new { model.id }));
         }
      }

      public void Delete(IKasAwalModel model)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IKasAwalModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => context.Conn.GetAll<KasAwalModel>(), dataAccessStatus);
         }
      }

      public IKasAwalModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public IKasAwalModel GetByTanggal(object date)
      {
         var model = GetAll().Where(k => k.tanggal.Date == ((DateTime)date).Date).FirstOrDefault();

         if (model == null)
         {
            var kasAwal = new KasAwalModel
            {
               tanggal = ((DateTime)date).Date,
               total = 0
            };

            Insert(kasAwal);

            return kasAwal;
         }

         return model;
      }

      private void ValidateModel(DbContext context, IKasAwalModel model, DataAccessStatus dataAccessStatus)
      {
         var exists = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM kas_awal WHERE tanggal=@tanggal AND id!=@id",
                                                                 new { model.tanggal, model.id });

         if (exists)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = $"{_modelName.FirstToUpper()} tanggal {model.tanggal} sudah ada di database !!!";

            throw new DataAccessException(dataAccessStatus); ;
         }
      }
   }
}
