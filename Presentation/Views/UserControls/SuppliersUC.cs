using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення списку постачальників
    /// </summary>
    public partial class SuppliersUC : UserControl, ISuppliersUC
    {
        private IErrorMessageView errorMessageView;

        private SortOrder orderOfSort = SortOrder.Ascending;

        /// <summary>
        /// Подія виклику представлення для створення нового постачальника
        /// </summary>
        public event EventHandler AddNewSupplierEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраного постачальника
        /// </summary>
        public event EventHandler EditSupplierEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення постачальника
        /// </summary>
        public event EventHandler DeleteSupplierEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного постачальника
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку постачальників
        /// </summary>
        public event EventHandler<DataEventArgs> SortSuppliersByBindingPropertyNameEventRaised;

        /// <summary>
        /// Кноструктор представлення списку постачальників
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public SuppliersUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Налаштування даних в представленні списку постачальників
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку постачальників</param>
        public void SetupControls(BindingSource bindingSource)
        {
            dgvSuppliers.DataSource = bindingSource;
            dgvSuppliers.Columns["Id"].HeaderText = "Id";
            dgvSuppliers.Columns["Id"].Width = 20;
            dgvSuppliers.Columns["Id"].Visible = false;
            dgvSuppliers.Columns["Id"].DisplayIndex = 0;

            dgvSuppliers.Columns["Name"].HeaderText = "Назва";
            dgvSuppliers.Columns["Name"].Width = 100;
            dgvSuppliers.Columns["Name"].DisplayIndex = 1;

            dgvSuppliers.Columns["Link"].HeaderText = "Сайт";
            dgvSuppliers.Columns["Link"].Width = 100;
            dgvSuppliers.Columns["Link"].DisplayIndex = 2;

            dgvSuppliers.Columns["Currency"].HeaderText = "Валюта";
            dgvSuppliers.Columns["Currency"].Width = 100;
            dgvSuppliers.Columns["Currency"].DisplayIndex = 3;

            dgvSuppliers.Columns["Notes"].HeaderText = "Опис";
            dgvSuppliers.Columns["Notes"].Width = 100;
            dgvSuppliers.Columns["Notes"].DisplayIndex = 4;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20,
                DisplayIndex = 5
            };

            if (dgvSuppliers.Columns["Options"] == null) dgvSuppliers.Columns.Add(imageColumn);

            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, AddNewSupplierEventRaised, e);
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
                EventHelper.RaiseEvent(this, EditSupplierEventRaised, e);
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
                EventHelper.RaiseEvent(this, DeleteSupplierEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSuppliers.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    if (dgvSuppliers.AreAllCellsSelected(true) == false)
                    {
                        var modelDictionary = new Dictionary<string, string> { { "Link", dgvSuppliers.SelectedCells[3].Value.ToString() } };
                        EventHelper.RaiseEvent(this, LinkToSearchChangedInUCEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvSuppliers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvSuppliers.Columns[e.ColumnIndex].Name != "Options")
                {
                    var sortParameters = new Dictionary<string, string>()
                {
                    { "PropertyName", dgvSuppliers.Columns[e.ColumnIndex].Name },
                    { "OrderOfSort", orderOfSort.ToString() }
                };
                    dgvSuppliers.DataSource = null;
                    EventHelper.RaiseEvent(this, SortSuppliersByBindingPropertyNameEventRaised, new DataEventArgs { ModelDictionary = sortParameters });
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
