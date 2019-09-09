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
   public partial class ComboBoxSubTipe : UserControl
   {
      private ISubTipeServices _services;
      private List<ISubTipeModel> _listSubTipes;

      public ComboBox ComboBox
      {
         get { return comboBox; }
      }

      public ComboBoxSubTipe()
      {
         InitializeComponent();

         LoadDataSource();
      }

      private void LoadDataSource()
      {
         _services = new SubTipeServices(new SubTipeRepository(), new ModelDataAnnotationCheck());
         _listSubTipes = _services.GetAll().ToList();

         if (_listSubTipes != null && _listSubTipes.Count > 0)
         {
            comboBox.Items.AddRange(_listSubTipes.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
