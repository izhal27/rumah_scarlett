using RumahScarlett.Domain.Models.User;
using RumahScarlett.Infrastructure.DataAccess.Repositories.User;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public partial class ComboBoxRole : UserControl
   {
      public IUserModel SelectedItem
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? (IUserModel)comboBox.SelectedItem : null;
         }
         set
         {
            if (value != null)
            {
               comboBox.SelectedItem = comboBox.Items.Cast<IUserModel>().Where(t => t.id == value.id).FirstOrDefault();
            }
         }
      }

      public ComboBoxRole()
      {
         InitializeComponent();

         if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime))
         {
            LoadDataSource();
         }
      }

      private void LoadDataSource()
      {
         var services = new UserServices(new UserRepository(), new ModelDataAnnotationCheck());
         var listUsers = services.GetAll().ToList();

         if (listUsers != null && listUsers.Count > 0)
         {
            comboBox.Items.AddRange(listUsers.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
