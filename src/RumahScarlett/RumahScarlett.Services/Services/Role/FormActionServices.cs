using RumahScarlett.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Role
{
   public class FormActionServices : IFormActionServices
   {
      private IFormActionRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public FormActionServices(IFormActionRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IFormActionModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IFormActionModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IFormActionModel model)
      {
         throw new NotImplementedException();
      }

      public void DeleteAll()
      {
         _repo.DeleteAll();
      }

      public IEnumerable<IFormActionModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IFormActionModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public void ValidateModel(IFormActionModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
