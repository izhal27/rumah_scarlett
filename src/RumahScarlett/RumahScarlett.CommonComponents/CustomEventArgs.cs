using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.CommonComponents
{
   public class EventArgs<T> : EventArgs
   {
      public T Value { get; set; }

      public EventArgs(T value)
      {
         Value = value;
      }
   }
}
