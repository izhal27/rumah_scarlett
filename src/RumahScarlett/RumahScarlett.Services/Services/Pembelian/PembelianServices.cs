using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Pembelian;

namespace RumahScarlett.Services.Services.Pembelian
{
   public class PembelianServices : IPembelianServices
   {
      private IPembelianRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public PembelianServices(IPembelianRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IPembelianModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IPembelianModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPembelianModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IPembelianModel> GetAll()
      {
         return _repo.GetAll();
      }

      public IEnumerable<IPembelianModel> GetByDate(object date)
      {
         return _repo.GetByDate(date);
      }

      public IEnumerable<IPembelianModel> GetByDate(object startDate, object endDate)
      {
         return _repo.GetByDate(startDate, endDate);
      }

      public IPembelianModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public void ValidateModel(IPembelianModel model)
      {
         _modelDAC.ValidateModel(model);
         _modelDAC.ValidateModels(model.PembelianDetails);
      }
   }
}
