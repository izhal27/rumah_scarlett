using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pengeluaran;
using RumahScarlett.Services.Services.Pengeluaran;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pengeluaran
{
   public class PengeluaranRepository : BaseRepository<IPengeluaranModel>, IPengeluaranRepository
   {
      public PengeluaranRepository()
      {
         _modelName = "pengeluaran";
      }

      public void Insert(IPengeluaranModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            model.tanggal = DateTime.Now;

            Insert(model, () => context.Conn.Insert((PengeluaranModel)model), dataAccessStatus,
                  () => CheckAfterInsert(context, "SELECT COUNT(1) FROM pengeluaran WHERE nama=@nama "
                                         + "AND id=(SELECT LAST_INSERT_ID())", new { model.nama }));
         }
      }

      public void Update(IPengeluaranModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Update(model, () => context.Conn.Update((PengeluaranModel)model), dataAccessStatus,
                   () => CheckModelExist(context, model.id));
         }
      }

      public void Delete(IPengeluaranModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((PengeluaranModel)model), dataAccessStatus,
               () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IPengeluaranModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IPengeluaranModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<PengeluaranModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object date)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return context.Conn.Query<PengeluaranModel>(StringHelper.QueryStringByDate(_modelName), new { date });
         }
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object startDate, object endDate)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return context.Conn.Query<PengeluaranModel>(StringHelper.QueryStringByBetweenDate(_modelName), new { startDate, endDate });
         }
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM pengeluaran WHERE id=@id",
                                new { id });
      }
   }
}
