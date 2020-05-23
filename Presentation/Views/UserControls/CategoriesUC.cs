using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення списку категорій постачальників
    /// </summary>
    public partial class CategoriesUC : UserControl, ICategoriesUC
    {
        private IErrorMessageView errorMessageView;

        private SortOrder orderOfSort = SortOrder.Ascending;

        /// <summary>
        /// Подія виклику представлення для створення нової категорії
        /// </summary>
        public event EventHandler AddNewCategoryEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної категорії
        /// </summary>
        public event EventHandler EditCategoryEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення категорії
        /// </summary>
        public event EventHandler DeleteCategoryEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраної категорії
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку категорій
        /// </summary>
        public event EventHandler<DataEventArgs> SortCategoriesByBindingPropertyNameEventRaised;

        /// <summary>
        /// Констрктор представлення списку категорій постачальників
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public CategoriesUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Налаштування даних в представленні списку категорій постачальників
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку категорій</param>
        public void SetupControls(BindingSource bindingSource)
        {
            dgvCategories.DataSource = bindingSource;
            dgvCategories.Columns["Id"].HeaderText = "Id";
            dgvCategories.Columns["Id"].Width = 20;
            dgvCategories.Columns["Id"].Visible = false;
            dgvCategories.Columns["Id"].DisplayIndex = 0;

            dgvCategories.Columns["Name"].HeaderText = "Назва";
            dgvCategories.Columns["Name"].Width = 100;
            dgvCategories.Columns["Name"].DisplayIndex = 1;

            dgvCategories.Columns["SupplierId"].Visible = false;
            dgvCategories.Columns["SupplierId"].DisplayIndex = 2;

            dgvCategories.Columns["SupplierName"].HeaderText = "Постачальник";
            dgvCategories.Columns["SupplierName"].Width = 100;
            dgvCategories.Columns["SupplierName"].DisplayIndex = 3;

            dgvCategories.Columns["Link"].HeaderText = "Лінк";
            dgvCategories.Columns["Link"].Width = 100;
            dgvCategories.Columns["Link"].DisplayIndex = 4;

            dgvCategories.Columns["Rate"].HeaderText = "Курс";
            dgvCategories.Columns["Rate"].Width = 70;
            dgvCategories.Columns["Rate"].DisplayIndex = 5;

            dgvCategories.Columns["Notes"].HeaderText = "Опис";
            dgvCategories.Columns["Notes"].Width = 100;
            dgvCategories.Columns["Notes"].DisplayIndex = 6;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20,
                DisplayIndex = 7
            };

            if (dgvCategories.Columns["Options"] == null) dgvCategories.Columns.Add(imageColumn);

            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, AddNewCategoryEventRaised, e);
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
                EventHelper.RaiseEvent(this, EditCategoryEventRaised, e);
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
                EventHelper.RaiseEvent(this, DeleteCategoryEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategories.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    if (dgvCategories.AreAllCellsSelected(true) == false)
                    {
                        var modelDictionary = new Dictionary<string, string> { { "Link", dgvCategories.SelectedCells[5].Value.ToString() } };
                        EventHelper.RaiseEvent(this, LinkToSearchChangedInUCEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvCategories_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvCategories.Columns[e.ColumnIndex].Name != "Options")
                {
                    var sortParameters = new Dictionary<string, string>()
                {
                    { "PropertyName", dgvCategories.Columns[e.ColumnIndex].Name },
                    { "OrderOfSort", orderOfSort.ToString() }
                };
                    dgvCategories.DataSource = null;
                    EventHelper.RaiseEvent(this, SortCategoriesByBindingPropertyNameEventRaised, new DataEventArgs { ModelDictionary = sortParameters });
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
