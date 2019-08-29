﻿using RumahScarlett.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Presenters
{
   public interface IBasePresenter<View> where View : IView
   {
      View GetView { get; }
   }
}