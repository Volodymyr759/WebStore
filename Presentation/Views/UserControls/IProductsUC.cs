using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення списку товарів постачальників
    /// </summary>
    public interface IProductsUC
    {
        /// <summary>
        /// Подія виклику представлення для створення нового товару
        /// </summary>
        event EventHandler AddNewProductEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення товару
        /// </summary>
        event EventHandler DeleteProductEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраного товару
        /// </summary>
        event EventHandler EditProductEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного товару
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку товарів
        /// </summary>
        event EventHandler<DataEventArgs> SortProductsByBindingPropertyNameEventRaised;

        /// <summary>
        /// Налаштування даних в представленні списку товарів постачальників
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку товарів</param>
        void SetupControls(BindingSource bindingSource);
    }
}