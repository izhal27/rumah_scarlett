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

namespace RumahScarlett.Presentation.Views.HutangOperasional
{
   public partial class HutangOperasionalView : BaseDataView, IHutangOperasionalView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnButtonTambahClick;
      public event EventHandler OnButtonUbahClick;
      public event EventHandler OnButtonHapusClick;
      public event EventHandler OnButtonRefreshClick;
      public event EventHandler OnButtonCetakClick;
      public event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;
      public event EventHandler<FilterDateEventArgs> OnTampilkanClick;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public Label LabelTotal
      {
         get { return labelTotal; }
      }

      public Label LabelLunas
      {
         get { return labelLunas; }
      }

      public Label LabelBelumLunas
      {
         get { return labelBelumLunas; }
      }

      public HutangOperasionalView()
      {
         InitializeComponent();

         panelUp.LabelInfo = $"DATA {Text.ToUpper()}";

         listDataGrid.CellDoubleClick += ListDataGrid_CellDoubleClick;
         crudcButtons.OnTambahClick += crudcButtons_OnTambahClick;
         crudcButtons.OnUbahClick += crudcButtons_OnUbahClick;
         crudcButtons.OnHapusClick += crudcButtons_OnHapusClick;
         crudcButtons.OnRefreshClick += crudcButtons_OnRefreshClickEvent;
         crudcButtons.OnCetakClick += CrudcButtons_OnCetakClick;
         crudcButtons.OnTutupClick += crudcButtons_OnTutupClickEvent;

         dateTimePickerFilter.OnTampilkanClick += DateTimePickerFilter_OnTampilkanClick;
      }

      private void HutangOperasionalView_Load(object sender, EventArgs e)
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

      private void CrudcButtons_OnCetakClick(object sender, EventArgs e)
      {
         OnButtonCetakClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }

      private void DateTimePickerFilter_OnTampilkanClick(object sender, FilterDateEventArgs e)
      {
         OnTampilkanClick?.Invoke(sender, e);
      }
   }
}
