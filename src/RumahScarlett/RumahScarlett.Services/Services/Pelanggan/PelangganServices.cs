using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Pelanggan;

namespace RumahScarlett.Services.Services.Pelanggan
{
   public class PelangganServices : IPelangganServices
   {
      private IPelangganRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public PelangganServices(IPelangganRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IPelangganModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IPelangganModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IPelangganModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IPelangganModel> GetAll()
      {
         return _repo.GetAll();
      }

      public IPelangganModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(IPelangganModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
