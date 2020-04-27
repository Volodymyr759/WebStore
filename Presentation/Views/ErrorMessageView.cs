using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class ErrorMessageView : Form, IErrorMessageView
    {
        public ErrorMessageView()
        {
            InitializeComponent();
        }

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
