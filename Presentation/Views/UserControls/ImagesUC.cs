using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class ImagesUC : UserControl, IImagesUC
    {
        public event EventHandler AddNewImageEventRaised;

        public event EventHandler EditImageEventRaised;

        public event EventHandler DeleteImageEventRaised;

        public ImagesUC()
        {
            InitializeComponent();
        }

        public void SetupControls(BindingSource bindingSource)
        {
            dgvImages.DataSource = bindingSource;
            dgvImages.Columns["Id"].HeaderText = "Id";
            dgvImages.Columns["FileName"].HeaderText = "Файл";
            dgvImages.Columns["ProductName"].HeaderText = "Товар";
            dgvImages.Columns["LinkWebStore"].HeaderText = "Лінк";
            dgvImages.Columns["LinkSupplier"].HeaderText = "Лінк постачальника";
            dgvImages.Columns["LocalPath"].HeaderText = "Шлях";

            dgvImages.Columns["Id"].Width = 20;
            dgvImages.Columns["Id"].Visible = false;
            dgvImages.Columns["FileName"].Width = 100;
            dgvImages.Columns["ProductName"].Width = 100;
            dgvImages.Columns["LinkWebStore"].Width = 100;
            dgvImages.Columns["LinkSupplier"].Width = 100;
            dgvImages.Columns["LocalPath"].Width = 100;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20
            };

            if (dgvImages.Columns["Options"] == null) dgvImages.Columns.Add(imageColumn);

            dgvImages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImages.AllowUserToAddRows = false;
            dgvImages.ReadOnly = true;

        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, AddNewImageEventRaised, e);
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, EditImageEventRaised, e);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteImageEventRaised, e);
        }

        #endregion

        #region Menu Options

        private void DgvImages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvImages.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvImages_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvImages.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvImages_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvImages.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
