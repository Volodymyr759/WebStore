using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    public interface IImagesDetailPresenter
    {
        /// <summary>
        /// Подія готовності форми для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowImagesDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження зображення
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування зображення
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування зображення</returns>
        IImagesDetailUC GetImagesDetailUC();

        /// <summary>
        /// Налаштування форми вводу даних для створення нового зображення
        /// </summary>
        void SetupImagesDetailForAdd();

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючого зображення
        /// </summary>
        /// <param name="id">id існуючого зображення</param>
        void SetupImagesDetailForEdit(int id);
    }
}
