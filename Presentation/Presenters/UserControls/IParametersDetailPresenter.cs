using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    public interface IParametersDetailPresenter
    {
        /// <summary>
        /// Подія готовності форми для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowParametersDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування характеристики
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування характеристики</returns>
        IParametersDetailUC GetParametersDetailUC();

        /// <summary>
        /// Налаштування форми вводу даних для створення нової характеристики
        /// </summary>
        void SetupParametersDetailForAdd();

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючої характеристики
        /// </summary>
        /// <param name="id">id існуючої характеристики</param>
        void SetupParametersDetailForEdit(int id);
    }
}
