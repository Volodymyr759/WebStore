using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення списку характеристик товарів
    /// </summary>
    public interface IParametersUC
    {
        /// <summary>
        /// Подія виклику представлення для створення нової характеристики
        /// </summary>
        event EventHandler AddNewParameterEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення характеристики
        /// </summary>
        event EventHandler DeleteParameterEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної характеристики
        /// </summary>
        event EventHandler EditParameterEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку характеристик товарів
        /// </summary>
        event EventHandler<DataEventArgs> SortParametersByBindingPropertyNameEventRaised;

        /// <summary>
        /// Налаштування даних в представленні списку характеристик товарів
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку характеристик</param>
        void SetupControls(BindingSource bindingSource);
    }
}