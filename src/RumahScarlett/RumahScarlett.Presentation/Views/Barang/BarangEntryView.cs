using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Barang
{
   public partial class BarangEntryView : BaseEntryView, IBarangEntryView
   {
      private bool _isNewData;
      private IBarangModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Barang";

      public BarangEntryView(bool isNewData = true, IBarangModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? $"TAMBAH {_typeName.ToUpper()}" : $"UBAH {_typeName.ToUpper()}";

         if (!_isNewData)
         {
            _model = model;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void BarangEntryView_Load(object sender, EventArgs e)
      {
         if (!_isNewData && _model != null)
         {
            comboBoxTipe.ComboBox.SelectedItem = comboBoxTipe.GetModel(_model.tipe_id);
            comboBoxSubTipe.ComboBox.SelectedItem = comboBoxSubTipe.GetModel(_model.sub_tipe_id);
            comboBoxSupplier.ComboBox.SelectedItem = comboBoxSupplier.GetModel(_model.supplier_id);
            textBoxKode.Text = _model.kode;
            textBoxNama.Text = _model.nama;
            textBoxHpp.Text = _model.hpp.ToString("N0");
            textBoxHargaJual.Text = _model.harga_jual.ToString("N0");
            textBoxHargaLama.Text = _model.harga_lama.ToString("N0");
            textBoxStok.Text = _model.stok.ToString("N0");
            textBoxMinStok.Text = _model.minimal_stok.ToString("N0");
            comboBoxSatuan.ComboBox.SelectedItem = comboBoxSatuan.GetModel(_model.satuan_id);
         }
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new BarangModel
         {
            tipe_id = comboBoxTipe.GetSelectedID,
            sub_tipe_id = comboBoxSubTipe.GetSelectedID,
            supplier_id = comboBoxSupplier.GetSelectedID,
            kode = textBoxKode.Text,
            nama = textBoxNama.Text,
            hpp = decimal.Parse(textBoxHpp.Text, NumberStyles.Number),
            harga_jual = decimal.Parse(textBoxHargaJual.Text, NumberStyles.Number),
            harga_lama = decimal.Parse(textBoxHargaLama.Text, NumberStyles.Number),
            stok = int.Parse(textBoxStok.Text, NumberStyles.Number),
            minimal_stok = int.Parse(textBoxMinStok.Text, NumberStyles.Number),
            Satuan = comboBoxSatuan.GetModel(comboBoxSatuan.GetSelectedID) ?? new SatuanModel()
         };

         var modelArgs = new ModelEventArgs<BarangModel>(model);

         if (_isNewData)
         {
            if (Messages.ConfirmSave(_typeName))
            {
               OnSaveData?.Invoke(this, modelArgs);
            }
         }
         else if (Messages.ConfirmUpdate(_typeName))
         {
            model.id = _model.id;
            OnSaveData?.Invoke(this, modelArgs);
         }
      }
   }
}
