using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Role;
using RumahScarlett.Domain.Models.User;
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

namespace RumahScarlett.Presentation.Views.User
{
   public partial class UserEntryView : BaseEntryView, IUserEntryView
   {
      private bool _isNewData;
      private IUserModel _model;
      public event EventHandler OnSaveData;
      private static string _typeName = "User";

      public UserEntryView(bool isNewData = true, IUserModel model = null)
      {
         InitializeComponent();
         _isNewData = isNewData;
         panelUp.LabelInfo = isNewData ? $"TAMBAH {_typeName.ToUpper()}" : $"UBAH {_typeName.ToUpper()}";

         if (!_isNewData)
         {
            _model = model;
         }

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void UserEntryView_Load(object sender, EventArgs e)
      {
         if (!_isNewData)
         {
            textBoxPassword.Enabled = false;
            buttonShowPassword.Enabled = false;
            textBoxLoginID.Text = _model.login_id;
            comboBoxRole.SelectedItem = new RoleModel { id = _model.id, kode = _model.role_kode };
         }
      }
      
      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         var model = new UserModel
         {
            login_id = textBoxLoginID.Text,
         };

         var modelArgs = new ModelEventArgs<UserModel>(model);

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

      private void buttonShowPassword_MouseDown(object sender, MouseEventArgs e)
      {
         textBoxPassword.UseSystemPasswordChar = false;
      }

      private void buttonShowPassword_MouseUp(object sender, MouseEventArgs e)
      {
         textBoxPassword.UseSystemPasswordChar = true;
      }

      private void textBoxPassword_ImeModeChanged(object sender, EventArgs e)
      {
         ((TextBox)sender).PasswordChar = '\0';
      }
   }
}
