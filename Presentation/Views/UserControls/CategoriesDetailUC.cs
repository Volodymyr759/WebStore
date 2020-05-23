using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення деталей категорії товарів постачальника
    /// </summary>
    public partial class CategoriesDetailUC : UserControl, ICategoriesDetailUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія збереження запису обраної категорії постачальника
        /// </summary>
        public event EventHandler<DataEventArgs> SaveCategoriesDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей категорії
        /// </summary>
        public event EventHandler CancelCategoriesDetailEventRaised;

        /// <summary>
        /// Конструктор представлення деталей категорії постаальника
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми повідомлення про помилку</param>
        public CategoriesDetailUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Очищення елементів у представленні деталей обрано категорії постачальника
        /// </summary>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        public void ResetControls(BindingSource bindingSourceSuppliersDtoModel)
        {
            Tag = "";
            textBoxName.Text = "";

            comboBoxSupplierName.DisplayMember = "Name";
            comboBoxSupplierName.ValueMember = "Id";
            comboBoxSupplierName.DataSource = bindingSourceSuppliersDtoModel;
            comboBoxSupplierName.Text = "";

            textBoxLink.Text = "";
            textBoxRate.Text = "";
            textBoxNotes.Text = "";

        }

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної категорії постачальника
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        public void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceSuppliersDtoModel)
        {
            Tag = modelDictionary["Id"];
            textBoxName.Text = modelDictionary["Name"];

            comboBoxSupplierName.DisplayMember = "Name";
            comboBoxSupplierName.ValueMember = "Id";
            comboBoxSupplierName.DataSource = bindingSourceSuppliersDtoModel;
            comboBoxSupplierName.Text = modelDictionary["SupplierName"];

            textBoxLink.Text = modelDictionary["Link"];
            textBoxRate.Text = modelDictionary["Rate"];
            textBoxNotes.Text = modelDictionary["Notes"];
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var modelDictionary = new Dictionary<string, string>()
                {
                    { "Id", Tag.ToString() },
                    { "Name", textBoxName.Text },
                    { "SupplierId", comboBoxSupplierName.SelectedValue.ToString() },
                    { "SupplierName", comboBoxSupplierName.Text },
                    { "Link", textBoxLink.Text },
                    { "Rate", textBoxRate.Text },
                    { "Notes", textBoxNotes.Text }
                };

                EventHelper.RaiseEvent(this, SaveCategoriesDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }

            ButtonCancel_Click(this, new EventArgs());
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelCategoriesDetailEventRaised, e);
        }
    }
}
