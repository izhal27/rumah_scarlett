using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public class ComboBoxStatusHutang : ComboBox
   {
      protected override void OnCreateControl()
      {
         if (Items.Count > 0)
         {
            Items.Clear();
         }

         Items.Add("Belum Lunas");
         Items.Add("Lunas");

         SelectedIndex = 0;
         DropDownStyle = ComboBoxStyle.DropDownList;
      }
   }
}
