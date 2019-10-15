using RumahScarlett.CommonComponents;
using RumahScarlett.Infrastructure.DataAccess.Repositories.User;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.Login;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.Login
{
   public class LoginPresenter : ILoginPresenter
   {
      private ILoginView _view;
      private IUserServices _services;

      public ILoginView GetView
      {
         get { return _view; }
      }

      public LoginPresenter()
      {
         _view = new LoginView();
         _services = new UserServices(new UserRepository(), new ModelDataAnnotationCheck());
         _view.OnButtonLoginClick += _view_OnButtonLoginClick;
      }

      private void _view_OnButtonLoginClick(object sender, EventArgs e)
      {
         try
         {
            var model = _services.LogIn(_view.TextBoxLoginID.Text, _view.TextBoxPassword.Text);

            if (model != null)
            {
               MainProgram.UserActive = model;

               ((Form)_view).Hide(); // Sembunyikan Form login
               ((Form)new MainPresenter().GetView).ShowDialog(); // Tampilkan From main
            }
         }
         catch (ArgumentException ex)
         {
            Messages.Error(ex);
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
            _view.TextBoxLoginID.Clear();
            _view.TextBoxPassword.Clear();
            _view.TextBoxLoginID.Focus();
         }
      }
   }
}
