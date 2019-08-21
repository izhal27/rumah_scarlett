using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services
{
   public interface IBaseRepository<T> where T : class
   {
      void Insert(T model);
      void Update(T model);
      void Delete(T model);
      IEnumerable<T> GetAll();
      T GetById(object id);
   }
}
