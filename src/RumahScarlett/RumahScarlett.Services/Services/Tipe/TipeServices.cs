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
      private ITipeRepository _tipeRepository;
      private IModelDataAnnotationCheck _modelDataAnnotationCheck;

      public TipeServices(ITipeRepository tipeRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
      {
         _tipeRepository = tipeRepository;
         _modelDataAnnotationCheck = modelDataAnnotationCheck;
      }

      public void Insert(ITipeModel model)
      {
         ValidateModel(model);
         _tipeRepository.Insert(model);
      }

      public void Update(ITipeModel model)
      {
         ValidateModel(model);
         _tipeRepository.Update(model);
      }

      public void Delete(ITipeModel model)
      {
         _tipeRepository.Delete(model);
      }

      public IEnumerable<ITipeModel> GetAll()
      {
         return _tipeRepository.GetAll();
      }

      public ITipeModel GetById(object id)
      {
         return _tipeRepository.GetById(id);
      }

      public void ValidateModel(ITipeModel model)
      {
         _modelDataAnnotationCheck.ValidateModel(model);
      }      
   }
}
