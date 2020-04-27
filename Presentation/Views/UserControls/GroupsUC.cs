using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class GroupsUC : UserControl, IGroupsUC
    {
        public event EventHandler AddNewGroupEventRaised;

        public event EventHandler EditGroupEventRaised;

        public event EventHandler DeleteGroupEventRaised;

        public GroupsUC()
        {
            InitializeComponent();
        }

        public void SetupControls(BindingSource bindingSource)
        {
            dgvGroups.DataSource = bindingSource;
            dgvGroups.Columns["Id"].HeaderText = "Id";
            dgvGroups.Columns["Name"].HeaderText = "Назва";
            dgvGroups.Columns["Number"].HeaderText = "Номер";
            dgvGroups.Columns["Identifier"].HeaderText = "Ідентифікатор";
            dgvGroups.Columns["AncestorNumber"].HeaderText = "Предок номер";
            dgvGroups.Columns["AncestorIdentifier"].HeaderText = "Предок ідентифікатор";
            dgvGroups.Columns["ProductType"].HeaderText = "Тип товару";
            dgvGroups.Columns["Link"].HeaderText = "Лінк";
            dgvGroups.Columns["Notes"].HeaderText = "Опис";

            dgvGroups.Columns["Id"].Width = 20;
            dgvGroups.Columns["Id"].Visible = false;
            dgvGroups.Columns["Name"].Width = 100;
            dgvGroups.Columns["Number"].Width = 100;
            dgvGroups.Columns["Identifier"].Width = 100;
            dgvGroups.Columns["AncestorNumber"].Width = 100;
            dgvGroups.Columns["AncestorIdentifier"].Width = 100;
            dgvGroups.Columns["ProductType"].Width = 100;
            dgvGroups.Columns["Link"].Width = 100;
            dgvGroups.Columns["Notes"].Width = 100;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20
            };

            if (dgvGroups.Columns["Options"] == null) dgvGroups.Columns.Add(imageColumn);

            dgvGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGroups.AllowUserToAddRows = false;
            dgvGroups.ReadOnly = true;

        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, AddNewGroupEventRaised, e);
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, EditGroupEventRaised, e);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteGroupEventRaised, e);
        }

        #endregion

        #region Menu Options

        private void DgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGroups.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvGroups_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvGroups.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvGroups_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvGroups.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion

    }
}
