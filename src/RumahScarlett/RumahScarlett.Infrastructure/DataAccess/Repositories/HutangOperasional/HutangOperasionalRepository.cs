using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.HutangOperasional;
using RumahScarlett.Services.Services.HutangOperasional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.HutangOperasional
{
   public class HutangOperasionalRepository : BaseRepository<IHutangOperasionalModel>, IHutangOperasionalRepository
   {
      public HutangOperasionalRepository()
      {
         _modelName = "hutang operasional";
      }

      public void Insert(IHutangOperasionalModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Insert(model, () => context.Conn.Insert((HutangOperasionalModel)model), dataAccessStatus,
                  () => CheckAfterInsert(context, "SELECT COUNT(1) FROM hutang_operasional WHERE tanggal=@tanggal "
                                         + "AND id=(SELECT LAST_INSERT_ID())", new { model.tanggal }));
         }
      }

      public void Update(IHutangOperasionalModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Update(model, () => context.Conn.Update((HutangOperasionalModel)model), dataAccessStatus,
                  () => CheckModelExist(context, model.id));
         }
      }

      public void Delete(IHutangOperasionalModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            Delete(model, () => context.Conn.Delete((HutangOperasionalModel)model), dataAccessStatus,
               () => CheckModelExist(context, model.id));
         }
      }

      public IEnumerable<IHutangOperasionalModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetAll(() => context.Conn.GetAll<HutangOperasionalModel>(), dataAccessStatus);
         }
      }

      public IHutangOperasionalModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         using (var context = new DbContext())
         {
            return GetBy(() => context.Conn.Get<HutangOperasionalModel>(id), dataAccessStatus,
                        () => CheckModelExist(context, id));
         }
      }

      private bool CheckModelExist(DbContext context, object id)
      {
         return CheckModelExist(context, "SELECT COUNT(1) FROM hutang_operasional WHERE id=@id",
                                new { id });
      }
   }
}
