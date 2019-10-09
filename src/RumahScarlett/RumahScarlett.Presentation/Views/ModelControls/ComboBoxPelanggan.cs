using RumahScarlett.Domain.Models.Pelanggan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Pelanggan;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.Pelanggan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Views.ModelControls
{
   public partial class ComboBoxPelanggan : UserControl
   {
      public IPelangganModel SelectedItem
      {
         get
         {
            return comboBox.SelectedIndex != -1 ? (IPelangganModel)comboBox.SelectedItem : null;
         }
         set
         {
            if (value != null)
            {
               comboBox.SelectedItem = comboBox.Items.Cast<IPelangganModel>().Where(t => t.id == value.id).FirstOrDefault();
            }
         }
      }
      
      public ComboBoxPelanggan()
      {
         InitializeComponent();

         if ((LicenseManager.UsageMode != LicenseUsageMode.Designtime))
         {
            LoadDataSource();
         }
      }

      private void LoadDataSource()
      {
         var services = new PelangganServices(new PelangganRepository(), new ModelDataAnnotationCheck());
         var listPelanggans = services.GetAll().ToList();

         if (listPelanggans != null && listPelanggans.Count > 0)
         {
            comboBox.Items.AddRange(listPelanggans.ToArray());
            comboBox.DisplayMember = "nama";
         }
      }
   }
}
