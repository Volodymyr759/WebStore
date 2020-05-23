using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення деталей характеристики товару
    /// </summary>
    public interface IParametersDetailUC
    {
        /// <summary>
        /// Подія відміни у представленні деталей характеристики товару
        /// </summary>
        event EventHandler CancelParametersDetailEventRaised;

        /// <summary>
        /// Подія збереження запису обраної характеристики товару
        /// </summary>
        event EventHandler<DataEventArgs> SaveParametersDetailEventRaised;

        /// <summary>
        /// Очищення елементів у представленні деталей обраної характеристики товару
        /// </summary>
        /// <param name="bindingSourceProductsDtoModel">Прив'язка до списку товарів</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        void ResetControls(BindingSource bindingSourceProductsDtoModel, BindingSource bindingSourceUnitsDtoModel);

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної характеристики товару
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceProductsDtoModel">Прив'язка до списку товарів</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceProductsDtoModel, BindingSource bindingSourceUnitsDtoModel);
    }
}