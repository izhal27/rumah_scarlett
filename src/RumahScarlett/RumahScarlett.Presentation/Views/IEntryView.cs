﻿using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface IEntryView : IView
   { 
      event EventHandler OnSaveData;
   }
}
