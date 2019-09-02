using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.HutangOperasional;
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

namespace RumahScarlett.Presentation.Views.HutangOperasional
{
   public partial class HutangOperasionalEntryView : BaseEntryView, IHutangOperasionalEntryView
   {
      private bool _isNewData;
      private IHutangOperasionalModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Hutang Operasional";

      public HutangOperasionalEntryView(bool isNewData = true, IHutangOperasionalModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH HUTANG OPERASIONAL" : "UBAH HUTANG OPERASIONAL";

         if (!_isNewData)
         {
            _model = model;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }


      private void HutangOperasionalEntryView_Load(object sender, EventArgs e)
      {
         if (!_isNewData && _model != null)
         {
            dateTimePickerTanggal.Value = _model.tanggal;
            textBoxDigitJumlah.Text = _model.jumlah.ToString("N0");
            textBoxKeterangan.Text = _model.keterangan;
            comboBoxStatusHutang.SelectedIndex = _model.status_hutang ? 1 : 0;
         }
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new HutangOperasionalModel
         {
            tanggal = dateTimePickerTanggal.Value,
            jumlah = decimal.Parse(textBoxDigitJumlah.Text, NumberStyles.Number),
            keterangan = textBoxKeterangan.Text,
            status_hutang = comboBoxStatusHutang.SelectedIndex == 0 ? false : true
         };

         if (_isNewData && Messages.ConfirmSave(_typeName))
         {
            OnSaveData?.Invoke(this, new EventArgs<IHutangOperasionalModel>(model));
         }
         else if (Messages.ConfirmUpdate(_typeName))
         {
            model.id = _model.id;
            OnSaveData?.Invoke(this, new EventArgs<IHutangOperasionalModel>(model));
         }
      }
   }
}
