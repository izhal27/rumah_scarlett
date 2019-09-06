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
   public partial class SubTipeEntryView : BaseEntryView, ISubTipeEntryView
   {
      private bool _isNewData;
      private ISubTipeModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Sub Tipe";

      public SubTipeEntryView(bool isNewData = true, ISubTipeModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH SUB TIPE" : "UBAH SUB TIPE";

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
         var model = new SubTipeModel
         {
            nama = textBoxNama.Text,
            keterangan = textBoxKeterangan.Text
         };

         var modelArgs = new ModelEventArgs<SubTipeModel>(model);

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
