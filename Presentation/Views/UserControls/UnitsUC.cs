using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення списку одиниць виміру
    /// </summary>
    public partial class UnitsUC : UserControl, IUnitsUC
    {
        private IErrorMessageView errorMessageView;

        private SortOrder orderOfSort = SortOrder.Ascending;

        /// <summary>
        /// Подія виклику представлення для створення нової одиниці виміру
        /// </summary>
        public event EventHandler AddNewUnitEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної одиниці виміру
        /// </summary>
        public event EventHandler EditUnitEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення одиниці виміру
        /// </summary>
        public event EventHandler DeleteUnitEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку одиниць виміру
        /// </summary>
        public event EventHandler<DataEventArgs> SortUnitsByBindingPropertyNameEventRaised;

        /// <summary>
        /// Конструктор представлення списку одиниць виміру
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public UnitsUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Налаштування даних в представленні списку одиниць виміру
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку одиниць виміру</param>
        public void SetupControls(BindingSource bindingSource)
        {
            dgvUnits.DataSource = bindingSource;
            dgvUnits.Columns["Id"].HeaderText = "Id";
            dgvUnits.Columns["Id"].DisplayIndex = 0;
            dgvUnits.Columns["Id"].Width = 20;
            dgvUnits.Columns["Id"].Visible = false;

            dgvUnits.Columns["Name"].HeaderText = "Назва";
            dgvUnits.Columns["Name"].Width = 50;
            dgvUnits.Columns["Name"].DisplayIndex = 1;

            dgvUnits.Columns["Notes"].HeaderText = "Опис";
            dgvUnits.Columns["Notes"].Width = 140;
            dgvUnits.Columns["Notes"].DisplayIndex = 2;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                DisplayIndex = 3,
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
            try
            {
                EventHelper.RaiseEvent(this, AddNewUnitEventRaised, e);
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
                EventHelper.RaiseEvent(this, EditUnitEventRaised, e);
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
                EventHelper.RaiseEvent(this, DeleteUnitEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvUnits_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvUnits.Columns[e.ColumnIndex].Name != "Options")
                {
                    var sortParameters = new Dictionary<string, string>()
                {
                    { "PropertyName", dgvUnits.Columns[e.ColumnIndex].Name },
                    { "OrderOfSort", orderOfSort.ToString() }
                };
                    dgvUnits.DataSource = null;
                    EventHelper.RaiseEvent(this, SortUnitsByBindingPropertyNameEventRaised, new DataEventArgs { ModelDictionary = sortParameters });
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
