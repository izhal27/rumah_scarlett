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
using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Presentation.Helper;
using System.Globalization;

namespace RumahScarlett.Presentation.Views.Barang
{
   public partial class BarangEntryView : BaseEntryView, IBarangEntryView
   {
      private bool _isNewData;
      private IBarangModel _model;
      public event EventHandler<ModelEventArgs> OnSaveData;
      private static string _typeName = "Barang";

      public BarangEntryView(bool isNewData = true, IBarangModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH BARANG" : "UBAH BARANG";

         if (!_isNewData)
         {
            _model = model;
            comboBoxTipe.SelectedValue = model.sub_tipe_id;
            comboBoxSubTipe.SelectedValue = model.sub_tipe_id;
            comboBoxSupplier.SelectedValue = model.supplier_id;
            textBoxKode.Text = model.kode;
            textBoxNama.Text = model.nama;
            textBoxHpp.Text = model.hpp.ToString("N0");
            textBoxHargaJual.Text = model.harga_jual.ToString("N0");
            textBoxHargaLama.Text = model.harga_lama.ToString("N0");
            textBoxStok.Text = model.stok.ToString("N0");
            textBoxMinStok.Text = model.minimal_stok.ToString("N0");
            comboBoxSatuan.SelectedValue = model.satuan_id;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new BarangModel
         {
            sub_tipe_id = (uint)comboBoxSubTipe.SelectedValue,
            supplier_id = (uint)comboBoxSupplier.SelectedValue,
            kode = textBoxKode.Text,
            nama = textBoxNama.Text,
            hpp = decimal.Parse(textBoxHpp.Text, NumberStyles.Number),
            harga_jual = decimal.Parse(textBoxHargaJual.Text, NumberStyles.Number),
            harga_lama = decimal.Parse(textBoxHargaLama.Text, NumberStyles.Number),
            stok = int.Parse(textBoxStok.Text, NumberStyles.Number),
            minimal_stok = int.Parse(textBoxMinStok.Text, NumberStyles.Number),
            satuan_id = (uint)comboBoxSatuan.SelectedValue
         };

         if (_isNewData && Messages.ConfirmSave(_typeName))
         {
            EventHelper.RaiseEvent(this, OnSaveData, new ModelEventArgs { Model = model });
         }
         else if (Messages.ConfirmUpdate(_typeName))
         {
            model.id = _model.id;
            EventHelper.RaiseEvent(this, OnSaveData, new ModelEventArgs { Model = model });
         }
      }

   }
}
