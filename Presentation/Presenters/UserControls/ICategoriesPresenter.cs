using Common;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення списку категорій постачальника
    /// </summary>
    public interface ICategoriesPresenter
    {
        /// <summary>
        /// Подія зміни посилання на сторінку обраної категорії постачальника
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Повертає екземпляр представлення списку категорій постачальників
        /// </summary>
        /// <returns>Екземпляр представлення категорій постачальників</returns>
        ICategoriesUC GetCategoriesUC();
    }
}
