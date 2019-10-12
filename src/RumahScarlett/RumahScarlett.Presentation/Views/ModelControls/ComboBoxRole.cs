using RumahScarlett.Domain.Models.Role;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Role;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Role;
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
      public IRoleModel SelectedItem
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? (IRoleModel)comboBox.SelectedItem : null;
         }
         set
         {
            if (value != null)
            {
               comboBox.SelectedItem = comboBox.Items.Cast<IRoleModel>()
                                       .Where(t => t.kode.Equals(value.kode)).FirstOrDefault();
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
         var services = new RoleServices(new RoleRepository(), new ModelDataAnnotationCheck());
         var listRoles = services.GetAll().ToList();

         if (listRoles != null && listRoles.Count > 0)
         {
            comboBox.Items.AddRange(listRoles.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
