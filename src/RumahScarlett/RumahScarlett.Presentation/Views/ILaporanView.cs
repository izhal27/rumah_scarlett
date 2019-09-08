﻿using RumahScarlett.Presentation.Views.CommonControls;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface ILaporanView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnDeleteClick;
      event EventHandler OnPrintClick;
      event EventHandler OnDetailClick;
      event EventHandler<FilterDateEventArgs> OnTampilkanClick;
      event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;

      DateTimePickerFilterTransaksi DateTimePickerFilterTransaksi { get; }
      ListDataGrid ListDataGrid { get; }
   }
}
