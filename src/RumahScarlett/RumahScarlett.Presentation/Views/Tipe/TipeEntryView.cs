using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Tipe;
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

namespace RumahScarlett.Presentation.Views.Tipe
{
   public partial class TipeEntryView : BaseEntryView, ITipeEntryView
   {
      private bool _isNewData;
      private ITipeModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Tipe";

      public TipeEntryView(bool isNewData = true, ITipeModel model = null)
      {
         InitializeComponent();
         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH TIPE" : "UBAH TIPE";

         if (!_isNewData)
         {
            _model = model;
            textBoxNama.Text = model.nama;
            textBoxKeterangan.Text = model.keterangan;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new TipeModel
         {
            nama = textBoxNama.Text,
            keterangan = textBoxKeterangan.Text
         };

         var modelArgs = new ModelEventArgs<TipeModel>(model);

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
