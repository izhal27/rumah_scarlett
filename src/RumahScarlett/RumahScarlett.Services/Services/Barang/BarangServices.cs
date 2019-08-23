using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Barang;

namespace RumahScarlett.Services.Services.Barang
{
   public class BarangServices : IBarangServices
   {
      private IBarangRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public BarangServices(IBarangRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IBarangModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IBarangModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IBarangModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IBarangModel> GetAll()
      {
         return _repo.GetAll();
      }

      public IBarangModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(IBarangModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
