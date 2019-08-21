using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Tipe;

namespace RumahScarlett.Services.Services.Tipe
{
   public class SubTipeServices : ISubTipeServices
   {
      private ISubTipeRepository _subTipeRepository;
      private IModelDataAnnotationCheck _modelDataAnnotationCheck;

      public SubTipeServices(ISubTipeRepository subTipeRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
      {
         _subTipeRepository = subTipeRepository;
         _modelDataAnnotationCheck = modelDataAnnotationCheck;
      }

      public void Insert(ISubTipeModel model)
      {
         ValidateModel(model);
         _subTipeRepository.Insert(model);
      }

      public void Update(ISubTipeModel model)
      {
         ValidateModel(model);
         _subTipeRepository.Update(model);
      }

      public void Delete(ISubTipeModel model)
      {
         _subTipeRepository.Delete(model);
      }

      public IEnumerable<ISubTipeModel> GetAll()
      {
         return _subTipeRepository.GetAll();
      }

      public ISubTipeModel GetById(object id)
      {
         return _subTipeRepository.GetById(id);
      }

      public void ValidateModel(ISubTipeModel model)
      {
         _modelDataAnnotationCheck.ValidateModel(model);
      }
   }
}
