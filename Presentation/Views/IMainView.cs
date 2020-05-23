using System;
using System.Windows.Forms;

namespace Presentation
{
    /// <summary>
    /// Інтерфейс головної форми
    /// </summary>
    public interface IMainView
    {
        #region Меню Файл
        
        /// <summary>
        /// Подія вибору експорту товарів у файл Сsv
        /// </summary>
        event EventHandler ExportСsvMenuClickEventRaised;

        /// <summary>
        /// Подія вибору експорту товарів у файл Xml
        /// </summary>
        event EventHandler ExportXmlMenuClickEventRaised;

        #endregion

        #region Меню Довідники

        /// <summary>
        /// Подія вибору довідника одиниць виміру
        /// </summary>
        event EventHandler UnitsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника зображень товарів
        /// </summary>
        event EventHandler ImagesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника характеристик товарів
        /// </summary>
        event EventHandler ParametersMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника постачальників
        /// </summary>
        event EventHandler SuppliersMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника груп власного каталогу
        /// </summary>
        event EventHandler GroupsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника категорій постачальників
        /// </summary>
        event EventHandler CategoriesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника товарів
        /// </summary>
        event EventHandler ProductsMenuClickEventRaised;

        #endregion


        #region Меню Сервіс

        /// <summary>
        /// Подія вибору меню налаштувань
        /// </summary>
        event EventHandler SettingsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження нових товарів
        /// </summary>
        event EventHandler FindNewProductsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження застарілих товарів
        /// </summary>
        event EventHandler FindOldProductsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню перевірки наявності товарів у постачальників
        /// </summary>
        event EventHandler CheckAvailabilityMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню перевірки цін товарів постачальників
        /// </summary>
        event EventHandler CheckPricesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження зображень товарів
        /// </summary>
        event EventHandler GetImagesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження характеристик товарів
        /// </summary>
        event EventHandler GetParametersMenuClickEventRaised;

        #endregion

        #region Helpers

        /// <summary>
        /// Подія завантаження головної форми
        /// </summary>
        event EventHandler MainViewLoadedEventRaised;

        /// <summary>
        /// Завантаження головної форми
        /// </summary>
        void ShowMainView();

        /// <summary>
        /// Повертає основну панель головної форми
        /// </summary>
        Panel GetMainPanel();

        /// <summary>
        /// Повертає праву панель головної форми
        /// </summary>
        Panel GetRightPanel();

        /// <summary>
        /// Повертає елемент для переходу на сторінку за посиланням
        /// </summary>
        ToolStripTextBox GetToolStripSearchBox();

        #endregion
    }
    }
