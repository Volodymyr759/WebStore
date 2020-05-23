using System;
using System.Windows.Forms;

namespace Presentation
{
    /// <summary>
    /// Універсальна форма відображення повідомлення про помилку
    /// </summary>
    public partial class ErrorMessageView : Form, IErrorMessageView
    {
        /// <summary>
        /// Конструктор універсальної форми відображення помилки
        /// </summary>
        public ErrorMessageView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Відображає форму повідомлення про помилку
        /// </summary>
        /// <param name="windowTitle">Заголовок форми</param>
        /// <param name="errorMessage">Текст повідомлення про помилку</param>
        public void ShowErrorMessageView(string windowTitle, string errorMessage)
        {
            this.Text = windowTitle;
            this.messageTextBox.Text = errorMessage;
            this.ShowDialog();
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (messageTextBox.Text != "")
            {
                Clipboard.SetText(messageTextBox.Text);
            }
        }

        private void ErrorMessageView_Load(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
