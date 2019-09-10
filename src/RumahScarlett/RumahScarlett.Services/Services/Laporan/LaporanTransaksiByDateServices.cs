using RumahScarlett.Domain.Models.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Laporan
{
   public class LaporanTransaksiByDateServices : ILaporanTransaksiByDateServices
   {
      private ILaporanTransaksiByDateRepository _repo;

      public LaporanTransaksiByDateServices(ILaporanTransaksiByDateRepository repo)
      {
         _repo = repo;
      }

      public ILaporanTransaksiByDateModel Get(object date)
      {
         return _repo.Get(date);
      }
   }
}
