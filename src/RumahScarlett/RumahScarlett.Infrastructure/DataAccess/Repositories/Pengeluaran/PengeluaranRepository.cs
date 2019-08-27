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
                  () => CheckInsert(context, model));
         }
      }

      public void Update(IPengeluaranModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPengeluaranModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((PengeluaranModel)model), dataAccessStatus,
               () => CheckUpdateDelete(context, model));
         }
      }

      public IEnumerable<IPengeluaranModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => context.Conn.GetAll<PengeluaranModel>(), dataAccessStatus);
         }
      }

      public IPengeluaranModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object date)
      {
         return GetAll().Where(p => p.tanggal.Date == ((DateTime)date).Date);
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object startDate, object endDate)
      {
         return GetAll().Where(p => p.tanggal.Date >= ((DateTime)startDate).Date && p.tanggal.Date <= ((DateTime)endDate).Date);
      }

      private bool CheckInsert(DbContext context, IPengeluaranModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pengeluaran WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(DbContext context, IPengeluaranModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pengeluaran WHERE id=@id",
                                                  new { model.id });
      }
   }
}
