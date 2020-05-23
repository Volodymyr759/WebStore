using System;
using System.Collections.Generic;
using System.Threading;

namespace Services.ShedulerServices
{
    /// <summary>
    /// Клас сервісу розпорядку виконання завдань
    /// </summary>
    public class SchedulerService
    {
        private static SchedulerService _instance;
        private List<Timer> timers = new List<Timer>();
        private SchedulerService() { }

        /// <summary>
        /// Singleton
        /// </summary>
        public static SchedulerService Instance => _instance ?? (_instance = new SchedulerService());

        /// <summary>
        /// Запускає виконання завдання викликаючого методу у 08:59 з інтервалом 24 години
        /// </summary>
        /// <param name="hour">08</param>
        /// <param name="min">59</param>
        /// <param name="intervalInHour">24</param>
        /// <param name="task"></param>
        public void ScheduleTask(int hour, int min, double intervalInHour, Action task)
        {
            DateTime now = DateTime.Now;
            DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);
            if (now > firstRun)
            {
                firstRun = firstRun.AddDays(1);
            }
            TimeSpan timeToGo = firstRun - now;
            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }
            var timer = new Timer(x =>
            {
                task.Invoke();
            }, null, timeToGo, TimeSpan.FromHours(intervalInHour));
            timers.Add(timer);
        }
    }
}
