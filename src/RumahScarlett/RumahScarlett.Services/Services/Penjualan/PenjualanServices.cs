using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Penjualan;

namespace RumahScarlett.Services.Services.Penjualan
{
   public class PenjualanServices : IPenjualanServices
   {
      private IPenjualanRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public PenjualanServices(IPenjualanRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IPenjualanModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IPenjualanModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPenjualanModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IPenjualanModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPenjualanModel> GetByDate(object date)
      {
         return _repo.GetByDate(date);
      }

      public IEnumerable<IPenjualanModel> GetByDate(object startDate, object endDate)
      {
         return _repo.GetByDate(startDate, endDate);
      }

      public IPenjualanModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(IPenjualanModel model)
      {
         _modelDAC.ValidateModel(model);
         _modelDAC.ValidateModels(model.PenjualanDetails);
      }
   }
}
