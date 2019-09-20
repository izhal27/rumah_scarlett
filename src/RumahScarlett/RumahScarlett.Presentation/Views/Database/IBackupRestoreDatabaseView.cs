using System;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Database
{
   public interface IBackupRestoreDatabaseView : IView
   {
      event EventHandler OnButtonLocationClick;
      event EventHandler OnButtonBackupRestoreClick;

      TextBox TextBoxLokasi { get; }

      void ShowView();
   }
}