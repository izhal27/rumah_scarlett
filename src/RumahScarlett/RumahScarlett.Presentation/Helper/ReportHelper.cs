using Microsoft.Reporting.WinForms;
using RumahScarlett.Domain.Models.Pembelian;
using RumahScarlett.Domain.Models.Penjualan;
using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Helper
{
   public static class ReportHelper
   {
      public static void ShowNotaPembelian(IPembelianModel pembelianModel)
      {
         var reportDataSources = new List<ReportDataSource>()
         {
            new ReportDataSource {
               Name = "DataSetPembelian",
               Value = new BindingSource(pembelianModel, null)
            },
            new ReportDataSource {
               Name = "DataSetPembelianDetail",
               Value = pembelianModel.PembelianDetails
            }
         };

         new ReportView("Nota Pembelian", "ReportViewerNotaPembelian",
                        reportDataSources, null).ShowDialog();
      }

      public static void ShowNotaPenjualan(IPenjualanModel penjualanModel)
      {
         var reportDataSources = new List<ReportDataSource>()
         {
            new ReportDataSource {
               Name = "DataSetPenjualan",
               Value = new BindingSource(penjualanModel, null)
            },
            new ReportDataSource {
               Name = "DataSetPenjualanDetail",
               Value = penjualanModel.PenjualanDetails
            }
         };

         new ReportView("Nota Penjualan", "ReportViewerNotaPenjualan",
                        reportDataSources, null).ShowDialog();
      }
   }
}
