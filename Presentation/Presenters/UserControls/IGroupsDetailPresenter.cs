using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    public interface IGroupsDetailPresenter
    {
        /// <summary>
        /// Подія готовності форми для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowGroupsDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження групи prom.ua
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування групи prom.ua
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування групи prom.ua</returns>
        IGroupsDetailUC GetGroupsDetailUC();

        /// <summary>
        /// Налаштування форми вводу даних для створення нової групи prom.ua
        /// </summary>
        void SetupGroupsDetailForAdd();

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючої групи prom.ua
        /// </summary>
        /// <param name="id">id існуючої групи prom.ua</param>
        void SetupGroupsDetailForEdit(int id);
    }
}
