using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Services.Services.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Infrastructure.DataAccess.Repositories.Penjualan
{
   public class PenjualanReturnRepository : BaseRepository<IPenjualanReturnModel>, IPenjualanReturnRepository
   {
      public PenjualanReturnRepository()
      {
         _modelName = "return penjualan";
      }
      
      public void Insert(IPenjualanReturnModel model)
      {
         throw new NotImplementedException();
      }

      public void Update(IPenjualanReturnModel model)
      {
         throw new NotImplementedException();
      }

      public void Delete(IPenjualanReturnModel model)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPenjualanReturnModel> GetAll()
      {
         throw new NotImplementedException();
      }

      public IPenjualanReturnModel GetById(object id)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPenjualanReturnModel> GetByDate(object date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<IPenjualanReturnModel> GetByDate(object startDate, object endDate)
      {
         throw new NotImplementedException();
      }
   }
}
