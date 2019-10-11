using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Role;

namespace RumahScarlett.Services.Services.Role
{
   public class RoleServices : IRoleServices
   {
      private IRoleRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public RoleServices(IRoleRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IRoleModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IRoleModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IRoleModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IRoleModel> GetAll()
      {
         return _repo.GetAll();
      }

      public IRoleModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(IRoleModel model)
      {
         _modelDAC.ValidateModel(model);
         _modelDAC.ValidateModels(model.RoleDetails);
      }
   }
}
