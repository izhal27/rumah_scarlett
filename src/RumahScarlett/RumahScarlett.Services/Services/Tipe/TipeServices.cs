using RumahScarlett.Domain.Models.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Tipe
{
   public class TipeServices : ITipeServices
   {
      private ITipeRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public TipeServices(ITipeRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(ITipeModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(ITipeModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(ITipeModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<ITipeModel> GetAll()
      {
         return _repo.GetAll();
      }

      public ITipeModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(ITipeModel model)
      {
         _modelDAC.ValidateModel(model);
      }      
   }
}
