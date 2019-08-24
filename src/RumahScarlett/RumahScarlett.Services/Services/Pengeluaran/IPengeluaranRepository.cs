using RumahScarlett.Domain.Models.Pengeluaran;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Pengeluaran
{
   public interface IPengeluaranRepository : IBaseRepositoryGetByDate<IPengeluaranModel>
   {
   }
}
