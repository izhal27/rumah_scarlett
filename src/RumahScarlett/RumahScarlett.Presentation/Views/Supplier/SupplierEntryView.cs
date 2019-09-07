using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
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

namespace RumahScarlett.Presentation.Views.Supplier
{
   public partial class SupplierEntryView : BaseEntryView, IEntryView
   {
      private bool _isNewData;
      private ISupplierModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "Supplier";

      public SupplierEntryView(bool isNewData = true, ISupplierModel model = null)
      {
         InitializeComponent();

         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? $"TAMBAH {_typeName.ToUpper()}" : $"UBAH {_typeName.ToUpper()}";

         if (!_isNewData)
         {
            _model = model;
            textBoxNama.Text = model.nama;
            textBoxAlamat.Text = model.alamat;
            textBoxTelpon.Text = model.telpon;
            textBoxFax.Text = model.fax;
            textBoxEmail.Text = model.email;
            textBoxWebsite.Text = model.website;
            textBoxContactPerson.Text = model.contact_person;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new SupplierModel
         {
            nama = textBoxNama.Text,
            alamat = textBoxAlamat.Text,
            telpon = textBoxTelpon.Text,
            fax = textBoxFax.Text,
            email = !string.IsNullOrWhiteSpace(textBoxEmail.Text) ? textBoxEmail.Text : null,
            website = !string.IsNullOrWhiteSpace(textBoxWebsite.Text) ? textBoxWebsite.Text : null,
            contact_person = textBoxContactPerson.Text
         };

         var modelArgs = new ModelEventArgs<SupplierModel>(model);

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
