using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views.GantiPassword
{
   public interface IGantiPasswordView : IView
   {
      event EventHandler OnButtonSimpanClick;

      BaseTextBox TextBoxPasswordSekarang { get; }
      BaseTextBox TextBoxPasswordBaru { get; }
      BaseTextBox TextBoxKonfPasswordBaru { get; }

      void ShowView();
   }
}