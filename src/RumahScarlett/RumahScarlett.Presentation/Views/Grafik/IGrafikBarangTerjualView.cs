﻿using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using RumahScarlett.Presentation.Views.CommonControls;

namespace RumahScarlett.Presentation.Views.Grafik
{
   public interface IGrafikBarangTerjualView : IView
   {
      event EventHandler OnLoadView;
      event EventHandler OnButtonTampilkanClick;

      Chart ChartBarangTerjual { get; }
      RadioButton RadioButtonBulan { get; }
      ComboBoxBulan ComboBoxBulan { get; }
      NumericUpDown NumericUpDownTahun { get; }
   }
}