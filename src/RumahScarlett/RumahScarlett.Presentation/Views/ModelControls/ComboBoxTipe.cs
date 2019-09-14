using RumahScarlett.Domain.Models.Tipe;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Tipe;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Tipe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public partial class ComboBoxTipe : UserControl
   {
      public ITipeModel SelectedItem
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? (ITipeModel)comboBox.SelectedItem : null;
         }
         set { comboBox.SelectedItem = comboBox.Items.Cast<ITipeModel>().Where(t => t.id == value.id).FirstOrDefault() ; }
      }
      
      public ComboBoxTipe()
      {
         InitializeComponent();

         if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime))
         {
            LoadDataSource();
         }
      }

      private void LoadDataSource()
      {
         var services = new TipeServices(new TipeRepository(), new ModelDataAnnotationCheck());
         var listTipes = services.GetAll().ToList();

         if (listTipes != null && listTipes.Count > 0)
         {
            comboBox.Items.AddRange(listTipes.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
