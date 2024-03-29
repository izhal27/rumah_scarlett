﻿using RumahScarlett.Presentation.Views.ModelControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Barang
{
   public interface IBarangView : IDataView
   {
      event EventHandler OnButtonTampilkanClick;
      event EventHandler OnRadioButtonTipeChecked;
      event EventHandler OnRadioButtonSupplierChecked;
      event EventHandler OnButtonDetailPenyesuaianStokClick;
      event EventHandler<ToolStripItemClickedEventArgs> OnButtonExportExcelClick;
      event EventHandler<ToolStripItemClickedEventArgs> OnButtonExportPDFClick;

      RadioButton RadioButtonSemua { get; }
      RadioButton RadioButtonTipe { get; }
      RadioButton RadioButtonSupplier { get; }
      ComboBoxTipe ComboBoxTipe { get; }
      ComboBoxSubTipe ComboBoxSubTipe { get; }
      ComboBoxSupplier ComboBoxSupplier { get; }
      Button ButtonTampilkan { get; }
   }
}
