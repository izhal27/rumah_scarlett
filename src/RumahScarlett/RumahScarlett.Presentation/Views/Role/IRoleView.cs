using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Role
{
   public interface IRoleView : IDataView
   {
      event EventHandler OnButtonUpdateActionClick;
      ComboBox ComboBoxMenu { get; }
      TreeView TreeViewAction { get; }
   }
}