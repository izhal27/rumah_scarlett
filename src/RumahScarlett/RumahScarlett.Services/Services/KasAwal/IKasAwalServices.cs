using RumahScarlett.Domain.Models.KasAwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.KasAwal
{
   public interface IKasAwalServices : IBaseServices<IKasAwalModel>
   {
      IKasAwalModel GetByTanggal(object tanggal);
   }
}
