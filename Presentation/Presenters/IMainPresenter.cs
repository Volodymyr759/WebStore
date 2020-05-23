namespace Presentation
{
    /// <summary>
    /// Інтерфейс головного презентера
    /// </summary>
    public interface IMainPresenter
    {
        /// <summary>
        /// Повертає головну форму
        /// </summary>
        /// <returns></returns>
        IMainView GetMainView();
    }
}
