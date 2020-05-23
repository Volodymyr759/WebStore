using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення списку одиниць виміру
    /// </summary>
    public interface IUnitsUC
    {
        /// <summary>
        /// Подія виклику представлення для створення нової одиниці виміру
        /// </summary>
        event EventHandler AddNewUnitEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення одиниці виміру
        /// </summary>
        event EventHandler DeleteUnitEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної одиниці виміру
        /// </summary>
        event EventHandler EditUnitEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку одиниць виміру
        /// </summary>
        event EventHandler<DataEventArgs> SortUnitsByBindingPropertyNameEventRaised;

        /// <summary>
        /// Налаштування даних в представленні списку одиниць виміру
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку одиниць виміру</param>
        void SetupControls(BindingSource bindingSource);
    }
}