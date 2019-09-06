using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Events;

namespace RumahScarlett.Presentation.Views.PenyesuaianStok
{
   public partial class PenyesuaianStokView : BaseDataView, IPenyesuaianStokView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnCreateData;
      public event EventHandler OnUpdateData;
      public event EventHandler OnDeleteData;
      public event EventHandler OnRefreshData;
      public event EventHandler OnPrintData;
      public event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;
      public event EventHandler OnTampilkanClick;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public Label LabelTotalQty
      {
         get { return labelTotalQty; }
      }

      public Label LabelTotalHpp
      {
         get { return labelTotalHpp; }
      }

      public PenyesuaianStokView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "DATA PENYESUAIAN STOK";
         
         listDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
         crudcButtons.OnTambahClick += crudcButtons_OnTambahClick;
         crudcButtons.OnUbahClick += crudcButtons_OnUbahClick;
         crudcButtons.OnHapusClick += crudcButtons_OnHapusClick;
         crudcButtons.OnRefreshClick += crudcButtons_OnRefreshClickEvent;
         crudcButtons.OnTutupClick += crudcButtons_OnTutupClickEvent;

         dateTimePickerFilter.OnTampilkanClick += DateTimePickerFilter_OnTampilkanClick;
      }
      
      private void PenyesuaianStokView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
      }

      private void ListDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         OnDataGridCellDoubleClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnTambahClick(object sender, EventArgs e)
      {
         OnCreateData?.Invoke(sender, e);
      }

      private void crudcButtons_OnUbahClick(object sender, EventArgs e)
      {
         OnUpdateData?.Invoke(sender, e);
      }

      private void crudcButtons_OnHapusClick(object sender, EventArgs e)
      {
         OnDeleteData?.Invoke(sender, e);
      }

      private void crudcButtons_OnRefreshClickEvent(object sender, EventArgs e)
      {
         OnRefreshData?.Invoke(sender, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }

      private void DateTimePickerFilter_OnTampilkanClick(object sender, EventArgs e)
      {
         OnTampilkanClick?.Invoke(sender, e);
      }
   }
}
