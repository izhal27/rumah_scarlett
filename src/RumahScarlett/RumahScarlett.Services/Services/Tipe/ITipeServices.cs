using RumahScarlett.Domain.Models.Tipe;
using System.Collections.Generic;

namespace RumahScarlett.Services.Services.Tipe
{
   public interface ITipeServices : IBaseServices<ITipeModel>
   {
      void Insert(ISubTipeModel model);
      void Update(ISubTipeModel model);
      void Delete(ISubTipeModel model);
      IEnumerable<ISubTipeModel> GetAllSubTipe();
      ISubTipeModel GetSubTipeById(object id);
      void ValidateModel(ISubTipeModel model);
   }
}