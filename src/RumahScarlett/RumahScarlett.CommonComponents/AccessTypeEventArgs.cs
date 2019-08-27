using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.CommonComponents
{
   public class AccessTypeEventArgs : IAccessTypeEventArgs
   {
      public enum AccessType
      {
         Read,
         Create,
         Update,
         Delete
      }

      private AccessType _accessType;
      private bool _valuesWereChanged;

      public bool ValuesWereChanged
      {
         get { return _valuesWereChanged; }
         set { _valuesWereChanged = value; }
      }

      public AccessType AccessTypeValue
      {
         get { return _accessType; }
         set { _accessType = value; }
      }
   }
}
