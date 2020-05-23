using Common;
using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення налаштувань
    /// </summary>
    public interface ISettingsUC
    {
        /// <summary>
        /// Подія збереження налаштувань
        /// </summary>
        event EventHandler<DataEventArgs> SaveSheduleSettingsEventRaised;

        /// <summary>
        /// Налаштування даних в представленні налаштувань
        /// </summary>
        /// <param name="setupValues">Словник параметрів налаштувань</param>
        void SetupControls(Dictionary<string, string> setupValues);
    }
}