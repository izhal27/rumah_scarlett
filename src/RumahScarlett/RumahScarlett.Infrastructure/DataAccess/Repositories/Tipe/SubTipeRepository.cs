﻿using RumahScarlett.Services.Services.Tipe;
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
   public class SubTipeRepository : BaseRepository<ISubTipeModel>, ISubTipeRepository
   {
      private DbContext _context;
      protected new static string _modelName = "sub tipe";

      public SubTipeRepository()
      {
         _context = new DbContext();
      }

      public void Insert(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Insert(model, () => _context.Conn.Insert((SubTipeModel)model), dataAccessStatus,
                () => CheckInsert(model));
      }

      public void Update(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Update(model, () => _context.Conn.Update((SubTipeModel)model), dataAccessStatus,
                () => CheckUpdateDelete(model));
      }

      public void Delete(ISubTipeModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () => _context.Conn.Delete((TipeModel)model), dataAccessStatus,
                () => CheckUpdateDelete(model));
      }

      public IEnumerable<ISubTipeModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            var queryStr = "SELECT s.*, t.* FROM sub_tipe s " +
                           "INNER JOIN tipe t ON s.tipe_id = t.id";

            return _context.Conn.Query<SubTipeModel, TipeModel, SubTipeModel>(queryStr, (s, t) =>
               {
                  if (t != null)
                  {
                     s.Tipe = t;
                  }

                  return s;
               }, splitOn: "id").ToList();
         }, dataAccessStatus);
      }

      public IEnumerable<ISubTipeModel> GetAll(object tipeId)
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {
            var queryStr = "SELECT s.*, t.* FROM sub_tipe s " +
                           "INNER JOIN tipe t ON s.tipe_id = t.id " +
                           "WHERE t.id=@id";

            return _context.Conn.Query<SubTipeModel, TipeModel, SubTipeModel>(queryStr, (s, t) =>
            {
               if (t != null)
               {
                  s.Tipe = t;
               }

               return s;
            }, new { id = tipeId }, splitOn: "id").ToList();
         }, dataAccessStatus);
      }

      public ISubTipeModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetBy(() =>
         {
            var queryStr = "SELECT s.*, t.* FROM sub_tipe s " +
                           "INNER JOIN tipe t ON s.tipe_id = t.id " +
                           "WHERE s.id=@id";

            return _context.Conn.Query<SubTipeModel, TipeModel, SubTipeModel>(queryStr, (s, t) =>
            {
               if (t != null)
               {
                  s.Tipe = t;
               }

               return s;
            }, new { id } , splitOn: "id").FirstOrDefault();
         }, dataAccessStatus);
      }


      private void ValidateModel(ISubTipeModel model, DataAccessStatus dataAccessStatus)
      {
         var existsNama = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama AND id!=@id",
                                                            new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus);
         }
      }

      private bool CheckInsert(ISubTipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE nama=@nama "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.nama });
      }

      private bool CheckUpdateDelete(ISubTipeModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM sub_tipe WHERE id=@id",
                                                  new { model.id });
      }
   }
}
