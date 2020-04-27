using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class ParametersUC : UserControl, IParametersUC
    {
        public event EventHandler AddNewParameterEventRaised;

        public event EventHandler EditParameterEventRaised;

        public event EventHandler DeleteParameterEventRaised;

        public ParametersUC()
        {
            InitializeComponent();
        }

        public void SetupControls(BindingSource bindingSource)
        {
            dgvParameters.DataSource = bindingSource;
            dgvParameters.Columns["Id"].HeaderText = "Id";
            dgvParameters.Columns["Name"].HeaderText = "Характеристика";
            dgvParameters.Columns["ProductName"].HeaderText = "Товар";
            dgvParameters.Columns["UnitName"].HeaderText = "Од. вим.";
            dgvParameters.Columns["Value"].HeaderText = "Значення";

            dgvParameters.Columns["Id"].Width = 20;
            dgvParameters.Columns["Id"].Visible = false;
            dgvParameters.Columns["Name"].Width = 100;
            dgvParameters.Columns["ProductName"].Width = 100;
            dgvParameters.Columns["UnitName"].Width = 100;
            dgvParameters.Columns["Value"].Width = 100;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20
            };

            if (dgvParameters.Columns["Options"] == null) dgvParameters.Columns.Add(imageColumn);

            dgvParameters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParameters.AllowUserToAddRows = false;
            dgvParameters.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, AddNewParameterEventRaised, e);
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, EditParameterEventRaised, e);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteParameterEventRaised, e);
        }

        #endregion

        #region Menu Options

        private void DgvParameters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvParameters.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvParameters_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvParameters.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvParameters_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvParameters.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
