using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.GantiPassword;
using RumahScarlett.Infrastructure.DataAccess.Repositories.User;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.GantiPassword;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.GantiPassword
{
   public class GantiPasswordPresenter : IGantiPasswordPresenter
   {
      private IGantiPasswordView _view;
      private IUserServices _services;

      public IGantiPasswordView GetView
      {
         get { return _view; }
      }

      public GantiPasswordPresenter()
      {
         _view = new GantiPasswordView();
         _services = new UserServices(new UserRepository(), new ModelDataAnnotationCheck());

         _view.OnButtonSimpanClick += _view_OnButtonSimpanClick;
      }

      private void _view_OnButtonSimpanClick(object sender, EventArgs e)
      {
         try
         {
            var model = new GantiPasswordModel
            {
               login_id = string.Copy(MainProgram.UserActive.login_id),
               password_sekarang = _view.TextBoxPasswordSekarang.Text,
               password_baru = _view.TextBoxPasswordBaru.Text,
               konf_password_baru = _view.TextBoxKonfPasswordBaru.Text
            };

            if (Messages.Confirm("Anda yakin ingin mengganti password?"))
            {
               _services.GantiPassword(model);
               Messages.Info("Password berhasil diganti.");
               ((Form)_view).Close();
            }
         }
         catch (ArgumentException ex)
         {
            Messages.Error(ex);
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
         }
      }
   }
}
