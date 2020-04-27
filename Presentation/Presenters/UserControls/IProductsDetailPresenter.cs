using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    public interface IProductsDetailPresenter
    {
        /// <summary>
        /// Подія готовності форми для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowProductsDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження товару
        /// </summary>
        event EventHandler CancelClickEventRaised;

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
