using RumahScarlett.CommonComponents;
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

namespace RumahScarlett.Presentation.Views.Supplier
{
   public partial class SupplierView : BaseDataView, ISupplierView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnButtonTambahClick;
      public event EventHandler OnButtonUbahClick;
      public event EventHandler OnButtonHapusClick;
      public event EventHandler OnButtonRefreshClick;
      public event EventHandler OnButtonCetakClick;
      public event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public SupplierView()
      {
         InitializeComponent();

         panelUp.LabelInfo = $"DATA {Text.ToUpper()}";
         crudcButtons.ButtonCetak.Visible = false;
         crudcButtons.ButtonCetak.Tag = "ignore";

         listDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
         crudcButtons.OnTambahClick += crudcButtons_OnTambahClick;
         crudcButtons.OnUbahClick += crudcButtons_OnUbahClick;
         crudcButtons.OnHapusClick += crudcButtons_OnHapusClick;
         crudcButtons.OnRefreshClick += crudcButtons_OnRefreshClickEvent;
         crudcButtons.OnTutupClick += crudcButtons_OnTutupClickEvent;
      }

      private void SupplierView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
         ActiveControl = crudcButtons.ButtonTutup;
      }

      private void ListDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         OnDataGridCellDoubleClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnTambahClick(object sender, EventArgs e)
      {
         OnButtonTambahClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnUbahClick(object sender, EventArgs e)
      {
         OnButtonUbahClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnHapusClick(object sender, EventArgs e)
      {
         OnButtonHapusClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnRefreshClickEvent(object sender, EventArgs e)
      {
         OnButtonRefreshClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}
