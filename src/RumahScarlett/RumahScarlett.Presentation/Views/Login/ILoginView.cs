using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views.Login
{
   public interface ILoginView : IView
   {
      event EventHandler OnButtonLoginClick;
      BaseTextBox TextBoxLoginID { get; }
      BaseTextBox TextBoxPassword { get; }
   }
}