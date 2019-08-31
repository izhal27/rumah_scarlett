using RumahScarlett.CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.KasAwal
{
   public partial class KasAwalView : Form, IKasAwalView
   {
      public event EventHandler OnLoadData;
      public event EventHandler OnSaveData;

      public KasAwalView()
      {
         InitializeComponent();
      }

      private void KasAwalView_Load(object sender, EventArgs e)
      {
         OnLoadData?.Invoke(sender, new EventArgs<TextBox>(textBoxTotal));
         ActiveControl = buttonSave;
      }

      private void KasAwalView_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            OnSaveData?.Invoke(sender, new EventArgs<TextBox>(textBoxTotal));
         }
      }

      private void buttonSave_Click(object sender, EventArgs e)
      {
         OnSaveData?.Invoke(sender, new EventArgs<TextBox>(textBoxTotal));
      }

      public void ShowView()
      {
         ShowDialog();
      }

   }
}
