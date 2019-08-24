using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services
{
   public interface IBaseRepositoryGetByDate<TDomainModel> : IBaseRepository<TDomainModel> where TDomainModel : class
   {
      IEnumerable<TDomainModel> GetByDate(object date);
      IEnumerable<TDomainModel> GetByDate(object startDate, object endDate);
   }
}
