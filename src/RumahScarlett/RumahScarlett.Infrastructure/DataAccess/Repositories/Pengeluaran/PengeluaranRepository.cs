using RumahScarlett.Services.Services.Pengeluaran;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Pengeluaran;
using RumahScarlett.CommonComponents;
using Dapper;
using Dapper.Contrib.Extensions;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Pengeluaran
{
   public class PengeluaranRepository : BaseRepository<IPengeluaranModel>, IPengeluaranRepository
   {
      private DbContext _context;

      public PengeluaranRepository()
      {
         _context = new DbContext();
         _modelName = "pengeluaran";
      }

      public void Insert(IPengeluaranModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         model.tanggal = DateTime.Now;

         Insert(model, () => _context.Conn.Insert((PengeluaranModel)model), dataAccessStatus,
               () => CheckInsert(model));
      }

      public void Update(IPengeluaranModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPengeluaranModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () => _context.Conn.Delete((PengeluaranModel)model), dataAccessStatus,
               () => CheckUpdateDelete(model));
      }

      public IEnumerable<IPengeluaranModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IPengeluaranModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object date)
      {
         date = ((DateTime)date).ToMysqlDateFormat();

         var queryStr = StringHelper.QueryStringByDate("pengeluaran", "tanggal");

         return _context.Conn.Query<PengeluaranModel>(queryStr, new { date });
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object startDate, object endDate)
      {
         startDate = ((DateTime)startDate).ToMysqlDateFormat();
         endDate = ((DateTime)endDate).ToMysqlDateFormat();

         var queryStr = StringHelper.QueryStringByBetweenDate("pengeluaran", "tanggal");

         return _context.Conn.Query<PengeluaranModel>(queryStr, new { startDate, endDate });
      }

      private bool CheckInsert(IPengeluaranModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pengeluaran WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(IPengeluaranModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM pengeluaran WHERE id=@id",
                                                  new { model.id });
      }
   }
}
