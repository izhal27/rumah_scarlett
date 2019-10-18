using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.ModelControls;
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
      public event EventHandler OnButtonTambahClick;
      public event EventHandler OnButtonUbahClick;
      public event EventHandler OnButtonHapusClick;
      public event EventHandler OnButtonRefreshClick;
      public event EventHandler OnButtonCetakClick;

      public event EventHandler<CellClickEventArgs> OnDataGridCellDoubleClick;
      public event EventHandler OnButtonTampilkanClick;
      public event EventHandler OnRadioButtonTipeChecked;
      public event EventHandler OnRadioButtonSupplierChecked;
      public event EventHandler OnButtonDetailPenyesuaianStokClick;
      public event EventHandler<ToolStripItemClickedEventArgs> OnButtonExportExcelClick;
      public event EventHandler<ToolStripItemClickedEventArgs> OnButtonExportPDFClick;

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

         panelUp.LabelInfo = $"DATA {Text.ToUpper()}";

         radioButtonTipe.CheckedChanged += radioButtonTipe_CheckedChanged;
         radioButtonSupplier.CheckedChanged += radioButtonSupplier_CheckedChanged;
         buttonTampilkan.Click += buttonTampilkan_Click;

         buttonExport.OnButtonExcelClick += ButtonExport_OnButtonExcelClick;
         buttonExport.OnButtonPDFClick += ButtonExport_OnButtonPDFClick;
      }

      private void BarangView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, e);
         ActiveControl = buttonTutup;
      }

      private void listDataGrid_CellDoubleClick(object sender, CellClickEventArgs e)
      {
         if (buttonUbah.Enabled)
         {
            OnDataGridCellDoubleClick?.Invoke(sender, e);
         }
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

      private void ButtonExport_OnButtonExcelClick(object sender, ToolStripItemClickedEventArgs e)
      {
         OnButtonExportExcelClick?.Invoke(sender, e);
      }

      private void ButtonExport_OnButtonPDFClick(object sender, ToolStripItemClickedEventArgs e)
      {
         OnButtonExportPDFClick?.Invoke(sender, e);
      }

      private void buttonTambah_Click(object sender, EventArgs e)
      {
         OnButtonTambahClick?.Invoke(sender, e);
      }

      private void buttonUbah_Click(object sender, EventArgs e)
      {
         OnButtonUbahClick?.Invoke(sender, e);
      }

      private void buttonHapus_Click(object sender, EventArgs e)
      {
         OnButtonHapusClick?.Invoke(sender, e);
      }

      private void buttonRefresh_Click(object sender, EventArgs e)
      {
         OnButtonRefreshClick?.Invoke(sender, e);
      }

      private void buttonCetak_Click(object sender, EventArgs e)
      {
         OnButtonCetakClick?.Invoke(sender, e);
      }

      private void buttonDetailPenyesuainStok_Click(object sender, EventArgs e)
      {
         OnButtonDetailPenyesuaianStokClick?.Invoke(sender, e);
      }

      private void crudcButtons_OnTutupClickEvent(object sender, EventArgs e)
      {
         Close();
      }
   }
}
