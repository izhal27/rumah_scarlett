﻿using RumahScarlett.Domain.Models.Penjualan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Services.Services.Penjualan
{
   public interface IPenjualanServices : IBaseServicesGetByDate<IPenjualanModel>, IBaseReportServicesByDate<IPenjualanReportModel>
   {
      IPenjualanModel GetByNoNota(object noNota);
   }
}
