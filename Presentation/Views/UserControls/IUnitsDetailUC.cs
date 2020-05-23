using Common;
using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення деталей одиниці виміру
    /// </summary>
    public interface IUnitsDetailUC
    {
        /// <summary>
        /// Подія відміни у представленні деталей одиниці виміру
        /// </summary>
        event EventHandler CancelUnitsDetailEventRaised;

        /// <summary>
        /// Подія збереження запису обраної одиниці виміру
        /// </summary>
        event EventHandler<DataEventArgs> SaveUnitsDetailEventRaised;

        /// <summary>
        /// Очищення елементів у представленні деталей обраної одиниці виміру
        /// </summary>
        void ResetControls();

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної одиниці виміру
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}