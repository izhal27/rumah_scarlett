using RumahScarlett.CommonComponents;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.ModelControls;
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

      public ComboBoxTipe ComboBoxTipe
      {
         get { return comboBoxTipe; }
      }

      public ComboBoxSubTipe ComboBoxSubTipe
      {
         get { return comboBoxSubTipe; }
      }

      public ComboBoxSupplier ComboBoxSupplier
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

         crudcButtons.OnTambahClick += crudcButtons_OnTambahClick;
         crudcButtons.OnUbahClick += crudcButtons_OnUbahClick;
         crudcButtons.OnHapusClick += crudcButtons_OnHapusClick;
         crudcButtons.OnRefreshClick += crudcButtons_OnRefreshClickEvent;
         crudcButtons.OnTutupClick += crudcButtons_OnTutupClickEvent;
      }

      private void BarangView_Load(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnLoadData, e);
         ActiveControl = buttonTampilkan;
      }

      private void crudcButtons_OnTambahClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnCreateData, null);
      }

      private void crudcButtons_OnUbahClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnUpdateData, null);
      }

      private void crudcButtons_OnHapusClick(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnDeleteData, null);
      }

      private void crudcButtons_OnRefreshClickEvent(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnRefreshData, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}
