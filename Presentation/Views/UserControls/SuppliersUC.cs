using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class SuppliersUC : UserControl, ISuppliersUC
    {
        public event EventHandler AddNewSupplierEventRaised;

        public event EventHandler EditSupplierEventRaised;

        public event EventHandler DeleteSupplierEventRaised;

        public SuppliersUC()
        {
            InitializeComponent();
        }

        public void SetupControls(BindingSource bindingSource)
        {
            dgvSuppliers.DataSource = bindingSource;
            dgvSuppliers.Columns["Id"].HeaderText = "Id";
            dgvSuppliers.Columns["Name"].HeaderText = "Назва";
            dgvSuppliers.Columns["Link"].HeaderText = "Сайт";
            dgvSuppliers.Columns["Currency"].HeaderText = "Валюта";
            dgvSuppliers.Columns["Notes"].HeaderText = "Опис";

            dgvSuppliers.Columns["Id"].Width = 20;
            dgvSuppliers.Columns["Id"].Visible = false;
            dgvSuppliers.Columns["Name"].Width = 100;
            dgvSuppliers.Columns["Link"].Width = 100;
            dgvSuppliers.Columns["Currency"].Width = 100;
            dgvSuppliers.Columns["Notes"].Width = 100;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20
            };

            if (dgvSuppliers.Columns["Options"] == null) dgvSuppliers.Columns.Add(imageColumn);

            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.ReadOnly = true;

        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, AddNewSupplierEventRaised, e);
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, EditSupplierEventRaised, e);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteSupplierEventRaised, e);
        }

        #endregion

        #region Menu Options

        private void DgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSuppliers.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvSuppliers_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvSuppliers.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvSuppliers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvSuppliers.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
