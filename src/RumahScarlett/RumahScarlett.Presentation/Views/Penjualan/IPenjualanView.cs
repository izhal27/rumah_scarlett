﻿using RumahScarlett.Presentation.Views.ModelControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Penjualan
{
   public interface IPenjualanView : ITransaksiView
   {
      TextBox TextBoxNoNota { get; }
   }
}
