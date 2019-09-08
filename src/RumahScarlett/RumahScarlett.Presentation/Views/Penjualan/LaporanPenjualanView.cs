using RumahScarlett.Presentation.Views.CommonControls;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public partial class LaporanPenjualanView : BaseDataView, ILaporanView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnDeleteData;
      public event EventHandler OnPrintData;
      public event EventHandler OnDetailClick;
      public event EventHandler OnTampilkanClick;
      public event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;

      public DateTimePickerFilterTransaksi DateTimePickerFilterTransaksi
      {
         get { return dateTimePickerFilterTransaksi; }
      }

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public LaporanPenjualanView()
      {
         InitializeComponent();

         panelUp.LabelInfo = $"LAPORAN {Text.ToUpper()}";

         dateTimePickerFilterTransaksi.OnTampilkanClick += DateTimePickerFilterTransaksi_OnTampilkanClick;
         buttonsDeletePrintDetail.OnHapusClick += ButtonsDeletePrintDetail_OnHapusClick;
         buttonsDeletePrintDetail.OnCetakClick += ButtonsDeletePrintDetail_OnCetakClick;
         buttonsDeletePrintDetail.OnDetailClick += ButtonsDeletePrintDetail_OnDetailClick;
      }

      private void LaporanPenjualanView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
      }

      private void listDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         OnDataGridCellDoubleClick?.Invoke(sender, e);
      }

      private void ButtonsDeletePrintDetail_OnHapusClick(object sender, EventArgs e)
      {
         OnDeleteData?.Invoke(sender, e);
      }

      private void ButtonsDeletePrintDetail_OnCetakClick(object sender, EventArgs e)
      {
         OnPrintData?.Invoke(sender, e);
      }

      private void ButtonsDeletePrintDetail_OnDetailClick(object sender, EventArgs e)
      {
         OnDetailClick?.Invoke(sender, e);
      }

      private void DateTimePickerFilterTransaksi_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         OnTampilkanClick?.Invoke(sender, e);
      }

   }
}
