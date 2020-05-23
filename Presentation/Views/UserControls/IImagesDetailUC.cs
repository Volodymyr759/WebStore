using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення деталей зображення товару
    /// </summary>
    public interface IImagesDetailUC
    {
        /// <summary>
        /// Подія відміни у представленні деталей зображення товару
        /// </summary>
        event EventHandler CancelImagesDetailEventRaised;

        /// <summary>
        /// Подія збереження запису у представленні деталей зображення товару
        /// </summary>
        event EventHandler<DataEventArgs> SaveImagesDetailEventRaised;

        /// <summary>
        /// Очищення значень елементів у представленні деталей зображення
        /// </summary>
        /// <param name="bindingSourceImagesDtoModel"></param>
        void ResetControls(BindingSource bindingSourceImagesDtoModel);

        /// <summary>
        /// Ініціалізація значень елементів представлення деталей зображення
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceSuppliersDtoModel);
    }
}