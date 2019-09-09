using RumahScarlett.Domain.Models.Satuan;
using RumahScarlett.Infrastructure.DataAccess.Repositories.Satuan;
using RumahScarlett.Presentation.Helper;
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
      private ISatuanServices _services;
      private List<ISatuanModel> _listSatuans;

      public ComboBox ComboBox
      {
         get { return comboBox; }
      }

      public ComboBoxSatuan()
      {
         InitializeComponent();

         LoadDataSource();
      }

      private void LoadDataSource()
      {
         _services = new SatuanServices(new SatuanRepository(), new ModelDataAnnotationCheck());
         _listSatuans = _services.GetAll().ToList();

         if (_listSatuans != null && _listSatuans.Count > 0)
         {
            comboBox.Items.AddRange(_listSatuans.ToArray());
            comboBox.DisplayMember = "nama";
            comboBox.SelectedIndex = 0;
         }
      }
   }
}
