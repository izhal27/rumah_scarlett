using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.Login
{
   public partial class LoginView : Form, ILoginView
   {
      public event EventHandler OnButtonLoginClick;

      public LoginView()
      {
         InitializeComponent();
      }

      private void LoginView_Load(object sender, EventArgs e)
      {
         ActiveControl = textBoxLoginID;
      }

      private void chkBoxShowCharacters_CheckedChanged(object sender, EventArgs e)
      {
         // Tampilkan karakter di TextBox password jika CheckBox tampilkan dicentang,
         // sebaliknya sembunyikan karakter dengan password char
         var status = ((CheckBox)sender).Checked;

         textBoxPassword.UseSystemPasswordChar = !status;
      }

      private void textBoxPassword_ImeModeChanged(object sender, EventArgs e)
      {
         ((TextBox)sender).PasswordChar = '\0'; // Disable password char
      }
      
      private void btnLogin_Click(object sender, EventArgs e)
      {
         OnButtonLoginClick?.Invoke(sender, e);
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }
   }
}
