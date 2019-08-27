using RumahScarlett.Presentation.Presenters;
using RumahScarlett.Presentation.Views;
using RumahScarlett.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

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
         var ioc = new UnityContainer();

         ioc.RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager());
         //ioc.RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager());

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         IMainPresenter mainPresenter = ioc.Resolve<MainPresenter>();
         IMainView mainView = mainPresenter.GetView;

         Application.Run((MainView)mainView);
      }
   }
}
