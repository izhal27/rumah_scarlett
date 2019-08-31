using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.KasAwal;
using RumahScarlett.Infrastructure.DataAccess.Repositories.KasAwal;
using RumahScarlett.Presentation.Helper;
using RumahScarlett.Presentation.Views.KasAwal;
using RumahScarlett.Services.Services;
using RumahScarlett.Services.Services.KasAwal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RumahScarlett.Presentation.Presenters.KasAwal
{
   public class KasAwalPresenter : IBasePresenter<IKasAwalView>
   {
      private IKasAwalView _view;
      private IKasAwalServices _services;
      private IKasAwalModel _model;

      public IKasAwalView GetView
      {
         get { return _view; }
      }

      public KasAwalPresenter()
      {
         _view = new KasAwalView();
         _services = new KasAwalServices(new KasAwalRepository(), new ModelDataAnnotationCheck());

         _view.OnLoadData += _view_OnLoadData;
         _view.OnSaveData += _view_OnSaveData;
      }

      private void _view_OnLoadData(object sender, EventArgs e)
      {
         _model = _services.GetByTanggal(DateTime.Now.Date);

         var textBoxTotal = ((EventArgs<TextBox>)e).Value;
         textBoxTotal.Text = _model.total.ToString("N0");
      }

      private void _view_OnSaveData(object sender, EventArgs e)
      {
         var textBoxTotal = ((EventArgs<TextBox>)e).Value;

         try
         {
            _model.total = uint.Parse(textBoxTotal.Text, NumberStyles.Number);
            _services.Update(_model);
         }
         catch (ArgumentException ex)
         {
            Messages.Error(ex);
         }
         catch (DataAccessException ex)
         {
            Messages.Error(ex);
         }
         finally
         {
            ((Form)_view).Close();
         }
      }
   }
}
