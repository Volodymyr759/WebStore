﻿using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення деталей характеристики товару
    /// </summary>
    public interface IParametersDetailPresenter
    {
        /// <summary>
        /// Подія готовності для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowParametersDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження характеристики товару
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраної характеристики товару
        /// </summary>
        event EventHandler SaveParameterClickEventRaised;

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
