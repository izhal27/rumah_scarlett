using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RumahScarlett.Presentation.Views;

namespace RumahScarlett.Presentation.Presenters
{
   public class MainPresenter : IMainPresenter
   {
      private IMainView _view;

      public IMainView GetView
      {
         get { return _view; }
      }

      public MainPresenter(IMainView view)
      {
         _view = view;
      }
   }
}
