using Dapper;
using Dapper.Contrib.Extensions;
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Infrastructure.DataAccess.Repositories.PenyesuaianStok;
using RumahScarlett.Services.Services.Barang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Barang
{
   public class BarangRepository : BaseRepository<IBarangModel>, IBarangRepository
   {
      private DbContext _context;

      public BarangRepository()
      {
         _context = new DbContext();
         _modelName = "barang";
      }

      public void Insert(IBarangModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Insert(model, () => _context.Conn.Insert((BarangModel)model), dataAccessStatus,
                () => CheckInsert(model));
      }

      public void Update(IBarangModel model)
      {
         var dataAccessStatus = new DataAccessStatus();
         ValidateModel(model, dataAccessStatus);

         Update(model, () => _context.Conn.Update((BarangModel)model), dataAccessStatus,
                () => CheckUpdateDelete(model));
      }

      public void Delete(IBarangModel model)
      {
         var dataAccessStatus = new DataAccessStatus();

         Delete(model, () => _context.Conn.Delete((BarangModel)model), dataAccessStatus,
                () => CheckUpdateDelete(model));
      }

      public IEnumerable<IBarangModel> GetAll()
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetAll(() =>
         {            
            var listBarangs = _context.Conn.GetAll<BarangModel>().ToList();

            if (listBarangs.Count > 0)
            {
               listBarangs = listBarangs.Map(b => b.penyesuaian_stok_qty = new PenyesuaianStokDetailRepository(_context).GetQtyCount(b.id)).ToList();
            }

            return listBarangs;
         }, dataAccessStatus);
      }

      public IBarangModel GetById(object id)
      {
         var dataAccessStatus = new DataAccessStatus();

         return GetBy(() => _context.Conn.Get<BarangModel>(id), dataAccessStatus);
      }
      
      private void ValidateModel(IBarangModel model, DataAccessStatus dataAccessStatus)
      {
         var existsKode = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE kode=@kode AND id!=@id",
                                                            new { model.kode, model.id });

         if (existsKode)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("kode", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }

         var existsNama = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE nama=@nama AND id!=@id",
                                                            new { model.nama, model.id });

         if (existsNama)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = StringHelper.DuplicateEntry("nama", _modelName);

            throw new DataAccessException(dataAccessStatus); ;
         }
      }

      private bool CheckInsert(IBarangModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE kode=@kode "
                                                  + "AND id=(SELECT LAST_INSERT_ID())",
                                                  new { model.kode });
      }

      private bool CheckUpdateDelete(IBarangModel model)
      {
         return _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) FROM barang WHERE id=@id",
                                                  new { model.id });
      }
   }
}
