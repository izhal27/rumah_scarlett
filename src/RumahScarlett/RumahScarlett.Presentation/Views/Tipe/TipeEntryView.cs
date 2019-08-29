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
      public event EventHandler<ModelEventArgs> OnSaveData;
      private static string _typeName = "Tipe";

      public TipeEntryView(bool isNewData = true, ITipeModel model = null)
      {
         InitializeComponent();
         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? "TAMBAH TIPE" : "UBAH TIPE";

         if (_isNewData)
         {
            navigationEntryButtons.Visible = false;
            Height -= navigationEntryButtons.Height;
         }
         else
         {
            _model = model;
            textBoxNama.Text = model.nama.Trim();
            textBoxKeterangan.Text = model.keterangan;
         }

         navigationEntryButtons.OnFirstClick += NavigationEntryButtons_OnFirstClick;
         navigationEntryButtons.OnReverseClick += NavigationEntryButtons_OnReverseClick;
         navigationEntryButtons.OnNextClick += NavigationEntryButtons_OnNextClick;
         navigationEntryButtons.OnLastClick += NavigationEntryButtons_OnLastClick;

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
         operationButtons.OnCloseButtonClick += OperationButtons_OnCloseButtonClick;
      }

      private void NavigationEntryButtons_OnFirstClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void NavigationEntryButtons_OnReverseClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void NavigationEntryButtons_OnNextClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void NavigationEntryButtons_OnLastClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new TipeModel
         {
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

      private void OperationButtons_OnCloseButtonClick(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      public void ShowView()
      {
         ShowDialog();
      }

      public void CloseView()
      {
         Close();
      }
   }
}
