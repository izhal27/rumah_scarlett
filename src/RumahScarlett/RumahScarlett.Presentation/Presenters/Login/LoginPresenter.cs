using RumahScarlett.Presentation.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.Login
{
   public class LoginPresenter : ILoginPresenter
   {
      private ILoginView _view;

      public ILoginView GetView
      {
         get { return _view; }
      }

      public LoginPresenter()
      {
         _view = new LoginView();

         _view.OnButtonLoginClick += _view_OnButtonLoginClick;
      }

      private void _view_OnButtonLoginClick(object sender, EventArgs e)
      {
         throw new NotImplementedException();
      }
   }
}
