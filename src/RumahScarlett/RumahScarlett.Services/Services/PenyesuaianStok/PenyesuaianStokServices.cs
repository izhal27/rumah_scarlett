﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Domain.Models.PenyesuaianStok;

namespace RumahScarlett.Services.Services.PenyesuaianStok
{
   public class PenyesuaianStokServices : IPenyesuaianStokServices
   {
      private IModelDataAnnotationCheck _modelDAC;
      private IPenyesuaianStokRepository _repo;

      public PenyesuaianStokServices(IPenyesuaianStokRepository repo, IModelDataAnnotationCheck modelDAC)
      {
         _repo = repo;
         _modelDAC = modelDAC;
      }

      public void Insert(IPenyesuaianStokModel model)
      {
         ValidateModel(model);
         _repo.Insert(model);
      }

      public void Update(IPenyesuaianStokModel model)
      {
         ValidateModel(model);
         _repo.Update(model);
      }

      public void Delete(IPenyesuaianStokModel model)
      {
         ValidateModel(model);
         _repo.Delete(model);
      }

      public IEnumerable<IPenyesuaianStokModel> GetAll()
      {
         return _repo.GetAll();
      }
      
      public IPenyesuaianStokModel GetById(object id)
      {
         return _repo.GetById(id);
      }

      public void ValidateModel(IPenyesuaianStokModel model)
      {
         _modelDAC.ValidateModel(model);
      }
   }
}
