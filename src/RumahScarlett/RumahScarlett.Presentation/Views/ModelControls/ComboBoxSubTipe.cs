using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Presentation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public class ComboBoxSubTipe : ComboBox
   {
      public List<ISubTipeModel> SubTipes { private get; set; }

      protected override void OnCreateControl()
      {
         LoadDataSource();
      }

      protected override void OnDataSourceChanged(EventArgs e)
      {
         base.OnDataSourceChanged(e);
         LoadDataSource();
      }

      private void LoadDataSource()
      {
         if (SubTipes != null && SubTipes.ToList().Count > 0)
         {
            var subTipeKVP = SubTipes.Select(sub => new KeyValuePair<object, string>(sub.id, sub.nama)).ToList();
            this.SetDataSource(subTipeKVP, false);
         }
      }
   }
}
