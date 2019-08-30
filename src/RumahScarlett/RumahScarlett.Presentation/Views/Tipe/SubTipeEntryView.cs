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
      private List<ITipeModel> _listTipes;
      private bool _isNewData;
      private ISubTipeModel _model;
      public event EventHandler<ModelEventArgs> OnSaveData;
      private static string _typeName = "Sub Tipe";

      public SubTipeEntryView(List<ITipeModel> listTipes, bool isNewData = true, ISubTipeModel model = null)
      {
         InitializeComponent();
         _listTipes = listTipes;
         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH SUB TIPE" : "UBAH SUB TIPE";

         if (listTipes != null)
         {
            var tipeKVP = listTipes.Select(t => new KeyValuePair<object, string>(t.id, t.nama)).ToList();
            comboBoxTipe.SetDataSource(tipeKVP, false);
         }

         if (!_isNewData)
         {
            _model = model;
            comboBoxTipe.SelectedValue = model.tipe_id;
            textBoxNama.Text = model.nama;
            textBoxKeterangan.Text = model.keterangan;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new SubTipeModel
         {
            tipe_id = (uint)comboBoxTipe.SelectedValue,
            nama = textBoxNama.Text,
            keterangan = textBoxKeterangan.Text
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
