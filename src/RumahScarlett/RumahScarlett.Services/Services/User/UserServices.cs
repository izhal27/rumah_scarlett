using RumahScarlett.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.User
{
   public class UserServices : IUserServices
   {
      private IUserRepository _repo;
      private IModelDataAnnotationCheck _moelDAC;

      public UserServices(IUserRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _moelDAC = modelDAC;
      }

      public void Insert(IUserModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IUserModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IUserModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IUserModel> GetAll()
      {
         return _repo.GetAll();
      }

      public IUserModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(IUserModel model)
      {
         _moelDAC.ValidateModel(model);
      }
   }
}
