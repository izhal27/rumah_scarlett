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
   public partial class ComboBoxTipe : UserControl
   {
      private ITipeServices _services;
      private List<ITipeModel> _listTipes;

      public ComboBox ComboBox
      {
         get { return comboBox; }
      }

      public ComboBoxTipe()
      {
         InitializeComponent();

         LoadDataSource();
      }

      private void LoadDataSource()
      {
         _services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         _listTipes = _services.GetAll().ToList();

         if (_listTipes != null && _listTipes.Count > 0)
         {
            comboBox.Items.AddRange(_listTipes.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
