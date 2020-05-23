using System;

namespace Presentation
{
    /// <summary>
    /// Інтерфейс універсальної форми підтвердження видалення запису
    /// </summary>
    public interface IDeleteConfirmView
    {
        /// <summary>
        /// Подія підтвердження видалення запису
        /// </summary>
        event EventHandler DeleteConfirmViewOKEventRaised;

        /// <summary>
        /// Повертає ідентифікатор запису, яка має бути видалена
        /// </summary>
        /// <returns>Ідентифікатор запису</returns>
        int GetIdToDelete();

        /// <summary>
        /// Повертає назву представлення, яке звернулось до форми підтвердження
        /// </summary>
        /// <returns>Назва представлення</returns>
        string GetUserControlName();

        /// <summary>
        /// Відображає форму підтвердження видалення запису
        /// </summary>
        /// <param name="windowTitle">Заголовок форми</param>
        /// <param name="deleteConfirmMessage">Текст повідомлення про видалення запису</param>
        /// <param name="idToDelete">Ідентифікатор запису</param>
        /// <param name="usercontrolName">Назва представлення, яке звернулось до форми підтвердження</param>
        void ShowDeleteConfirmMessageView(string windowTitle, string deleteConfirmMessage, int idToDelete, string usercontrolName);
    }
}