using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.KasAwal
{
   public interface IKasAwalView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnSaveData;

      TextBox TextBoxTotal { get; }
      Button ButtonSave { get; }
      void ShowView();
   }
}
