using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Satuan;

namespace RumahScarlett.Services.Services.Satuan
{
   public class SatuanServices : ISatuanServices
   {
      private IModelDataAnnotationCheck _modelDAC;
      private ISatuanRepository _repo;

      public SatuanServices(ISatuanRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(ISatuanModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(ISatuanModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(ISatuanModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<ISatuanModel> GetAll()
      {
         return _repo.GetAll();
      }

      public ISatuanModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(ISatuanModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
