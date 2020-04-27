using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class CategoriesUC : UserControl, ICategoriesUC
    {
        public event EventHandler AddNewCategoryEventRaised;

        public event EventHandler EditCategoryEventRaised;

        public event EventHandler DeleteCategoryEventRaised;

        public CategoriesUC()
        {
            InitializeComponent();
        }

        public void SetupControls(BindingSource bindingSource)
        {
            dgvCategories.DataSource = bindingSource;
            dgvCategories.Columns["Id"].HeaderText = "Id";
            dgvCategories.Columns["Name"].HeaderText = "Назва";
            dgvCategories.Columns["SupplierName"].HeaderText = "Постачальник";
            dgvCategories.Columns["Link"].HeaderText = "Лінк";
            dgvCategories.Columns["Rate"].HeaderText = "Курс";
            dgvCategories.Columns["Notes"].HeaderText = "Опис";


            dgvCategories.Columns["Id"].Width = 20;
            dgvCategories.Columns["Id"].Visible = false;
            dgvCategories.Columns["Name"].Width = 100;
            dgvCategories.Columns["SupplierName"].Width = 100;
            dgvCategories.Columns["Link"].Width = 100;
            dgvCategories.Columns["Rate"].Width = 100;
            dgvCategories.Columns["Notes"].Width = 100;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20
            };

            if (dgvCategories.Columns["Options"] == null) dgvCategories.Columns.Add(imageColumn);

            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, AddNewCategoryEventRaised, e);
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, EditCategoryEventRaised, e);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteCategoryEventRaised, e);
        }

        #endregion

        #region Menu Options

        private void DgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCategories.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvCategories_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvCategories.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvCategories_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvCategories.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
