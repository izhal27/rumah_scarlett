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
      public event EventHandler OnComboBoxTipeSelectedIndexChanged;
      public event EventHandler OnRadioButtonSupplierChecked;

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
      }

      private void BarangView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, new EventArgs<ListDataGrid>(listDataGrid));

         comboBoxTipe.Enabled = false;
         comboBoxSubTipe.Enabled = false;
         comboBoxSupplier.Enabled = false;
         ActiveControl = buttonTampilkan;
      }

      private void listDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         OnDataGridCellDoubleClick?.Invoke(sender, e);
      }

      private void radioButtonTipe_CheckedChanged(object sender, EventArgs e)
      {
         var value = new Dictionary<string, ComboBox>();
         value.Add(comboBoxTipe.Name, comboBoxTipe);
         value.Add(comboBoxSubTipe.Name, comboBoxSubTipe);

         OnRadioButtonTipeChecked?.Invoke(sender, new EventArgs<Dictionary<string, ComboBox>>(value));
      }

      private void comboBoxTipe_SelectedIndexChanged(object sender, EventArgs e)
      {
         OnComboBoxTipeSelectedIndexChanged?.Invoke(sender, new EventArgs<ComboBox>(comboBoxSubTipe));
      }

      private void radioButtonSupplier_CheckedChanged(object sender, EventArgs e)
      {
         OnRadioButtonSupplierChecked?.Invoke(sender, new EventArgs<ComboBox>(comboBoxSupplier));
      }

      private void buttonTampilkan_Click(object sender, EventArgs e)
      {
         var value = new Dictionary<string, ComboBox>();
         value.Add(comboBoxTipe.Name, comboBoxTipe);
         value.Add(comboBoxSubTipe.Name, comboBoxSubTipe);
         value.Add(comboBoxSupplier.Name, comboBoxSupplier);

         OnButtonTampilkanClick?.Invoke(sender, new EventArgs<Dictionary<string, ComboBox>>(value));
      }

      private void crudcButtons_OnTambahClick(object sender, EventArgs e)
      {
         OnCreateData?.Invoke(sender, e);
      }

      private void crudcButtons_OnUbahClick(object sender, EventArgs e)
      {
         OnUpdateData?.Invoke(sender, new EventArgs<ListDataGrid>(listDataGrid));
      }

      private void crudcButtons_OnHapusClick(object sender, EventArgs e)
      {
         OnDeleteData?.Invoke(sender, new EventArgs<ListDataGrid>(listDataGrid));
      }

      private void crudcButtons_OnRefreshClickEvent(object sender, EventArgs e)
      {
         radioButtonSemua.Checked = true;
         OnRefreshData?.Invoke(sender, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}
