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
   public class ComboBoxTipe : ComboBox
   {
      protected ITipeServices _services;
      protected List<ITipeModel> _listTipes;
      protected List<ISubTipeModel> _listSubTipes;

      public List<ISubTipeModel> SubTipes
      {
         get { return _listSubTipes; }
      }

      protected override void OnCreateControl()
      {
         LoadDataSource();
         GetSubTipes();
      }

      protected override void OnSelectedIndexChanged(EventArgs e)
      {
         GetSubTipes();
         base.OnSelectedIndexChanged(e);
      }

      protected virtual void LoadDataSource()
      {
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         _listTipes = _services.GetAll().ToList();

         if (_listTipes != null && _listTipes.Count > 0)
         {
            var tipeKVP = _listTipes.Select(t => new KeyValuePair<object, string>(t.id, t.nama)).ToList();
            this.SetDataSource(tipeKVP, false);
         }
      }

      private void GetSubTipes()
      {
         if (DataSource != null && SelectedIndex >= 0)
         {
            var selectedTipe = _listTipes.Where(t => t.id == (uint)SelectedValue).FirstOrDefault();

            if (selectedTipe != null)
            {
               _listSubTipes = selectedTipe.SubTipes.ToList();
            }
         }
      }
   }
}
