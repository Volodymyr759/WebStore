namespace Presentation
{
    /// <summary>
    /// Інтерфейс універсальної форми відображення помилки
    /// </summary>
    public interface IErrorMessageView
    {
        /// <summary>
        /// Відображає форму повідомлення про помилку
        /// </summary>
        /// <param name="windowTitle">Заголовок форми</param>
        /// <param name="errorMessage">Текст повідомлення про помилку</param>
        void ShowErrorMessageView(string windowTitle, string errorMessage);
    }
}