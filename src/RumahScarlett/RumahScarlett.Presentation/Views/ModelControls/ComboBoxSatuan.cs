using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Satuan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Satuan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public partial class ComboBoxSatuan : UserControl
   {
      public ISatuanModel SelectedItem
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? (ISatuanModel)comboBox.SelectedItem : null;
         }
         set { comboBox.SelectedItem = comboBox.Items.Cast<ISatuanModel>().Where(t => t.id == value.id).FirstOrDefault(); }
      }
      
      public ComboBoxSatuan()
      {
         InitializeComponent();

         if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime))
         {
            LoadDataSource();
         }
      }

      private void LoadDataSource()
      {
         var services = new SatuanServices(new SatuanRepository(), new ModelDataAnnotationCheck());
         var listSatuans = services.GetAll().ToList();

         if (listSatuans != null && listSatuans.Count > 0)
         {
            comboBox.Items.AddRange(listSatuans.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
