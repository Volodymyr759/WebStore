using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс стартових налаштувань
    /// </summary>
    public interface ISettingsPresenter
    {
        /// <summary>
        /// Повертає представлення налаштувань
        /// </summary>
        /// <returns></returns>
        ISettingsUC GetSettingsUC();

        /// <summary>
        /// Час початку дії розкладу для виконання завдань
        /// </summary>
        /// <returns></returns>
        DateTime GetSheduleStartTime();

        /// <summary>
        /// Інтервал в годинах для розкладу виконання завдань
        /// </summary>
        /// <returns></returns>
        int GetSheduleInterval();

        /// <summary>
        /// При запуску визначає, чи потрібно використовувати розклад виконання завдань
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        bool IsNeedRunShedule();

        /// <summary>
        /// Визначає, чи потрібно виконувати завдання перевірки наявності товарів у постачальників
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        bool IsNeedToCheckAvailability();

        /// <summary>
        /// Визначає, чи потрібно виконувати завдання перевірки цін товарів у постачальників
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        bool IsNeedToCheckPrices();

        /// <summary>
        /// Визначає, чи потрібно виконувати завдання перевірки наявності нових товарів у постачальників і завантаження в базу даних
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        bool IsNeedToLoadNewProducts();
    }
}