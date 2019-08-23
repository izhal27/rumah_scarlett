using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services
{
   /// <summary>
   /// Base of model services
   /// </summary>
   /// <typeparam name="TDomainModel">Type of domain model</typeparam>
   public interface IBaseServices<TDomainModel> where TDomainModel : class
   {
      void Insert(TDomainModel model);
      void Update(TDomainModel model);
      void Delete(TDomainModel model);
      IEnumerable<TDomainModel> GetAll();
      TDomainModel GetById(object id);
      void ValidateModel(TDomainModel model);
   }
}
