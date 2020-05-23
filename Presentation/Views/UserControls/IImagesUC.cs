using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Інтерфейс представлення списку зображень товарів
    /// </summary>
    public interface IImagesUC
    {
        /// <summary>
        /// Подія виклику представлення для створення нового зображення
        /// </summary>
        event EventHandler AddNewImageEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення зображення
        /// </summary>
        event EventHandler DeleteImageEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраного зображення
        /// </summary>
        event EventHandler EditImageEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного зображення
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку зображень
        /// </summary>
        event EventHandler<DataEventArgs> SortImagesByBindingPropertyNameEventRaised;

        /// <summary>
        /// Налаштування даних в представленні списку зображень товарів
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку зображень товарів</param>
        void SetupControls(BindingSource bindingSource);
    }
}