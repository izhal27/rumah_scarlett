using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views.KasAwal
{
   public interface IKasAwalView : IView
   {
      event EventHandler OnLoadData;
      event EventHandler OnSaveData;
      void ShowView();
   }
}
