using RumahScarlett.Domain.Models.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Pembelian
{
   public class PembelianReturnServices : IPembelianReturnServices
   {
      private IPembelianReturnRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public PembelianReturnServices(IPembelianReturnRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IPembelianReturnModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IPembelianReturnModel model)
      {
         throw new NotImplementedException();
      }
      
      public void Delete(IPembelianReturnModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IPembelianReturnModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPembelianReturnModel> GetByDate(object date)
      {
         return _repo.GetByDate(date);
      }

      public IEnumerable<IPembelianReturnModel> GetByDate(object startDate, object endDate)
      {
         return _repo.GetByDate(startDate, endDate);
      }

      public IPembelianReturnModel GetById(object id)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<IPembelianReturnReportModel> GetReportByDate(object date)
      {
         return _repo.GetReportByDate(date);
      }

      public IEnumerable<IPembelianReturnReportModel> GetReportByDate(object startDate, object endDate)
      {
         return _repo.GetReportByDate(startDate, endDate);
      }

      public void ValidateModel(IPembelianReturnModel model)
      {
         _modelDAC.ValidateModel(model);
         _modelDAC.ValidateModels(model.PembelianReturnDetails);
      }
   }
}
