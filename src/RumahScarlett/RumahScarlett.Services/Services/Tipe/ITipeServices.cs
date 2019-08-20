using System.Collections.Generic;
using RumahScarlett.Domain.Models.Tipe;

namespace RumahScarlett.Services.Services.Tipe
{
   public interface ITipeServices
   {
      void Create(ITipeModel model);
      void Update(ITipeModel model);
      void Delete(ITipeModel model);
      IEnumerable<ITipeModel> GetAll();
      ITipeModel GetById(object id);
      void ValidateModel(ITipeModel model);
   }
}