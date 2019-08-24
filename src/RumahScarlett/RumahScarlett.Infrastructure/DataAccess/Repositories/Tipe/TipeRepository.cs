using RumahScarlett.Services.Services.Tipe;
using RumahScarlett.Domain.Models.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using Dapper;
using MySql.Data.MySqlClient;
using RumahScarlett.Services.CommonServices;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   public class TipeRepository : BaseRepository<ITipeModel>, ITipeRepository
   {
      private DbContext _context;

      public TipeRepository()
      {
         _context = new DbContext();
         _modelName = "tipe";
      }

      public void Insert(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Insert(model, () => _context.Conn.Insert((TipeModel)model), dataAccessStatus, 
                () => CheckInsert(model));
      }

      public void Update(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Update(model, () => _context.Conn.Update((TipeModel)model), dataAccessStatus, 
                () => CheckUpdateDelete(model));
      }

      public void Delete(ITipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         
         Delete(model, () => _context.Conn.Delete((TipeModel)model), dataAccessStatus, 
                () => CheckUpdateDelete(model));
      }

      public IEnumerable<ITipeModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();
         
         return GetAll(() =>
         {
            var listObj = _context.Conn.GetAll<TipeModel>().ToList();

            if (listObj != null)
            {
               listObj = listObj.Map(
                  t => t.SubTipes = new SubTipeRepository().GetAll(t.id)
                  ).ToList();
            }

            return listObj;
         }, dataAccessStatus);
      }

      public ITipeModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();
         
         return GetBy(() => _context.Conn.Get<TipeModel>(id), dataAccessStatus);
      }

      private void ValidateModel(ITipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE nama=@nama AND id!=@id",
                                                             new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(ITipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(ITipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM tipe WHERE id=@id",
                                                  new { model.id });
      }
   }
}
