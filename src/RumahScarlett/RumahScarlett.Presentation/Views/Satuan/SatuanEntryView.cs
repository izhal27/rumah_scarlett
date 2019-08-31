using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Satuan;
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

namespace RumahScarlett.Presentation.Views.Satuan
{
   public partial class SatuanEntryView : BaseEntryView, ISatuanEntryView
   {
      private bool _isNewData;
      private ISatuanModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Satuan";

      public SatuanEntryView(bool isNewData = true, ISatuanModel model = null)
      {
         InitializeComponent();
         
         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH SATUAN" : "UBAH SATUAN";

         if (!_isNewData)
         {
            _model = model;
            textBoxNama.Text = _model.nama;
            textBoxKeterangan.Text = _model.keterangan;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new SatuanModel
         {
            nama = textBoxNama.Text,
            keterangan = textBoxKeterangan.Text
         };

         if (_isNewData && Messages.ConfirmSave(_typeName))
         {
            OnSaveData?.Invoke(this, new EventArgs<ISatuanModel>(model));
         }
         else if (Messages.ConfirmUpdate(_typeName))
         {
            model.id = _model.id;
            OnSaveData?.Invoke(this, new EventArgs<ISatuanModel>(model));
         }
      }
   }
}
