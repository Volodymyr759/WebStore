using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    public interface ISuppliersDetailPresenter
    {
        /// <summary>
        /// Подія готовності форми для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowSuppliersDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження постачальника
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування постачальника
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування постачальника</returns>
        ISuppliersDetailUC GetSuppliersDetailUC();

        /// <summary>
        /// Налаштування форми вводу даних для створення нового постачальника
        /// </summary>
        void SetupSuppliersDetailForAdd();

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючого постачальника
        /// </summary>
        /// <param name="id">id існуючого постачальника</param>
        void SetupSuppliersDetailForEdit(int id);
    }
}
