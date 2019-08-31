using RumahScarlett.CommonComponents;
using RumahScarlett.Domain.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.Presentation.Views
{
   public interface IEntryView<TDomainModel> : IView where TDomainModel : class
   {
      event EventHandler<EventArgs<TDomainModel>> OnSaveData;
   }
}
