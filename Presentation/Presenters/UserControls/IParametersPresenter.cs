using Presentation.Views.UserControls;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Інтерфейс презентера представлення списку характеристик товару
    /// </summary>
    public interface IParametersPresenter
    {
        /// <summary>
        /// Повертає екземпляр представлення списку характеристик товару
        /// </summary>
        /// <returns>Екземпляр представлення категорій постачальників</returns>
        IParametersUC GetParametersUC();

        /// <summary>
        /// Завантаження характеристик товарів з джерел постачальників
        /// </summary>
        /// <returns>Екземпляр представлення категорій постачальників</returns>
        IParametersUC LoadParameters();
    }
}
