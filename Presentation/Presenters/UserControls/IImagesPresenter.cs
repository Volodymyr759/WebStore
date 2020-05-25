using Common;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення списку зображень товарів
    /// </summary>
    public interface IImagesPresenter
    {
        /// <summary>
        /// Подія зміни посилання на сторінку обраного зображення товару
        /// </summary>
        event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Повертає екземпляр представлення списку зображень товарів
        /// </summary>
        /// <returns>Екземпляр представлення списку зображень</returns>
        IImagesUC GetImagesUC();

        /// <summary>
        /// Завантаження зображень з джерел даних постачальників
        /// </summary>
        /// <param name="localFolders">Адреси локальних папок для зображень товарів постачальників</param>
        /// <returns></returns>
        IImagesUC LoadImages(string[] localFolders);
    }
}
