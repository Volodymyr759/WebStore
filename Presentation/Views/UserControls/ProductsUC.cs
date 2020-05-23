using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class ProductsUC : UserControl, IProductsUC
    {
        private IErrorMessageView errorMessageView;

        private SortOrder orderOfSort = SortOrder.Ascending;

        /// <summary>
        /// Подія виклику представлення для створення нового товару
        /// </summary>
        public event EventHandler AddNewProductEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраного товару
        /// </summary>
        public event EventHandler EditProductEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення товару
        /// </summary>
        public event EventHandler DeleteProductEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного товару
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку товарів
        /// </summary>
        public event EventHandler<DataEventArgs> SortProductsByBindingPropertyNameEventRaised;

        /// <summary>
        /// Конструктор представлення списку товарів
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public ProductsUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Налаштування даних в представленні списку товарів постачальників
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку товарів</param>
        public void SetupControls(BindingSource bindingSource)
        {   // ініціалізація dgvProducts відрізняється через неправильний порядок стовпців при початковому завантаженні
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AutoSize = true;
            dgvProducts.DataSource = bindingSource;

            if (dgvProducts.Columns["Id"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "Id", Width = 20, Visible = false });
            if (dgvProducts.Columns["SupplierId"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "SupplierId", DataPropertyName = "SupplierId", HeaderText = "SupplierId", Width = 20, Visible = false });
            if (dgvProducts.Columns["CategoryId"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "CategoryId", DataPropertyName = "CategoryId", HeaderText = "CategoryId", Width = 20, Visible = false });
            if (dgvProducts.Columns["GroupId"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "GroupId", DataPropertyName = "GroupId", HeaderText = "GroupId", Width = 20, Visible = false });
            if (dgvProducts.Columns["UnitId"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitId", DataPropertyName = "UnitId", HeaderText = "UnitId", Width = 20, Visible = false });
            if (dgvProducts.Columns["NameWebStore"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "NameWebStore", DataPropertyName = "NameWebStore", HeaderText = "Назва", Width = 100, DisplayIndex = 0 });
            if (dgvProducts.Columns["NameSupplier"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "NameSupplier", DataPropertyName = "NameSupplier", HeaderText = "Назва постачальника", Width = 100, DisplayIndex = 1 });
            if (dgvProducts.Columns["SupplierName"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "SupplierName", DataPropertyName = "SupplierName", HeaderText = "Постачальник", Width = 100, DisplayIndex = 2 });
            if (dgvProducts.Columns["CategoryName"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CategoryName",
                    DataPropertyName = "CategoryName",
                    HeaderText = "Категорія",
                    Width = 100,
                    DisplayIndex = 3
                });
            if (dgvProducts.Columns["GroupName"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "GroupName",
                    DataPropertyName = "GroupName",
                    HeaderText = "Група",
                    Width = 100,
                    DisplayIndex = 4
                });
            if (dgvProducts.Columns["UnitName"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "UnitName",
                    DataPropertyName = "UnitName",
                    HeaderText = "Од.",
                    Width = 30,
                    DisplayIndex = 5
                });
            if (dgvProducts.Columns["CodeWebStore"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CodeWebStore",
                    DataPropertyName = "CodeWebStore",
                    HeaderText = "Код",
                    Width = 100,
                    DisplayIndex = 6
                });
            if (dgvProducts.Columns["CodeSupplier"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CodeSupplier",
                    DataPropertyName = "CodeSupplier",
                    HeaderText = "Код постачальника",
                    Width = 100,
                    DisplayIndex = 7
                });
            if (dgvProducts.Columns["PriceWebStore"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PriceWebStore",
                    DataPropertyName = "PriceWebStore",
                    HeaderText = "Ціна",
                    Width = 80,
                    DisplayIndex = 8
                });

            dgvProducts.Columns["PriceWebStore"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dgvProducts.Columns["PriceSupplier"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PriceSupplier",
                    DataPropertyName = "PriceSupplier",
                    HeaderText = "Ціна постачальника",
                    Width = 80,
                    DisplayIndex = 9
                });
            dgvProducts.Columns["PriceSupplier"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dgvProducts.Columns["Currency"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Currency",
                    DataPropertyName = "Currency",
                    HeaderText = "Валюта",
                    Width = 60,
                    DisplayIndex = 10
                });
            if (dgvProducts.Columns["Available"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Available",
                    DataPropertyName = "Available",
                    HeaderText = "Наявно",
                    Width = 40,
                    DisplayIndex = 11
                });
            if (dgvProducts.Columns["LinkWebStore"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "LinkWebStore",
                    DataPropertyName = "LinkWebStore",
                    HeaderText = "Лінк",
                    Width = 100,
                    DisplayIndex = 12
                });
            if (dgvProducts.Columns["LinkSupplier"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "LinkSupplier",
                    DataPropertyName = "LinkSupplier",
                    HeaderText = "Лінк постачальника",
                    Width = 100,
                    DisplayIndex = 13
                });
            if (dgvProducts.Columns["Notes"] == null)
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Notes",
                    DataPropertyName = "Notes",
                    HeaderText = "Опис",
                    Width = 100,
                    DisplayIndex = 14
                });

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "Options",
                HeaderText = "Опції",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20,
                DisplayIndex = 15
            };
            dgvProducts.Columns.Add(imageColumn);

            if (dgvProducts.Columns["Options"] == null) dgvProducts.Columns.Add(imageColumn);
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, AddNewProductEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, EditProductEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, DeleteProductEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    if (dgvProducts.AreAllCellsSelected(true) == false)
                    {
                        var modelDictionary = new Dictionary<string, string> { { "Link", dgvProducts.SelectedCells[18].Value.ToString() } };
                        EventHelper.RaiseEvent(this, LinkToSearchChangedInUCEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvProducts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProducts.Columns[e.ColumnIndex].Name != "Options")
                {
                    var sortParameters = new Dictionary<string, string>()
                {
                    { "PropertyName", dgvProducts.Columns[e.ColumnIndex].Name },
                    { "OrderOfSort", orderOfSort.ToString() }
                };
                    dgvProducts.DataSource = null;
                    EventHelper.RaiseEvent(this, SortProductsByBindingPropertyNameEventRaised, new DataEventArgs { ModelDictionary = sortParameters });
                    orderOfSort = (orderOfSort == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                }
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
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
