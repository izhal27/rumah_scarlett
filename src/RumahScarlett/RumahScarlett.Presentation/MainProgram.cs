using ExceptionReporting;
using RumahScarlett.Presentation.Presenters;
using RumahScarlett.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation
{
   static class MainProgram
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         // Mengubah Exception dihandle oleh ExceptionReporter
         Application.ThreadException += delegate (object sender, ThreadExceptionEventArgs e)
         {
            ReportCrash(e.Exception);
         };

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         var view = new MainPresenter().GetView;
         Application.Run((Form)view);
      }

      /// <summary>
      /// Method yang mengubah exception default menjadi ExceptionReporter
      /// </summary>
      /// <param name="exception">Exception object</param>
      public static void ReportCrash(Exception exception)
      {
         var reporter = new ExceptionReporter();

         reporter.Config.ShowLessDetailButton = true;

         var productName = Application.ProductName;
         productName = productName.Substring(0, productName.LastIndexOf('.')) + " ";
         var productVersion = Application.ProductVersion;
         // Title form ExceptionReporter
         reporter.Config.TitleText = productName + productVersion + " Exception Report";

         reporter.Show(exception);
      }
   }
}
