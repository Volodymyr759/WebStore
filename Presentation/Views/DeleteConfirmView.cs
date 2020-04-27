using System;
using System.Windows.Forms;
using Common;

namespace Presentation
{
    public partial class DeleteConfirmView : Form, IDeleteConfirmView
    {
        public event EventHandler DeleteConfirmViewOKEventRaised;

        int idToDelete;

        public DeleteConfirmView()
        {
            InitializeComponent();
        }

        public void ShowDeleteConfirmMessageView(string windowTitle, string deleteConfirmMessage, int idToDelete)
        {
            this.Text = windowTitle;
            labelMessage.Text = deleteConfirmMessage;
            this.idToDelete = idToDelete;
            this.ShowDialog();
        }

        public int GetIdToDelete()
        {
            return idToDelete;
        }

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
