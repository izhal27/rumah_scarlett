﻿using RumahScarlett.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Role
{
   public interface IRoleRepository : IBaseRepository<IRoleModel>
   {
      void Insert(IRoleDetailModel model);
      void Insert(IEnumerable<IRoleDetailModel> models);
      void Delete(IRoleDetailModel model);
      void DeleteAllRoleDetail();
      IEnumerable<IRoleDetailModel> GetByMenuParent(string roleKode, string menuParent);
      IEnumerable<IRoleDetailModel> GetAllByRoleKode(string roleKode);
      IEnumerable<string> GetAllMenuNameByTagAction(string roleKode, string formName);
   }
}
