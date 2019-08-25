using RumahScarlett.Domain.Models.KasAwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.KasAwal
{
   public interface IKasAwalRepository : IBaseRepository<IKasAwalModel>
   {
      IKasAwalModel GetByTanggal(object date);
   }
}
