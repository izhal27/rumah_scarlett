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

namespace RumahScarlett.Presentation.Views.GanitPassword
{
   public partial class GantiPasswordView : BaseEntryView, IGantiPasswordView
   {
      public event EventHandler OnButtonSimoanClick;

      public GantiPasswordView()
      {
         InitializeComponent();

         panelUp.LabelInfo = $"{Text.ToUpper()}";

         operationButtons.OnSaveButtonClick += OperationButtons_OnSaveButtonClick;
      }

      private void OperationButtons_OnSaveButtonClick(object sender, EventArgs e)
      {
         OnButtonSimoanClick?.Invoke(sender, e);
      }

      private void checkBoxShowCharacters_CheckedChanged(object sender, EventArgs e)
      {
         // Tampilkan karakter di TextBox password jika CheckBox tampilkan dicentang,
         // sebaliknya sembunyikan karakter dengan password char
         var status = ((CheckBox)sender).Checked;

         textBoxPasswordSekarang.UseSystemPasswordChar = !status;
         textBoxPasswordBaru.UseSystemPasswordChar = !status;
         textBoxKonfPasswordBaru.UseSystemPasswordChar = !status;
      }

      private void textBox_ImeModeChanged(object sender, EventArgs e)
      {
         ((TextBox)sender).PasswordChar = '\0'; // Disable/show password char
      }

      public void ShowView()
      {
         ShowDialog();
      }
   }
}
