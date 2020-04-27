using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class UnitsUC : UserControl, IUnitsUC
    {
        public event EventHandler AddNewUnitEventRaised;

        public event EventHandler EditUnitEventRaised;

        public event EventHandler DeleteUnitEventRaised;

        public UnitsUC()
        {
            InitializeComponent();
        }

        public void SetupControls(BindingSource bindingSource)
        {
            dgvUnits.DataSource = bindingSource;
            dgvUnits.Columns["Id"].HeaderText = "Id";
            dgvUnits.Columns["Name"].HeaderText = "Назва";
            dgvUnits.Columns["Notes"].HeaderText = "Опис";

            dgvUnits.Columns["Id"].Width = 20;
            dgvUnits.Columns["Id"].Visible = false;
            dgvUnits.Columns["Name"].Width = 50;
            dgvUnits.Columns["Notes"].Width = 100;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20
            };

            if (dgvUnits.Columns["Options"] == null) dgvUnits.Columns.Add(imageColumn);

            dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnits.AllowUserToAddRows = false;
            dgvUnits.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, AddNewUnitEventRaised, e);
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, EditUnitEventRaised, e);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteUnitEventRaised, e);
        }

        #endregion

        #region Menu Options

        private void DgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUnits.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvUnits_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvUnits.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvUnits_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvUnits.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
