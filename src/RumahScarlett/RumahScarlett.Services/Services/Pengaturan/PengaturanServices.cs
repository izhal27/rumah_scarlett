using RumahScarlett.Domain.Models.Pengaturan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Pengaturan
{
   public class PengaturanServices : IPengaturanServices
   {
      private IModelDataAnnotationCheck _modelDAC;
      private IPengaturanRepository _repo;

      public PengaturanServices(IPengaturanRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public IPengaturanModel GetModel
      {
         get { return _repo.GetModel; }
      }

      public void Save(IPengaturanModel model)
      {
         _modelDAC.ValidateModel(model);
         _repo.Save(model);
      }
   }
}
