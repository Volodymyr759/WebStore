using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class ImagesUC : UserControl, IImagesUC
    {
        private IErrorMessageView errorMessageView;

        private SortOrder orderOfSort = SortOrder.Ascending;

        /// <summary>
        /// Подія виклику представлення для створення нового зображення
        /// </summary>
        public event EventHandler AddNewImageEventRaised;

        /// <summary>
        /// Подія виклику представлення для редагування обраного зображення
        /// </summary>
        public event EventHandler EditImageEventRaised;

        /// <summary>
        /// Подія виклику форми підтвердження видалення зображення
        /// </summary>
        public event EventHandler DeleteImageEventRaised;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного зображення
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedInUCEventRaised;

        /// <summary>
        /// Подія сортування у представленні списку зображень
        /// </summary>
        public event EventHandler<DataEventArgs> SortImagesByBindingPropertyNameEventRaised;

        /// <summary>
        /// Конструктор представлення списку зображень товарів
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public ImagesUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Налаштування даних в представленні списку зображень товарів
        /// </summary>
        /// <param name="bindingSource">Прив'язка даних списку зображень товарів</param>
        public void SetupControls(BindingSource bindingSource)
        {
            dgvImages.DataSource = bindingSource;
            dgvImages.Columns["Id"].HeaderText = "Id";
            dgvImages.Columns["Id"].Width = 20;
            dgvImages.Columns["Id"].Visible = false;
            dgvImages.Columns["Id"].DisplayIndex = 0;

            dgvImages.Columns["FileName"].HeaderText = "Файл";
            dgvImages.Columns["FileName"].Width = 100;
            dgvImages.Columns["FileName"].DisplayIndex = 1;

            dgvImages.Columns["ProductId"].HeaderText = "ProductId";
            dgvImages.Columns["ProductId"].Visible = false;
            dgvImages.Columns["ProductId"].DisplayIndex = 2;

            dgvImages.Columns["ProductName"].HeaderText = "Товар";
            dgvImages.Columns["ProductName"].Width = 100;
            dgvImages.Columns["ProductName"].DisplayIndex = 3;

            dgvImages.Columns["LinkWebStore"].HeaderText = "Лінк";
            dgvImages.Columns["LinkWebStore"].Width = 100;
            dgvImages.Columns["LinkWebStore"].DisplayIndex = 4;

            dgvImages.Columns["LinkSupplier"].HeaderText = "Лінк постачальника";
            dgvImages.Columns["LinkSupplier"].Width = 100;
            dgvImages.Columns["LinkSupplier"].DisplayIndex = 5;

            dgvImages.Columns["LocalPath"].HeaderText = "Шлях";
            dgvImages.Columns["LocalPath"].Width = 100;
            dgvImages.Columns["LocalPath"].DisplayIndex = 6;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Опції",
                Name = "Options",
                Width = 60,
                Image = Properties.Resources.OptionsBlackDotsOnWhite20x20,
                DisplayIndex = 7
            };
            if (dgvImages.Columns["Options"] == null) dgvImages.Columns.Add(imageColumn);
            dgvImages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImages.AllowUserToAddRows = false;
            dgvImages.ReadOnly = true;
        }

        #region Events

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, AddNewImageEventRaised, e);
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
                EventHelper.RaiseEvent(this, EditImageEventRaised, e);
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
                EventHelper.RaiseEvent(this, DeleteImageEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvImages_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvImages.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    if (dgvImages.AreAllCellsSelected(true) == false)
                    {
                        var modelDictionary = new Dictionary<string, string> { { "Link", dgvImages.SelectedCells[5].Value.ToString() } };
                        EventHelper.RaiseEvent(this, LinkToSearchChangedInUCEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void DgvImages_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvImages.Columns[e.ColumnIndex].Name != "Options")
                {
                    var sortParameters = new Dictionary<string, string>()
                {
                    { "PropertyName", dgvImages.Columns[e.ColumnIndex].Name },
                    { "OrderOfSort", orderOfSort.ToString() }
                };
                    dgvImages.DataSource = null;
                    EventHelper.RaiseEvent(this, SortImagesByBindingPropertyNameEventRaised, new DataEventArgs { ModelDictionary = sortParameters });
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

        private void DgvImages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvImages.Columns["Options"].Index)
                contextMenuOptions.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void DgvImages_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvImages.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Hand;
            }
        }

        private void DgvImages_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvImages.Columns[e.ColumnIndex].Name == "Options") Cursor.Current = Cursors.Default;
            }
        }

        #endregion
    }
}
