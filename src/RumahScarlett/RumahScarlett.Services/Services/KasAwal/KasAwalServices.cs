using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.KasAwal;

namespace RumahScarlett.Services.Services.KasAwal
{
   public class KasAwalServices : IKasAwalServices
   {
      private IKasAwalRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public KasAwalServices(IKasAwalRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IKasAwalModel model)
      {
         throw new NotImplementedException();
      }

      public void Update(IKasAwalModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IKasAwalModel model)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IKasAwalModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IKasAwalModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public IKasAwalModel GetByTanggal(object tanggal)
      {
         return _repo.GetByTanggal(tanggal);
      }

      public void ValidateModel(IKasAwalModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
