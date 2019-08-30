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
using RumahScarlett.Services.Services.Tipe;
using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Domain.Models.Supplier;
using RumahScarlett.Services.Services.Supplier;
using RumahScarlett.Services.Services;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Supplier;
using RumahScarlett.Services.Services.Satuan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Satuan;

namespace RumahScarlett.Presentation.Views.Barang
{
   public partial class BarangEntryView : BaseEntryView, IBarangEntryView
   {
      private bool _isNewData;
      private IBarangModel _model;
      private List<ITipeModel> _listTipes;
      private List<ISupplierModel> _listSupplier;
      public event EventHandler<ModelEventArgs> OnSaveData;
      private static string _typeName = "Barang";

      public BarangEntryView(ITipeServices tipeServices, bool isNewData = true, IBarangModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH BARANG" : "UBAH BARANG";

         _listTipes = tipeServices.GetAll().ToList();

         if (_listTipes != null && _listTipes.Count > 0)
         {
            var tipeKVP = _listTipes.Select(t => new KeyValuePair<object, string>(t.id, t.nama)).ToList();
            comboBoxTipe.SetDataSource(tipeKVP, true);
         }

         var listSuppliers = new SupplierServices(new SupplierRepository(), new ModelDataAnnotationCheck()).GetAll().ToList();

         if (listSuppliers != null && listSuppliers.Count > 0)
         {
            var supplierKVP = listSuppliers.Select(s => new KeyValuePair<object, string>(s.id, s.nama)).ToList();
            comboBoxSupplier.SetDataSource(supplierKVP, false);
         }

         var listSatuans = new SatuanServices(new SatuanRepository(), new ModelDataAnnotationCheck()).GetAll().ToList();

         if (listSatuans != null && listSatuans.Count > 0)
         {
            var satuanKVP = listSatuans.Select(s => new KeyValuePair<object, string>(s.id, s.nama)).ToList();
            comboBoxSatuan.SetDataSource(satuanKVP, false);
         }

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

      private void BarangEntryView_Load(object sender, EventArgs e)
      {
         if (comboBoxTipe.Items.Count > 0)
         {
            comboBoxTipe.SelectedIndex = 0;
         }
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new BarangModel
         {
            tipe_id = (uint)comboBoxTipe.SelectedValue,
            sub_tipe_id = comboBoxSubTipe.SelectedValue != null ? (uint)comboBoxSubTipe.SelectedValue : default(uint),
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

      private void comboBoxTipe_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (comboBoxTipe.SelectedIndex != -1)
         {
            var tipeId = (uint)comboBoxTipe.SelectedValue;

            var subTipeKVP = _listTipes.Where(t => t.id == tipeId).FirstOrDefault()
                          .SubTipes.Select(sub => new KeyValuePair<object, string>(sub.id, sub.nama)).ToList();

            comboBoxSubTipe.SetDataSource(subTipeKVP, false);
         }
      }
   }
}
