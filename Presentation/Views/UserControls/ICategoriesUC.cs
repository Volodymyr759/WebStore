using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення списку категорій постачальників
    /// </summary>
    public interface ICategoriesUC
    {
        /// <summary>
        /// Подія виклику представлення для створення нової категорії
        /// </summary>
        event EventHandler AddNewCategoryEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення категорії
        /// </summary>
        event EventHandler DeleteCategoryEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної категорії
        /// </summary>
        event EventHandler EditCategoryEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраної категорії
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку категорій
        /// </summary>
        event EventHandler<DataEventArgs> SortCategoriesByBindingPropertyNameEventRaised;

        /// <summary>
        /// Налаштування даних в представленні списку категорій постачальників
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку категорій</param>
        void SetupControls(BindingSource bindingSource);
    }
}