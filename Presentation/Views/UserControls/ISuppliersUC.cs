using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення списку постачальників
    /// </summary>
    public interface ISuppliersUC
    {
        /// <summary>
        /// Подія виклику представлення для створення нового постачальника
        /// </summary>
        event EventHandler AddNewSupplierEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення постачальника
        /// </summary>
        event EventHandler DeleteSupplierEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраного постачальника
        /// </summary>
        event EventHandler EditSupplierEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного постачальника
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку постачальників
        /// </summary>
        event EventHandler<DataEventArgs> SortSuppliersByBindingPropertyNameEventRaised;

        /// <summary>
        /// Налаштування даних в представленні списку постачальників
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку постачальників</param>
        void SetupControls(BindingSource bindingSource);
    }
}