using Common;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення списку товарів постачальників
    /// </summary>
    public interface IProductsPresenter
    {
        /// <summary>
        /// Подія зміни посилання на сторінку обраного товару постачальника
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Повертає екземпляр представлення списку товарів постачальників
        /// </summary>
        /// <returns>Екземпляр представлення списку товарів постачальників</returns>
        IProductsUC GetProductsUC();

        /// <summary>
        /// Завантаження списку нових товарів з джерел постачальників
        /// </summary>
        /// <returns>>Екземпляр представлення списку товарів постачальників</returns>
        IProductsUC GetNewProducts();

        /// <summary>
        /// Перевіряє наявність збережених товарів у джерелах постачальників
        /// </summary>
        /// <returns>>Екземпляр представлення списку товарів постачальників</returns>
        IProductsUC CheckAvailability();

        /// <summary>
        /// Перевіряє ціни збережених товарів у джерелах постачальників
        /// </summary>
        /// <returns>>Екземпляр представлення списку товарів постачальників</returns>
        IProductsUC CheckPrices();
    }
}
