using Common;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення списку груп власного каталогу
    /// </summary>
    public interface IGroupsPresenter
    {
        /// <summary>
        /// Подія зміни посилання на сторінку групи
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Повертає екземпляр представлення списку груп власного каталогу
        /// </summary>
        /// <returns>Екземпляр представлення списку груп</returns>
        IGroupsUC GetGroupsUC();
    }
}
