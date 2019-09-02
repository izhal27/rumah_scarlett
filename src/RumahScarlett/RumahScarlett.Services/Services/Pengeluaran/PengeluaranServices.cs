using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.Pengeluaran;

namespace RumahScarlett.Services.Services.Pengeluaran
{
   public class PengeluaranServices : IPengeluaranServices
   {
      private IPengeluaranRepository _repo;
      private IModelDataAnnotationCheck _modelDAC;

      public PengeluaranServices(IPengeluaranRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IPengeluaranModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IPengeluaranModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IPengeluaranModel model)
      {
         _repo.Delete(model);
      }

      public IEnumerable<IPengeluaranModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IPengeluaranModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object date)
      {
         return _repo.GetByDate(date);
      }

      public IEnumerable<IPengeluaranModel> GetByDate(object startDate, object endDate)
      {
         return _repo.GetByDate(startDate, endDate);
      }

      public void ValidateModel(IPengeluaranModel model)
      {
         _modelDAC.ValidateModel(model);
      }

   }
}
