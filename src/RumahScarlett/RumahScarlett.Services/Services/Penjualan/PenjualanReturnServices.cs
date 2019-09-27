using RumahScarlett.Domain.Models.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Penjualan
{
   public class PenjualanReturnServices : IPenjualanReturnServices
   {
      private IPenjualanReturnRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public PenjualanReturnServices(IPenjualanReturnRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IPenjualanReturnModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IPenjualanReturnModel model)
      {
         throw new NotImplementedException();
      }
      
      public void Delete(IPenjualanReturnModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IPenjualanReturnModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPenjualanReturnModel> GetByDate(object date)
      {
         return _repo.GetByDate(date);
      }

      public IEnumerable<IPenjualanReturnModel> GetByDate(object startDate, object endDate)
      {
         return _repo.GetByDate(startDate, endDate);
      }

      public IPenjualanReturnModel GetById(object id)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<IPenjualanReturnReportModel> GetReportByDate(object date)
      {
         return _repo.GetReportByDate(date);
      }

      public IEnumerable<IPenjualanReturnReportModel> GetReportByDate(object startDate, object endDate)
      {
         return _repo.GetReportByDate(startDate, endDate);
      }

      public void ValidateModel(IPenjualanReturnModel model)
      {
         _modelDAC.ValidateModel(model);
         _modelDAC.ValidateModels(model.PenjualanReturnDetails);
      }
   }
}
