using RumahScarlett.Presentation.Views.GanitPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters.GantiPassword
{
   public class GantiPasswordPresenter : IGantiPasswordPresenter
   {
      private IGantiPasswordView _view;

      public IGantiPasswordView GetView
      {
         get { return _view; }
      }

      public GantiPasswordPresenter()
      {
         _view = new GantiPasswordView();
      }
   }
}
