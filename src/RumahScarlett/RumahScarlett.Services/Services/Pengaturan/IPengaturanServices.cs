using RumahScarlett.Domain.Models.Pengaturan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Pengaturan
{
   public interface IPengaturanServices
   {
      IPengaturanModel GetModel { get; }
      void Save(IPengaturanModel model);
   }
}
