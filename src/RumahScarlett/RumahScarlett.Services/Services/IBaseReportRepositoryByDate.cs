using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services
{
   public interface IBaseReportRepositoryByDate<TDomainModel> where TDomainModel : class
   {
      IEnumerable<TDomainModel> GetReportByDate(object date);
      IEnumerable<TDomainModel> GetReportByDate(object startDate, object endDate);
   }
}
