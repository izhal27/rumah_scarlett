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
   public partial class ComboBoxSubTipe : UserControl
   {
      public ISubTipeModel SelectedItem
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? (ISubTipeModel)comboBox.SelectedItem : null;
         }
         set
         {
            if (value != null)
            {
               comboBox.SelectedItem = comboBox.Items.Cast<ISubTipeModel>().Where(st => st.id == value.id).FirstOrDefault();
            }
         }
      }

      public ComboBoxSubTipe()
      {
         InitializeComponent();

         if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime))
         {
            LoadDataSource();
         }
      }

      private void LoadDataSource()
      {
         var services = new SubTipeServices(new SubTipeRepository(), new ModelDataAnnotationCheck());
         var listSubTipes = services.GetAll().ToList();

         if (listSubTipes != null && listSubTipes.Count > 0)
         {
            comboBox.Items.AddRange(listSubTipes.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
