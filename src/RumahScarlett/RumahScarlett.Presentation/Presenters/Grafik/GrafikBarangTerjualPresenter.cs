﻿using RumahScarlett.Domain.Models.Grafik;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Grafik;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Grafik;
using RumahScarlett.Services.Services.Grafik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Grafik
{
   public class GrafikBarangTerjualPresenter : IGrafikBarangTerjualPresenter
   {
      private IGrafikBarangTerjualView _view;
      private IGrafikBarangTerjualServices _services;

      public IGrafikBarangTerjualView GetView
      {
         get { return _view; }
      }

      public GrafikBarangTerjualPresenter()
      {
         _view = new GrafikBarangTerjualView();
         _services = new GrafikBarangTerjualServices(new GrafikBarangTerjualRepository());

         _view.OnLoadView += _view_OnLoadView;
         _view.OnButtonTampilkanClick += _view_OnButtonTampilkanClick;
      }

      private void _view_OnLoadView(object sender, EventArgs e)
      {
         _view.ChartBarangTerjual.Titles.Add("Daftar 10 Barang yang sering terjual");
         PopulateChartBarangTerjual();
      }

      private void _view_OnButtonTampilkanClick(object sender, EventArgs e)
      {
         PopulateChartBarangTerjual();
      }

      private void PopulateChartBarangTerjual()
      {
         using (new WaitCursorHandler())
         {
            var listObj = new List<IGrafikBarangTerjualModel>();
            var chart = _view.ChartBarangTerjual;

            listObj = _services.GetByMonthYear((_view.ComboBoxBulan.SelectedIndex + 1), _view.NumericUpDownTahun.Value).ToList();

            if (chart.Series != null)
            {
               chart.Series.Clear();
            }

            chart.DataBindCrossTable(listObj, "barang_nama", "bulan_tahun", "stok_terjual", "");

            foreach (var ser in chart.Series)
            {
               ser.IsValueShownAsLabel = true;
            }
         }
      }
   }
}
