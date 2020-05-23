using Common;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення списку постачальників
    /// </summary>
    public interface ISuppliersPresenter
    {
        /// <summary>
        /// Подія зміни посилання на сторінку обраного постачальника
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Повертає екземпляр представлення списку постачальників
        /// </summary>
        /// <returns>Екземпляр представлення списку постачальників</returns>
        ISuppliersUC GetSuppliersUC();
    }
}
