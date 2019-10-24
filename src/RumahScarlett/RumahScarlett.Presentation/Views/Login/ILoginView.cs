﻿using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Login
{
   public interface ILoginView : IView
   {
      event EventHandler OnLoadView;
      event EventHandler OnButtonLoginClick;
      event EventHandler OnButtonTesKoneksiClick;

      TabControl TabControlLogin { get;} 
      TabPage TabPageLogin { get;} 
      TabPage TabPageDatabase { get;} 

      BaseTextBox TextBoxLoginID { get; }
      BaseTextBox TextBoxPassword { get; }
      BaseTextBox TextBoxServer{ get; }
      BaseTextBox TextBoxDatabase { get; }
      BaseTextBox TextBoxPort { get; }
      BaseTextBox TextBoxUser { get; }
      BaseTextBox TextBoxPasswordDatabase { get; }
   }
}