using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення деталей товару постачальника
    /// </summary>
    public interface IProductsDetailUC
    {
        /// <summary>
        /// Подія відміни у представленні деталей товару
        /// </summary>
        event EventHandler CancelProductsDetailEventRaised;

        /// <summary>
        /// Подія збереження запису обраного товару
        /// </summary>
        event EventHandler<DataEventArgs> SaveProductsDetailEventRaised;

        /// <summary>
        /// Очищення елементів у представленні деталей обраного товару
        /// </summary>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        /// <param name="bindingSourceCategoriesDtoModel">Прив'язка до списку категорій</param>
        /// <param name="bindingSourceGroupsDtoModel">Прив'язка до списку груп власного каталогу</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        void ResetControls(BindingSource bindingSourceSuppliersDtoModel, BindingSource bindingSourceCategoriesDtoModel,
            BindingSource bindingSourceGroupsDtoModel, BindingSource bindingSourceUnitsDtoModel);

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраного товару
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        /// <param name="bindingSourceCategoriesDtoModel">Прив'язка до списку категорій</param>
        /// <param name="bindingSourceGroupsDtoModel">Прив'язка до списку груп власного каталогу</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceSuppliersDtoModel,
            BindingSource bindingSourceCategoriesDtoModel,
            BindingSource bindingSourceGroupsDtoModel,
            BindingSource bindingSourceUnitsDtoModel);
    }
}