using System;

namespace Common
{
    /// <summary>
    /// Клас, генеруючий повідомлення між рівнями програми
    /// </summary>
    public static class EventHelper
    {
        /// <summary>
        /// Викликає підписаний на подію метод обробки зі стандартними аргументами
        /// </summary>
        /// <param name="objectRaisingEvent">object</param>
        /// <param name="eventHandlerRaised">EventHandler</param>
        /// <param name="eventArgs">EventArgs</param>
        public static void RaiseEvent(object objectRaisingEvent, EventHandler eventHandlerRaised, EventArgs eventArgs) =>
            eventHandlerRaised?.Invoke(objectRaisingEvent, eventArgs);

        /// <summary>
        /// Викликає підписаний на подію метод обробки з передачею даних у словнику параметрів
        /// </summary>
        /// <param name="objectRaisingEvent">object</param>
        /// <param name="eventHandlerRaised">EventHandler(DataEventArgs)</param>
        /// <param name="dataEventArgs">DataEventArgs</param>
        public static void RaiseEvent(object objectRaisingEvent, EventHandler<DataEventArgs> eventHandlerRaised,
            DataEventArgs dataEventArgs)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, dataEventArgs);
        }
    }
}
