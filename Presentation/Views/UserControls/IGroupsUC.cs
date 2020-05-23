using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення списку груп власного каталогу
    /// </summary>
    public interface IGroupsUC
    {
        /// <summary>
        /// Подія виклику представлення для створення нової групи
        /// </summary>
        event EventHandler AddNewGroupEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення групи
        /// </summary>
        event EventHandler DeleteGroupEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної групи
        /// </summary>
        event EventHandler EditGroupEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраної групи
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку груп
        /// </summary>
        event EventHandler<DataEventArgs> SortGroupsByBindingPropertyNameEventRaised;

        /// <summary>
        /// Налаштування даних в представленні списку груп
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку груп</param>
        void SetupControls(BindingSource bindingSource);
    }
}