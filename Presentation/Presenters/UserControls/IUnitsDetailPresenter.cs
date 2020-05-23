using Presentation.Views.UserControls;
using System;

namespace Presentation
{
    /// <summary>
    /// Інтерфейс форми вводу даних для створення/редагування одиниці виміру
    /// </summary>
    public interface IUnitsDetailPresenter
    {
        /// <summary>
        /// Подія готовності форми для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowUnitsDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження одиниці виміру
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраної одиниці виміру
        /// </summary>
        event EventHandler SaveUnitClickEventRaised;

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування одиниці виміру
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування одиниці виміру</returns>
        IUnitsDetailUC GetUnitsDetailUC();

        /// <summary>
        /// Налаштування форми вводу даних для створення нової одиниці виміру
        /// </summary>
        void SetupUnitsDetailForAdd();

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючої одиниці виміру
        /// </summary>
        /// <param name="id">id існуючої одиниці виміру</param>
        void SetupUnitsDetailForEdit(int id);
    }
}
