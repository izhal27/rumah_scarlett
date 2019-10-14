using RumahScarlett.Presentation.Views.CommonControls;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            //{typeof(ComboBox), c => ((ComboBox)c).SelectedIndex = -1},
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

      /// <summary>
      /// Method yang digunakan untuk mengatur data source ComboBox dari object List KeyValuePair,
      /// dengan menggunakan class BindingSource
      /// </summary>
      /// <param name="comboBox">ComboBox target</param>
      /// <param name="kvDataSource">KeyValuePair data source</param>
      /// <param name="clearSelected">True jika ingin mengatur selected index ComboBox -1 </param>
      public static void SetDataSource(this ComboBox comboBox,
         List<KeyValuePair<object, string>> kvDataSource, bool clearSelected = true)
      {
         var kvpDataSource = kvDataSource;
         // Atur data source ComboBox menggunakan class BindingSource
         comboBox.DataSource = new BindingSource(kvpDataSource, null);
         comboBox.ValueMember = "Key"; // Value member / id item
         comboBox.DisplayMember = "Value"; // Display member / text item yang ditampilkan di ComboBox
         if (clearSelected) comboBox.SelectedIndex = -1; // Jangan tampilkan item
      }

      /// <summary>
      /// Method untuk membuat font menjadi style Bold
      /// </summary>
      /// <param name="fontTarget">Font target</param>
      /// <returns>Mengembalikan font dengan style Bold</returns>
      public static Font Bold(this Font fontTarget)
      {
         return new Font(fontTarget.Name, fontTarget.Size, FontStyle.Bold);
      }
      
      /// <summary>
      /// Enable control yang ingin dilewati / tidak termasuk dalam daftar Role detail
      /// </summary>
      /// <param name="control">Control target</param>
      /// <returns>Mengembalikan true jika control mempunyai Tag ignore</returns>
      public static bool TagIgnore(this object control)
      {
         return control.PropertyValueEquals("Tag", "ignore");
      }
   }
}
