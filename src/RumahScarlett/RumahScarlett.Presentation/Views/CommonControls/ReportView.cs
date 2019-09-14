﻿using Microsoft.Reporting.WinForms;
using RumahScarlett.Domain.Models.Pengaturan;
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

         reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
         reportViewer.ZoomMode = ZoomMode.Percent;
         reportViewer.ZoomPercent = 100;

         _assemblyReport = Assembly.LoadFrom("RumahScarlett.Report.dll");

         Text = textForm; // Title Form preview

         reportName = string.Format(_reportNameSpace, reportName);
         var reportDefinition = _assemblyReport.GetManifestResourceStream(reportName);

         reportViewer.LocalReport.DataSources.Clear();

         var reportDatasourcePengaturan = new ReportDataSource
         {
            Name = "DataSetPengaturan",
            Value = new BindingSource(MainProgram.Pengaturan ?? new PengaturanModel(), null)
         };

         if (reportDataSource != null)
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

         reportViewer.LocalReport.DataSources.Add(reportDatasourcePengaturan);
         reportViewer.LocalReport.LoadReportDefinition(reportDefinition);

         if (parameters != null)
            reportViewer.LocalReport.SetParameters(parameters);

         reportViewer.RefreshReport();
      }

      #endregion

   }
}
