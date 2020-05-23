using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення списку характеристик товарів
    /// </summary>
    public partial class ParametersUC : UserControl, IParametersUC
    {
        private IErrorMessageView errorMessageView;

        private SortOrder orderOfSort = SortOrder.Ascending;

        /// <summary>
        /// Подія виклику представлення для створення нової характеристики
        /// </summary>
        public event EventHandler AddNewParameterEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної характеристики
        /// </summary>
        public event EventHandler EditParameterEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення характеристики
        /// </summary>
        public event EventHandler DeleteParameterEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку характеристик товарів
        /// </summary>
        public event EventHandler<DataEventArgs> SortParametersByBindingPropertyNameEventRaised;

        /// <summary>
        /// Конструктор представлення списку характеристик товарів
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public ParametersUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Налаштування даних в представленні списку характеристик товарів
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку характеристик</param>
        public void SetupControls(BindingSource bindingSource)
        {
            dgvParameters.DataSource = bindingSource;
            dgvParameters.Columns["Id"].HeaderText = "Id";
            dgvParameters.Columns["Id"].Width = 20;
            dgvParameters.Columns["Id"].Visible = false;
            dgvParameters.Columns["Id"].DisplayIndex = 0;

            dgvParameters.Columns["Name"].HeaderText = "Характеристика";
            dgvParameters.Columns["Name"].Width = 100;
            dgvParameters.Columns["Name"].DisplayIndex = 1;

            dgvParameters.Columns["ProductId"].HeaderText = "ProductId";
            dgvParameters.Columns["ProductId"].Visible = false;
            dgvParameters.Columns["ProductId"].DisplayIndex = 2;

            dgvParameters.Columns["ProductName"].HeaderText = "Товар";
            dgvParameters.Columns["ProductName"].Width = 100;
            dgvParameters.Columns["ProductName"].DisplayIndex = 3;

            dgvParameters.Columns["UnitId"].HeaderText = "UnitId";
            dgvParameters.Columns["UnitId"].Visible = false;
            dgvParameters.Columns["UnitId"].DisplayIndex = 4;

            dgvParameters.Columns["UnitName"].HeaderText = "Од. вим.";
            dgvParameters.Columns["UnitName"].Width = 100;
            dgvParameters.Columns["UnitName"].DisplayIndex = 5;

            dgvParameters.Columns["Value"].HeaderText = "Значення";
            dgvParameters.Columns["Value"].Width = 100;
            dgvParameters.Columns["Value"].DisplayIndex = 6;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20,
                DisplayIndex = 7
            };

            if (dgvParameters.Columns["Options"] == null) dgvParameters.Columns.Add(imageColumn);

            dgvParameters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParameters.AllowUserToAddRows = false;
            dgvParameters.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, AddNewParameterEventRaised, e);
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
                EventHelper.RaiseEvent(this, EditParameterEventRaised, e);
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
                EventHelper.RaiseEvent(this, DeleteParameterEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvParameters_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvParameters.Columns[e.ColumnIndex].Name != "Options")
                {
                    var sortParameters = new Dictionary<string, string>()
                {
                    { "PropertyName", dgvParameters.Columns[e.ColumnIndex].Name },
                    { "OrderOfSort", orderOfSort.ToString() }
                };
                    dgvParameters.DataSource = null;
                    EventHelper.RaiseEvent(this, SortParametersByBindingPropertyNameEventRaised, new DataEventArgs { ModelDictionary = sortParameters });
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
