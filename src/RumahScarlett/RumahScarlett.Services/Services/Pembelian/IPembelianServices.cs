﻿using RumahScarlett.Domain.Models.Pembelian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Pembelian
{
   public interface IPembelianServices : IBaseServicesGetByDate<IPembelianModel>, IBaseReportServicesByDate<IPembelianReportModel>
   {
      IPembelianModel GetByNoNota(object noNota);
   }
}
