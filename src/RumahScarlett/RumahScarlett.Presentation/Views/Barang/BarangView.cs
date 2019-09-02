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

namespace RumahScarlett.Presentation.Views.Barang
{
   public partial class BarangView : BaseDataView, IBarangView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnCreateData;
      public event EventHandler OnUpdateData;
      public event EventHandler OnDeleteData;
      public event EventHandler OnRefreshData;
      public event EventHandler OnPrintData;

      public event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;
      public event EventHandler OnButtonTampilkanClick;
      public event EventHandler OnRadioButtonTipeChecked;
      public event EventHandler OnRadioButtonSupplierChecked;

      public ListDataGrid ListDataGrid
      {
         get { return listDataGrid; }
      }

      public RadioButton RadioButtonSemua
      {
         get { return radioButtonSemua; }
      }

      public RadioButton RadioButtonTipe
      {
         get { return radioButtonTipe; }
      }

      public RadioButton RadioButtonSupplier
      {
         get { return radioButtonSupplier; }
      }

      public ComboBox ComboBoxTipe
      {
         get { return comboBoxTipe; }
      }

      public ComboBox ComboBoxSubTipe
      {
         get { return comboBoxSubTipe; }
      }

      public ComboBox ComboBoxSupplier
      {
         get { return comboBoxSupplier; }
      }

      public Button ButtonTampilkan
      {
         get { return buttonTampilkan; }
      }

      public BarangView()
      {
         InitializeComponent();

         panelUp.LabelInfo = "DATA BARANG";

         radioButtonTipe.CheckedChanged += radioButtonTipe_CheckedChanged;
         radioButtonSupplier.CheckedChanged += radioButtonSupplier_CheckedChanged;
         buttonTampilkan.Click += buttonTampilkan_Click;
         crudcButtons.OnTambahClick += crudcButtons_OnTambahClick;
         crudcButtons.OnUbahClick += crudcButtons_OnUbahClick;
         crudcButtons.OnHapusClick += crudcButtons_OnHapusClick;
         crudcButtons.OnRefreshClick += crudcButtons_OnRefreshClickEvent;
         crudcButtons.OnTutupClick += crudcButtons_OnTutupClickEvent;
         crudcButtons.OnCetakClick += CrudcButtons_OnCetakClick;
      }

      private void BarangView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
      }

      private void listDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         OnDataGridCellDoubleClick?.Invoke(sender, e);
      }

      private void radioButtonTipe_CheckedChanged(object sender, EventArgs e)
      {
         OnRadioButtonTipeChecked?.Invoke(sender, e);
      }

      private void radioButtonSupplier_CheckedChanged(object sender, EventArgs e)
      {
         OnRadioButtonSupplierChecked?.Invoke(sender, e);
      }

      private void buttonTampilkan_Click(object sender, EventArgs e)
      {
         OnButtonTampilkanClick?.Invoke(sender, e);
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

      private void CrudcButtons_OnCetakClick(object sender, EventArgs e)
      {
         OnPrintData?.Invoke(sender, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}
