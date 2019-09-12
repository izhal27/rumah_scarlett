using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public partial class ComboBoxBulan : UserControl
   {
      [Description("Occurs when the value of the SelectedIndex property changes.")]
      public event EventHandler SelectedIndexChanged;

      public ComboBoxBulan()
      {
         InitializeComponent();

         comboBox.DataSource = CultureInfo.InvariantCulture.DateTimeFormat
                               .MonthNames.Take(12).ToList();
         comboBox.SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat
                                 .MonthNames[DateTime.Now.AddMonths(-1).Month];
      }

      private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         SelectedIndexChanged?.Invoke(sender, e);
      }
   }
}
