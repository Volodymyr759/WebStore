﻿using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення деталей категорії постачальника
    /// </summary>
    public interface ICategoriesDetailPresenter
    {
        /// <summary>
        /// Подія готовності для відображення у головній формі
        /// </summary>
        event EventHandler ReadyToShowCategoriesDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження категорії товарів постачальника
        /// </summary>
        event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраної категорії постачальника
        /// </summary>
        event EventHandler SaveCategoryClickEventRaised;

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
