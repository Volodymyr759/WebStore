using Common;
using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення деталей постачальника
    /// </summary>
    public interface ISuppliersDetailUC
    {
        /// <summary>
        /// Подія відміни у представленні деталей постачальника
        /// </summary>
        event EventHandler CancelSuppliersDetailEventRaised;

        /// <summary>
        /// Подія збереження запису обраного постачальника
        /// </summary>
        event EventHandler<DataEventArgs> SaveSuppliersDetailEventRaised;

        /// <summary>
        /// Очищення елементів у представленні деталей обраного постачальника
        /// </summary>
        void ResetControls();

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраного постачальника
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}