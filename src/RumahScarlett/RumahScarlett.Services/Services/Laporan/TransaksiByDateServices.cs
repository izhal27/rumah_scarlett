using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public class TransaksiByDateServices : ITransaksiByDateServices
   {
      private ITransaksiByDateRepository _repo;

      public TransaksiByDateServices(ITransaksiByDateRepository repo)
      {
         _repo = repo;
      }

      public ITransaksiByDateModel Get(object date)
      {
         return _repo.Get(date);
      }
   }
}
