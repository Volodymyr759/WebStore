using Common;
using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class ProductsUC : UserControl, IProductsUC
    {
        public event EventHandler AddNewProductEventRaised;

        public event EventHandler EditProductEventRaised;

        public event EventHandler DeleteProductEventRaised;

        public ProductsUC()
        {
            InitializeComponent();
        }

        public void SetupControls(BindingSource bindingSource)
        {
            dgvProducts.DataSource = bindingSource;
            dgvProducts.Columns["Id"].HeaderText = "Id";
            dgvProducts.Columns["NameWebStore"].HeaderText = "Назва";
            dgvProducts.Columns["NameSupplier"].HeaderText = "Назва постачальника";
            dgvProducts.Columns["SupplierName"].HeaderText = "Постачальник";
            dgvProducts.Columns["CategoryName"].HeaderText = "Категорія постачальника";
            dgvProducts.Columns["GroupName"].HeaderText = "Група Prom";
            dgvProducts.Columns["UnitName"].HeaderText = "Од. вим.";
            dgvProducts.Columns["CodeWebStore"].HeaderText = "Код";
            dgvProducts.Columns["CodeSupplier"].HeaderText = "Код постачальника";
            dgvProducts.Columns["PriceWebStore"].HeaderText = "Ціна";
            dgvProducts.Columns["PriceSupplier"].HeaderText = "Ціна постачальника";
            dgvProducts.Columns["Currency"].HeaderText = "Валюта";
            dgvProducts.Columns["Available"].HeaderText = "Наявно";
            dgvProducts.Columns["LinkWebStore"].HeaderText = "Лінк";
            dgvProducts.Columns["LinkSupplier"].HeaderText = "Лінк постачальника";
            dgvProducts.Columns["Notes"].HeaderText = "Опис";

            dgvProducts.Columns["Id"].Width = 20;
            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["NameWebStore"].Width = 100;
            dgvProducts.Columns["NameSupplier"].Width = 100;
            dgvProducts.Columns["SupplierName"].Width = 100;
            dgvProducts.Columns["CategoryName"].Width = 100;
            dgvProducts.Columns["GroupName"].Width = 100;
            dgvProducts.Columns["UnitName"].Width = 100;
            dgvProducts.Columns["CodeWebStore"].Width = 100;
            dgvProducts.Columns["CodeSupplier"].Width = 100;
            dgvProducts.Columns["PriceWebStore"].Width = 100;
            dgvProducts.Columns["PriceSupplier"].Width = 100;
            dgvProducts.Columns["Currency"].Width = 100;
            dgvProducts.Columns["Available"].Width = 100;
            dgvProducts.Columns["LinkWebStore"].Width = 100;
            dgvProducts.Columns["LinkSupplier"].Width = 100;
            dgvProducts.Columns["Notes"].Width = 100;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20
            };

            if (dgvProducts.Columns["Options"] == null) dgvProducts.Columns.Add(imageColumn);

            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, AddNewProductEventRaised, e);
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, EditProductEventRaised, e);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, DeleteProductEventRaised, e);
        }

        #endregion

        #region Menu Options

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProducts.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvProducts_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvProducts.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvProducts_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvProducts.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
