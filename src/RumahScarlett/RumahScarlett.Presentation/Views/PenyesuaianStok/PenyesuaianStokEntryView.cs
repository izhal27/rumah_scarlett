using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.PenyesuaianStok;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Barang;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.CommonControls;
using RumahScarlett.Presentation.Views.ModelControls;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Barang;
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

namespace RumahScarlett.Presentation.Views.PenyesuaianStok
{
   public partial class PenyesuaianStokEntryView : BaseEntryView, IPenyesuaianStokEntryView
   {
      private bool _isNewData;
      private IPenyesuaianStokModel _model;
      public event EventHandler OnSaveData;
      private IBarangServices _barangServices;
      private List<IBarangModel> _listBarangs;
      private static string _typeName = "Penyesuaian Stok";

      public PenyesuaianStokEntryView(bool isNewData = true, IPenyesuaianStokModel model = null)
      {
         InitializeComponent();
         _barangServices = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? $"TAMBAH {_typeName.ToUpper()}" : $"UBAH {_typeName.ToUpper()}";

         if (!_isNewData)
         {
            dateTimePickerTanggal.Enabled = false;
            buttonCari.Enabled = false;
            textBoxQty.Enabled = false;
            comboBoxSatuan.Enabled = false;

            _model = model;
            dateTimePickerTanggal.Value = model.tanggal;
            textBoxBarang.Text = model.Barang.nama;
            textBoxBarang.Tag = model.Barang;
            textBoxQty.Text = model.qty.ToString("N0");
            comboBoxSatuan.SelectedItem = model.Satuan;
            textBoxHpp.Text = model.hpp.ToString("N0");
            textBoxKeterangan.Text = model.keterangan;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         if (textBoxBarang.Tag != null)
         {
            var barangModel = textBoxBarang.Tag != null ? (BarangModel)textBoxBarang.Tag : new BarangModel();

            var model = new PenyesuaianStokModel
            {
               tanggal = dateTimePickerTanggal.Value,
               Barang = barangModel,
               hpp = decimal.Parse(textBoxHpp.Text, NumberStyles.Number),
               qty = int.Parse(textBoxQty.Text, NumberStyles.Number),
               satuan_id = comboBoxSatuan.SelectedItem != null ? comboBoxSatuan.SelectedItem.id : default(uint),
               satuan_nama = comboBoxSatuan.SelectedItem.nama,
               keterangan = textBoxKeterangan.Text
            };

            var modelArgs = new ModelEventArgs<PenyesuaianStokModel>(model);

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

      private void buttonCari_Click(object sender, EventArgs e)
      {
         _listBarangs = _barangServices.GetAll().Where(b => b.stok > b.minimal_stok).ToList();

         var view = new CariBarangView(_listBarangs, TipePencarian.PenyesuaianStok);
         view.OnSendData += CariBarangPembelianView_OnSendData;
         view.ShowDialog();
      }

      private void CariBarangPembelianView_OnSendData(object sender, EventArgs e)
      {
         var view = (CariBarangView)sender;
         var model = ((ModelEventArgs<BarangModel>)e).Value;

         if (model != null)
         {
            textBoxBarang.Text = model.nama;
            textBoxBarang.Tag = model;
            textBoxHpp.Text = model.hpp.ToString("N0");
            view.Close();
         }
      }
   }
}
