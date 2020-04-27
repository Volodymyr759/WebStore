using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    public interface ICategoriesDetailPresenter
    {
        /// <summary>
        /// Подія готовності форми для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowCategoriesDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження категорії товарів постачальника
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування категорії товарів постачальника
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування категорії товарів постачальника</returns>
        ICategoriesDetailUC GetCategoriesDetailUC();

        /// <summary>
        /// Налаштування форми вводу даних для створення нової категорії товарів постачальника
        /// </summary>
        void SetupCategoriesDetailForAdd();

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючої категорії товарів постачальника
        /// </summary>
        /// <param name="id">id існуючої категорії товарів постачальника</param>
        void SetupCategoriesDetailForEdit(int id);
    }
}
