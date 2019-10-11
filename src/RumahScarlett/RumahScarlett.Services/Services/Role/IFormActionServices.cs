using RumahScarlett.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Role
{
   public interface IFormActionServices : IBaseServices<IFormActionModel>
   {
      IEnumerable<IFormActionModel> GetAllByFormName(string formName);
      IFormActionModel GetByFormName(string formName);
      void DeleteAll();
   }
}
