using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
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
         LoadDataSource();
         base.OnDataSourceChanged(e);
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
