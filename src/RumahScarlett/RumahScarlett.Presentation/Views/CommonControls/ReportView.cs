using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class ReportView : Form
   {

      #region >> Fields <<

      private string _reportNameSpace = @"RumahScarlett.Report.{0}.rdlc";
      private Assembly _assemblyReport;

      #endregion

      // ----------------------------------------------------------------------//

      #region >> Constructor <<
         
      public ReportView(string textForm, string reportName, ReportDataSource reportDataSource
         , IEnumerable<ReportParameter> parameters = null)
      {
         InitializeComponent();

         reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
         reportViewer1.ZoomMode = ZoomMode.Percent;
         reportViewer1.ZoomPercent = 100;

         _assemblyReport = Assembly.LoadFrom("RumahScarlett.Report.dll");

         Text = textForm; // Title Form preview

         reportName = string.Format(_reportNameSpace, reportName);
         var reportDefinition = _assemblyReport.GetManifestResourceStream(reportName);

         reportViewer1.LocalReport.DataSources.Clear();

         if (reportDataSource != null)
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

         reportViewer1.LocalReport.LoadReportDefinition(reportDefinition);

         if (parameters != null)
            reportViewer1.LocalReport.SetParameters(parameters);

         reportViewer1.RefreshReport();
      }

      #endregion

   }
}
