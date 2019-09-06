using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Barang;
using RumahScarlett.Domain.Models.PenyesuaianStok;
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

namespace RumahScarlett.Presentation.Views.PenyesuaianStok
{
   public partial class PenyesuaianStokEntryView : BaseEntryView, IPenyesuaianStokEntryView
   {
      private bool _isNewData;
      private IPenyesuaianStokModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Penyesuaian Stok";

      public PenyesuaianStokEntryView(bool isNewData = true, IPenyesuaianStokModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH PENYESUAIAN STOK" : "UBAH PENYESUAIAN STOK";

         if (!_isNewData)
         {
            _model = model;
            dateTimePickerTanggal.Value = model.tanggal;
            textBoxNamaBarang.Text = model.Barang.nama;
            textBoxNamaBarang.Tag = model.Barang;
            textBoxQty.Text = model.qty.ToString("N0");
            textBoxKeterangan.Text = model.keterangan;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new PenyesuaianStokModel
         {
            tanggal = dateTimePickerTanggal.Value.Date,
            Barang = textBoxNamaBarang.Tag != null ? (BarangModel)textBoxNamaBarang.Tag : new BarangModel(),
            qty = int.Parse(textBoxQty.Text, NumberStyles.Number),
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
}
