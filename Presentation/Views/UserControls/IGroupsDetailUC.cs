using Common;
using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення деталей групи власного каталогу
    /// </summary>
    public interface IGroupsDetailUC
    {
        /// <summary>
        /// Подія відміни у представленні деталей групи
        /// </summary>
        event EventHandler CancelGroupsDetailEventRaised;

        /// <summary>
        /// Подія збереження запису обраної групи
        /// </summary>
        event EventHandler<DataEventArgs> SaveGroupsDetailEventRaised;

        /// <summary>
        /// Очищення елементів у представленні деталей обраної групи
        /// </summary>
        void ResetControls();

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної групи
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}