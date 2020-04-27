using Presentation.Views.UserControls;

namespace Presentation
{
    /// <summary>
    /// Інтерфейс презентера форми одиниць виміру
    /// </summary>
    public interface IUnitsPresenter
    {
        /// <summary>
        /// Отримання форми списку одиниць виміру
        /// </summary>
        /// <returns>Форма списку одиниць виміру</returns>
        IUnitsUC GetUnitsUC();
    }
}
