using Equin.ApplicationFramework;
using Microsoft.Reporting.WinForms;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.Laporan;
using RumahScarlett.Services.Services.Laporan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Laporan
{
   public class LaporanStatusPerBarangPresenter : ILaporanStatusPerBarangPresenter
   {
      private ILaporanStatusPerBarangView _view;
      private IStatusPerBarangServices _services;
      private List<IStatusPerBarangModel> _listObjs;
      private BindingListView<StatusPerBarangModel> _bindingView;
      private StatusTampilkan _tampilkanStatus = StatusTampilkan.BulanTahun;

      public ILaporanStatusPerBarangView GetView
      {
         get { return _view; }
      }

      private MonthYear MonthYear
      {
         get { return new MonthYear((_view.ComboBoxBulan.SelectedIndex + 1), _view.NumericUpDownTahun.Value); }
      }

      private MonthYear StartMonthYear
      {
         get { return new MonthYear((_view.ComboBoxBulanAwal.SelectedIndex + 1), _view.NumericUpDownTahunAwal.Value); }
      }

      private MonthYear EndMonthYear
      {
         get { return new MonthYear((_view.ComboBoxBulanAkhir.SelectedIndex + 1), _view.NumericUpDownTahunAkhir.Value); }
      }

      public LaporanStatusPerBarangPresenter()
      {
         _view = new LaporanStatusPerBarangView();
         _services = new StatusPerBarangServices(new StatusPerBarangRepository());

         _view.OnLoadView += _view_OnLoadView;
         _view.OnButtonTampilkanClick += _view_OnButtonTampilkanClick;
         _view.OnButtonCetakClick += _view_OnButtonCetakClick;
      }

      private void _view_OnLoadView(object sender, EventArgs e)
      {
         _view.ComboBoxBulanAwal.SelectedIndex = 0; // Januari

         var year = DateTime.Now.Year;
         _view.NumericUpDownTahun.Value = year;
         _view.NumericUpDownTahunAwal.Value = year;
         _view.NumericUpDownTahunAkhir.Value = year;

         _listObjs = _services.GetByMonthYear(new MonthYear(DateTime.Now.Month, DateTime.Now.Year)).ToList();
         _bindingView = new BindingListView<StatusPerBarangModel>(_listObjs);
         _view.ListDataGrid.DataSource = _bindingView;
      }

      private void _view_OnButtonTampilkanClick(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_view.RadioButtonBulan.Checked)
            {
               _listObjs = _services.GetByMonthYear(MonthYear).ToList();
               _bindingView.DataSource = _listObjs;
               _tampilkanStatus = StatusTampilkan.BulanTahun;
            }
            else
            {
               _listObjs = _services.GetByMonthYear(StartMonthYear, EndMonthYear).ToList();
               _bindingView.DataSource = _listObjs;
               _tampilkanStatus = StatusTampilkan.BulanTahunPeriode;
            }
         }
      }

      private void _view_OnButtonCetakClick(object sender, EventArgs e)
      {
         using (new WaitCursorHandler())
         {
            if (_bindingView.DataSource.Count > 0)
            {
               var parameters = new List<ReportParameter>();
               
               if (_tampilkanStatus == StatusTampilkan.BulanTahun)
               {
                  parameters.Add(new ReportParameter("BulanTahun", $"{_view.ComboBoxBulan.Text}   {_view.NumericUpDownTahun.Value}"));
               }
               else
               {
                  var bulanTahunAwal = $"{_view.ComboBoxBulanAwal.Text}   {_view.NumericUpDownTahunAwal.Value}";
                  var bulanTahunAkhir = $"{_view.ComboBoxBulanAkhir.Text}   {_view.NumericUpDownTahunAkhir.Value}";

                  parameters.Add(new ReportParameter("BulanTahun", bulanTahunAwal));
                  parameters.Add(new ReportParameter("BulanTahunAkhir", bulanTahunAkhir));
               }

               var reportDataSources = new List<ReportDataSource>()
               {
                  new ReportDataSource {
                     Name = "DataSetStatusPerBrang",
                     Value = _bindingView.DataSource
                  }
               };

               new ReportView("Laporan Status Per Barang", "ReportViewerLaporanStatusPerBarang",
                              reportDataSources, parameters).ShowDialog();
            }
         }
      }
   }
   
   enum StatusTampilkan
   {
      BulanTahun,
      BulanTahunPeriode
   }
}
