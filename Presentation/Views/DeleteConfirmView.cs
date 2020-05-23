using System;
using System.Windows.Forms;
using Common;

namespace Presentation
{
    /// <summary>
    /// Універсальна форма підтвердження видалення запису
    /// </summary>
    public partial class DeleteConfirmView : Form, IDeleteConfirmView
    {
        /// <summary>
        /// Подія підтвердження видалення запису
        /// </summary>
        public event EventHandler DeleteConfirmViewOKEventRaised;

        int idToDelete;

        string usercontrolName;

        /// <summary>
        /// Конструктор форми підтвердження видалення запису
        /// </summary>
        public DeleteConfirmView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Відображає форму підтвердження видалення запису
        /// </summary>
        /// <param name="windowTitle">Заголовок форми</param>
        /// <param name="deleteConfirmMessage">Текст повідомлення про видалення запису</param>
        /// <param name="idToDelete">Ідентифікатор запису</param>
        /// <param name="usercontrolName">Назва представлення, яке звернулось до форми підтвердження</param>
        public void ShowDeleteConfirmMessageView(string windowTitle, string deleteConfirmMessage, int idToDelete, string usercontrolName)
        {
            this.Text = windowTitle;
            labelMessage.Text = deleteConfirmMessage;
            this.idToDelete = idToDelete;
            this.usercontrolName = usercontrolName;
            this.ShowDialog();
        }

        /// <summary>
        /// Повертає ідентифікатор запису, яка має бути видалена
        /// </summary>
        /// <returns>Ідентифікатор запису</returns>
        public int GetIdToDelete() => idToDelete;

        /// <summary>
        /// Повертає назву представлення, яке звернулось до форми підтвердження
        /// </summary>
        /// <returns>Назва представлення</returns>
        public string GetUserControlName() => usercontrolName;

        private void DeleteConfirmView_Load(object sender, EventArgs e)
        {
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteConfirmViewOKEventRaised, new EventArgs());
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
