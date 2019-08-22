using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Supplier;

namespace RumahScarlett.Services.Services.Supplier
{
   public class SupplierServices : ISupplierServices
   {
      private ISupplierRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public SupplierServices(ISupplierRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(ISupplierModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(ISupplierModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(ISupplierModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<ISupplierModel> GetAll()
      {
         return _repo.GetAll();
      }

      public ISupplierModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(ISupplierModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
