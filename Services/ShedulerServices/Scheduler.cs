using System;

namespace Services.ShedulerServices
{
    /// <summary>
    /// Розпорядок виконання завдань
    /// </summary>
    public static class Scheduler
    {
        /// <summary>
        /// Починає виконувати завдання у заданий в параметрах час (08:59) та з вказаним інтервалом в секундах (15)
        /// </summary>
        /// <param name="hour">08</param>
        /// <param name="sec">59</param>
        /// <param name="interval">15</param>
        /// <param name="task"></param>
        public static void IntervalInSeconds(int hour, int sec, double interval, Action task)
        {
            interval = interval / 3600;
            SchedulerService.Instance.ScheduleTask(hour, sec, interval, task);
        }

        /// <summary>
        /// Починає виконувати завдання у заданий в параметрах час (08:59) та з вказаним інтервалом в хвилинах (30)
        /// </summary>
        /// <param name="hour">08</param>
        /// <param name="min">59</param>
        /// <param name="interval">30</param>
        /// <param name="task"></param>
        public static void IntervalInMinutes(int hour, int min, double interval, Action task)
        {
            interval = interval / 60;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        /// <summary>
        /// Починає виконувати завдання у заданий в параметрах час (08:59) та з вказаним інтервалом в годинах (24)
        /// </summary>
        /// <param name="hour">08</param>
        /// <param name="min">59</param>
        /// <param name="interval">24</param>
        /// <param name="task"></param>
        public static void IntervalInHours(int hour, int min, double interval, Action task)
        {
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        /// <summary>
        /// Починає виконувати завдання у заданий в параметрах час (08:59) та з вказаним інтервалом в днях (1)
        /// </summary>
        /// <param name="hour">08</param>
        /// <param name="min">59</param>
        /// <param name="interval">1</param>
        /// <param name="task"></param>
        public static void IntervalInDays(int hour, int min, double interval, Action task)
        {
            interval = interval * 24;
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }
    }
}
