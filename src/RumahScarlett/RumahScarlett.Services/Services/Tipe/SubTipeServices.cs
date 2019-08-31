using RumahScarlett.Domain.Models.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Tipe
{
   public class SubTipeServices : ISubTipeServices
   {
      private ISubTipeRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public SubTipeServices(ISubTipeRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(ISubTipeModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(ISubTipeModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(ISubTipeModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<ISubTipeModel> GetAll()
      {
         return _repo.GetAll();
      }

      public ISubTipeModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(ISubTipeModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
