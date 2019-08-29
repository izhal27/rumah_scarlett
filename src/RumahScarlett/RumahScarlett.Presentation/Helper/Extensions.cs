using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Helper
{
   public static class Extensions
   {
      private static Dictionary<Type, Action<Control>> controlDefaults = new Dictionary<Type, Action<Control>>() {
            {typeof(BaseTextBox), c => ((BaseTextBox)c).Clear()},
            {typeof(BaseTextBoxDigit), c => ((BaseTextBoxDigit)c).Text = "0"},
            {typeof(ComboBox), c => ((ComboBox)c).SelectedIndex = -1},
            {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
            {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
            {typeof(RadioButton), c => ((RadioButton)c).Checked = false}
      };

      private static void FindAndInvoke(Type type, Control control)
      {
         if (controlDefaults.ContainsKey(type))
         {
            controlDefaults[type].Invoke(control);
         }
      }

      public static void ClearControls(this Control.ControlCollection controls)
      {
         foreach (Control control in controls)
         {
            FindAndInvoke(control.GetType(), control);

            // Recrusive method
            control.Controls.ClearControls();
         }
      }

      public static void ClearControls<T>(this Control.ControlCollection controls) where T : class
      {
         if (!controlDefaults.ContainsKey(typeof(T))) return;

         foreach (Control control in controls)
         {
            if (control.GetType().Equals(typeof(T)))
            {
               FindAndInvoke(typeof(T), control);
            }
         }
      }

   }
}
