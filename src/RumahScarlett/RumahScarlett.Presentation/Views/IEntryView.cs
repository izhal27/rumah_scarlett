using RumahScarlett.CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface IEntryView : IView
   {
      event EventHandler<ModelEventArgs> OnSaveData;
      void ShowView();
      void CloseView();
   }
}
