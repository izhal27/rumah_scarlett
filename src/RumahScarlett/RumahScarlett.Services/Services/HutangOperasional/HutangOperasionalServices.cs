using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.HutangOperasional;

namespace RumahScarlett.Services.Services.HutangOperasional
{
   public class HutangOperasionalServices : IHutangOperasionalServices
   {
      private IHutangOperasionalRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public HutangOperasionalServices(IHutangOperasionalRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IHutangOperasionalModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IHutangOperasionalModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IHutangOperasionalModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IHutangOperasionalModel> GetAll()
      {
         return _repo.GetAll();
      }

      public IHutangOperasionalModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(IHutangOperasionalModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
