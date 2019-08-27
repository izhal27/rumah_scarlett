using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe
{
   internal interface ISubTipeRepository
   {
      void Insert(ISubTipeModel model);
      void Update(ISubTipeModel model);
      void Delete(ISubTipeModel model);
      IEnumerable<ISubTipeModel> GetAll();
      IEnumerable<ISubTipeModel> GetAll(ITipeModel pembelian);
      ISubTipeModel GetById(object id);
   }

   internal class SubTipeRepository : BaseRepository<ISubTipeModel>, ISubTipeRepository
   {
      private DbContext _context;

      public SubTipeRepository(DbContext context)
      {
         _context = context;
         _modelName = "sub tipe";
      }

      public void Insert(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         ValidateModel(_context, model, dataAccessStatus);

         Insert(model, () => _context.Conn.Insert((SubTipeModel)model), dataAccessStatus,
                () => CheckInsert(_context, model));
      }

      public void Update(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         ValidateModel(_context, model, dataAccessStatus);

         Update(model, () => _context.Conn.Update((SubTipeModel)model), dataAccessStatus,
                () => CheckUpdateDelete(_context, model));
      }

      public void Delete(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () => _context.Conn.Delete((TipeModel)model), dataAccessStatus,
             () => CheckUpdateDelete(_context, model));
      }
      
      public IEnumerable<ISubTipeModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() => { return _context.Conn.GetAll<SubTipeModel>(); }, dataAccessStatus);
      }

      public IEnumerable<ISubTipeModel> GetAll(ITipeModel tipe)
      {
         return GetAll().Where(s => s.tipe_id == tipe.id);
      }

      public ISubTipeModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();
         
         return GetBy(() => { return _context.Conn.Get<SubTipeModel>(id); }, dataAccessStatus);
      }
      
      private void ValidateModel(DbContext context, ISubTipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama AND id!=@id",
                                                            new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus);
         }
      }

      private bool CheckInsert(DbContext context, ISubTipeModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(DbContext context, ISubTipeModel model)
      {
         return context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE id=@id",
                                                  new { model.id });
      }
   }
}
