using ExceptionReporting;
using RumahScarlett.Domain.Models.Pengaturan;
using RumahScarlett.Domain.Models.User;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pengaturan;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Presenters;
using RumahScarlett.Presentation.Presenters.Login;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pengaturan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation
{
   static class MainProgram
   {
      private static IPengaturanModel _pengaturan;
      
      public static IPengaturanModel Pengaturan
      {
         get { return _pengaturan ?? (_pengaturan = PengaturanServices.GetModel); }
         set { _pengaturan = value; }
      }

      private static IPengaturanServices _pengaturanServices;

      public static IPengaturanServices PengaturanServices
      {
         get
         {
            return _pengaturanServices ?? (_pengaturanServices = new PengaturanServices(new PengaturanRepository(), new ModelDataAnnotationCheck()));
         }
      }

      public static IUserModel UserActive { get; set; }

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         // Mengubah Exception dihandle oleh ExceptionReporter
         Application.ThreadException += new ThreadExceptionEventHandler(ReportCrash);

         if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1)
         {
            Messages.Error("Aplikasi Sedang Berjalan !!!");
            return;
         }

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         
         var view = new LoginPresenter().GetView;
         Application.Run((Form)view);
      }

      /// <summary>
      /// Method yang mengubah exception default menjadi ExceptionReporter
      /// </summary>
      /// <param name="e">Exception EventArgs</param>
      public static void ReportCrash(object sender, ThreadExceptionEventArgs e)
      {
         var reporter = new ExceptionReporter();

         reporter.Config.ShowLessDetailButton = true;

         var productName = Application.ProductName;
         var productVersion = Application.ProductVersion;
         // Title form ExceptionReporter
         reporter.Config.TitleText = $"{productName} {productVersion} Exception Report";

         reporter.Show(e.Exception);
      }
   }
}
