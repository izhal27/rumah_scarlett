using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumahScarlett.CommonComponents
{
   public class EventHelper
   {
      public static void RaiseEvent(object sender,
                                    EventHandler<AccessTypeEventArgs> eventHandlerRaised,
                                    AccessTypeEventArgs accessTypeEventArgs)
      {
         eventHandlerRaised?.Invoke(sender, accessTypeEventArgs);
      }

      public static void RaiseEvent(object sender, EventHandler eventHandlerRaised,
                                    EventArgs eventArgs)
      {
         eventHandlerRaised?.Invoke(sender, eventArgs);
      }
   }
}
