using RumahScarlett.Domain.Models.Tipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Tipe
{
   public class TipeServices : IBaseServices<ITipeModel>, ITipeServices
   {
      private ITipeRepository _tipeRepository;
      private IModelDataAnnotationCheck _modelDataAnnotationCheck;

      public TipeServices(ITipeRepository tipeRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
      {
         _tipeRepository = tipeRepository;
         _modelDataAnnotationCheck = modelDataAnnotationCheck;
      }

      public void Create(ITipeModel model)
      {
         _tipeRepository.Create(model);
      }

      public void Update(ITipeModel model)
      {
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
