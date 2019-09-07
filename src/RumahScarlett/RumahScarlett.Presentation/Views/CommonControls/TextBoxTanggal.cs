using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views.CommonControls
{
   public class TextBoxTanggal : BaseTextBox
   {
      protected override void OnCreateControl()
      {
         Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
      }
   }
}
