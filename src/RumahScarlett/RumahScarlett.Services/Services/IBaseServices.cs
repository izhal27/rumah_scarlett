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
   /// <typeparam name="T">Type of model</typeparam>
   public interface IBaseServices<T> where T : class
   {
      void Insert(T model);
      void Update(T model);
      void Delete(T model);
      IEnumerable<T> GetAll();
      T GetById(object id);
      void ValidateModel(T model);
   }
}
