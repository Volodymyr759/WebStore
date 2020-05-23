using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення деталей товару постачальника
    /// </summary>
    public interface IProductsDetailPresenter
    {
        /// <summary>
        /// Подія готовності для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowProductsDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження товару
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраного товару
        /// </summary>
        event EventHandler SaveProductClickEventRaised;

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування товару
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування товару</returns>
        IProductsDetailUC GetProductsDetailUC();

        /// <summary>
        /// Налаштування форми вводу даних для створення нового товару
        /// </summary>
        void SetupProductsDetailForAdd();

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючого товару
        /// </summary>
        /// <param name="id">id існуючого товару</param>
        void SetupProductsDetailForEdit(int id);

    }
}
