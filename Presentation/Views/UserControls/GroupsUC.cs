using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення списку груп власного каталогу
    /// </summary>
    public partial class GroupsUC : UserControl, IGroupsUC
    {
        private IErrorMessageView errorMessageView;

        private SortOrder orderOfSort = SortOrder.Ascending;

        /// <summary>
        /// Подія виклику представлення для створення нової групи
        /// </summary>
        public event EventHandler AddNewGroupEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраної групи
        /// </summary>
        public event EventHandler EditGroupEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення групи
        /// </summary>
        public event EventHandler DeleteGroupEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраної групи
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку груп
        /// </summary>
        public event EventHandler<DataEventArgs> SortGroupsByBindingPropertyNameEventRaised;

        /// <summary>
        /// Конструктор представлення списку груп власного каталогу
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми повідомлення про помилку</param>
        public GroupsUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Налаштування даних в представленні списку груп
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку груп</param>
        public void SetupControls(BindingSource bindingSource)
        {// ініціалізація dgvGroups відрізняється через неправильний порядок стовпців при початковому завантаженні
            dgvGroups.AutoGenerateColumns = false;
            dgvGroups.AutoSize = true;

            dgvGroups.DataSource = bindingSource;

            if (dgvGroups.Columns["Id"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "Id", Width = 20, Visible = false });
            if (dgvGroups.Columns["Name"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Назва", Width = 100, DisplayIndex = 0 });
            if (dgvGroups.Columns["Number"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "Number", DataPropertyName = "Number", HeaderText = "Номер", Width = 80, DisplayIndex = 1 });
            if (dgvGroups.Columns["Identifier"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "Identifier", DataPropertyName = "Identifier", HeaderText = "Ідентифікатор", Width = 80, DisplayIndex = 2 });
            if (dgvGroups.Columns["AncestorNumber"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "AncestorNumber", DataPropertyName = "AncestorNumber", HeaderText = "Предок номер", Width = 80, DisplayIndex = 3 });
            if (dgvGroups.Columns["AncestorIdentifier"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "AncestorIdentifier", DataPropertyName = "AncestorIdentifier", HeaderText = "Предок ідентифікатор", Width = 80, DisplayIndex = 4 });
            if (dgvGroups.Columns["ProductType"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductType", DataPropertyName = "ProductType", HeaderText = "Тип товару", Width = 60, DisplayIndex = 5 });
            if (dgvGroups.Columns["Link"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "Link", DataPropertyName = "Link", HeaderText = "Лінк", Width = 100, DisplayIndex = 6 });
            if (dgvGroups.Columns["Notes"] == null)
                dgvGroups.Columns.Add(new DataGridViewTextBoxColumn { Name = "Notes", DataPropertyName = "Notes", HeaderText = "Опис", Width = 100, DisplayIndex = 7 });

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20,
                DisplayIndex = 8
            };

            if (dgvGroups.Columns["Options"] == null) dgvGroups.Columns.Add(imageColumn);

            dgvGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGroups.AllowUserToAddRows = false;
            dgvGroups.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, AddNewGroupEventRaised, e);
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
                EventHelper.RaiseEvent(this, EditGroupEventRaised, e);
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
                EventHelper.RaiseEvent(this, DeleteGroupEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvGroups.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    if (dgvGroups.AreAllCellsSelected(true) == false)
                    {
                        var modelDictionary = new Dictionary<string, string> { { "Link", dgvGroups.SelectedCells[8].Value.ToString() } };
                        EventHelper.RaiseEvent(this, LinkToSearchChangedInUCEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvGroups_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvGroups.Columns[e.ColumnIndex].Name != "Options")
                {
                    var sortParameters = new Dictionary<string, string>()
                {
                    { "PropertyName", dgvGroups.Columns[e.ColumnIndex].Name },
                    { "OrderOfSort", orderOfSort.ToString() }
                };
                    dgvGroups.DataSource = null;
                    EventHelper.RaiseEvent(this, SortGroupsByBindingPropertyNameEventRaised, new DataEventArgs { ModelDictionary = sortParameters });
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
