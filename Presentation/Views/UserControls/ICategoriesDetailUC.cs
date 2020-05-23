using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення деталей категорії постачальника
    /// </summary>
    public interface ICategoriesDetailUC
    {
        /// <summary>
        /// Подія відміни у представленні деталей категорії
        /// </summary>
        event EventHandler CancelCategoriesDetailEventRaised;

        /// <summary>
        /// Подія збереження запису обраної категорії постачальника
        /// </summary>
        event EventHandler<DataEventArgs> SaveCategoriesDetailEventRaised;

        /// <summary>
        /// Очищення елементів у представленні деталей обраної категорії постачальника
        /// </summary>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        void ResetControls(BindingSource bindingSourceSuppliersDtoModel);

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної категорії постачальника
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceSuppliersDtoModel);
    }
}