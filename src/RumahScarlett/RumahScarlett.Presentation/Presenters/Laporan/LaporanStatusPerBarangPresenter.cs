using Equin.ApplicationFramework;
using RumahScarlett.Domain.Models.Laporan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Laporan;
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

      public ILaporanStatusPerBarangView GetView
      {
         get { return _view; }
      }

      public LaporanStatusPerBarangPresenter()
      {
         _view = new LaporanStatusPerBarangView();
         _services = new StatusPerBarangServices(new StatusPerBarangRepository());

         _view.OnLoadView += _view_OnLoadView;
         _view.OnButtonTampilkanClick += _view_OnButtonTampilkanClick;
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
         if (_view.RadioButtonBulan.Checked)
         {
            var monthYear = new MonthYear((_view.ComboBoxBulan.SelectedIndex + 1), _view.NumericUpDownTahun.Value);

            _listObjs = _services.GetByMonthYear(monthYear).ToList();
            _bindingView.DataSource = _listObjs;
         }
         else
         {
            var startMonthYear = new MonthYear((_view.ComboBoxBulanAwal.SelectedIndex + 1), _view.NumericUpDownTahunAwal.Value);
            var endMonthYear = new MonthYear((_view.ComboBoxBulanAkhir.SelectedIndex + 1), _view.NumericUpDownTahunAkhir.Value);

            _listObjs = _services.GetByMonthYear(startMonthYear, endMonthYear).ToList();
            _bindingView.DataSource = _listObjs;
         }
      }
   }
}
