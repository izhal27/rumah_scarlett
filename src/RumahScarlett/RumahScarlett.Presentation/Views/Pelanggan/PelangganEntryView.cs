using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Presentation.Helper;
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

namespace RumahScarlett.Presentation.Views.Pelanggan
{
   public partial class PelangganEntryView : BaseEntryView, IPelangganEntryView
   {
      private bool _isNewData;
      private IPelangganModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Pelanggan";

      public PelangganEntryView(bool isNewData = true, IPelangganModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH PELANGGAN" : "UBAH PELANGGAN";

         if (!_isNewData)
         {
            _model = model;
            textBoxNama.Text = model.nama;
            textBoxAlamat.Text = model.alamat;
            textBoxTelpon.Text = model.telpon;
            textBoxKeterangan.Text = model.keterangan;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new PelangganModel
         {
            nama = textBoxNama.Text,
            alamat = textBoxAlamat.Text,
            telpon = textBoxTelpon.Text,
            keterangan = textBoxKeterangan.Text,
         };

         var modelArgs = new ModelEventArgs<PelangganModel>(model);

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
