using System;
using System.Collections.Generic;

namespace Common
{
    public static class EventHelper
    {
        //public static void RaiseEvent(Object objectRaisingEvent,
        //                          EventHandler<AccessTypeEventArgs> eventHandlerRaised,
        //                          AccessTypeEventArgs accessTypeEventArgs)
        //{
        //    if (eventHandlerRaised != null) //Check if any subscribed to this event 
        //    {
        //        eventHandlerRaised(objectRaisingEvent, accessTypeEventArgs); // Notify all subscribers 
        //    }
        //}

        public static void RaiseEvent(object objectRaisingEvent, EventHandler eventHandlerRaised, EventArgs eventArgs) =>
            eventHandlerRaised?.Invoke(objectRaisingEvent, eventArgs);

        public static void RaiseEvent(object objectRaisingEvent, EventHandler<DataEventArgs> eventHandlerRaised,
            DataEventArgs dataEventArgs)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, dataEventArgs);
        }
    }
}
