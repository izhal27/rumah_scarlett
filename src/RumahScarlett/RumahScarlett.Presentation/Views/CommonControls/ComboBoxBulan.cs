using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public class ComboBoxBulan : ComboBox
   {
      public ComboBoxBulan()
      {
         DropDownStyle = ComboBoxStyle.DropDownList;
      }

      protected override void OnCreateControl()
      {
         DataSource = CultureInfo.InvariantCulture.DateTimeFormat
                               .MonthNames.Take(12).ToList();
         SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat
                                 .MonthNames[DateTime.Now.AddMonths(-1).Month];
      }
   }
}
