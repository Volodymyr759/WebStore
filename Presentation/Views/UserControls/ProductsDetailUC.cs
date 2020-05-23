using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення деталей товару
    /// </summary>
    public partial class ProductsDetailUC : UserControl, IProductsDetailUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія збереження запису обраного товару
        /// </summary>
        public event EventHandler<DataEventArgs> SaveProductsDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей товару
        /// </summary>
        public event EventHandler CancelProductsDetailEventRaised;

        /// <summary>
        /// Конструктор представлення деталей товару постачальника
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public ProductsDetailUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Очищення елементів у представленні деталей обраного товару
        /// </summary>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        /// <param name="bindingSourceCategoriesDtoModel">Прив'язка до списку категорій</param>
        /// <param name="bindingSourceGroupsDtoModel">Прив'язка до списку груп власного каталогу</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        public void ResetControls(BindingSource bindingSourceSuppliersDtoModel,
            BindingSource bindingSourceCategoriesDtoModel,
            BindingSource bindingSourceGroupsDtoModel,
            BindingSource bindingSourceUnitsDtoModel)
        {
            Tag = "";
            textBoxNameWebStore.Text = "";
            textBoxNameSupplier.Text = "";

            comboBoxSupplierName.DisplayMember = "Name";
            comboBoxSupplierName.ValueMember = "Id";
            comboBoxSupplierName.DataSource = bindingSourceSuppliersDtoModel;
            comboBoxSupplierName.Text = "";

            comboBoxCategoryName.DisplayMember = "Name";
            comboBoxCategoryName.ValueMember = "Id";
            comboBoxCategoryName.DataSource = bindingSourceCategoriesDtoModel;
            comboBoxCategoryName.Text = "";

            comboBoxGroupName.DisplayMember = "Name";
            comboBoxGroupName.ValueMember = "Id";
            comboBoxGroupName.DataSource = bindingSourceGroupsDtoModel;
            comboBoxGroupName.Text = "";

            comboBoxUnitName.DisplayMember = "Name";
            comboBoxUnitName.ValueMember = "Id";
            comboBoxUnitName.DataSource = bindingSourceUnitsDtoModel;
            comboBoxUnitName.Text = "";

            textBoxCodeWebStore.Text = "";
            textBoxCodeSupplier.Text = "";
            textBoxPriceWebStore.Text = "";
            textBoxPriceSupplier.Text = "";
            textBoxCurrency.Text = "";
            textBoxAvailable.Text = "";
            textBoxLinkWebStore.Text = "";
            textBoxLinkSupplier.Text = "";
            richTextBox1.Text = "";
        }

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраного товару
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        /// <param name="bindingSourceCategoriesDtoModel">Прив'язка до списку категорій</param>
        /// <param name="bindingSourceGroupsDtoModel">Прив'язка до списку груп власного каталогу</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        public void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceSuppliersDtoModel,
            BindingSource bindingSourceCategoriesDtoModel,
            BindingSource bindingSourceGroupsDtoModel,
            BindingSource bindingSourceUnitsDtoModel)
        {
            Tag = modelDictionary["Id"];
            textBoxNameWebStore.Text = modelDictionary["NameWebStore"];
            textBoxNameSupplier.Text = modelDictionary["NameSupplier"];

            comboBoxSupplierName.DisplayMember = "Name";
            comboBoxSupplierName.ValueMember = "Id";
            comboBoxSupplierName.DataSource = bindingSourceSuppliersDtoModel;
            comboBoxSupplierName.Text = modelDictionary["SupplierName"];

            comboBoxCategoryName.DisplayMember = "Name";
            comboBoxCategoryName.ValueMember = "Id";
            comboBoxCategoryName.DataSource = bindingSourceCategoriesDtoModel;
            comboBoxCategoryName.Text = modelDictionary["CategoryName"];

            comboBoxGroupName.DisplayMember = "Name";
            comboBoxGroupName.ValueMember = "Id";
            comboBoxGroupName.DataSource = bindingSourceGroupsDtoModel;
            comboBoxGroupName.Text = modelDictionary["GroupName"];

            comboBoxUnitName.DisplayMember = "Name";
            comboBoxUnitName.ValueMember = "Id";
            comboBoxUnitName.DataSource = bindingSourceUnitsDtoModel;
            comboBoxUnitName.Text = modelDictionary["UnitName"];

            textBoxCodeWebStore.Text = modelDictionary["CodeWebStore"];
            textBoxCodeSupplier.Text = modelDictionary["CodeSupplier"];
            textBoxPriceWebStore.Text = modelDictionary["PriceWebStore"];
            textBoxPriceSupplier.Text = modelDictionary["PriceSupplier"];
            textBoxCurrency.Text = modelDictionary["Currency"];
            textBoxAvailable.Text = modelDictionary["Available"];
            textBoxLinkWebStore.Text = modelDictionary["LinkWebStore"];
            textBoxLinkSupplier.Text = modelDictionary["LinkSupplier"];
            richTextBox1.Text = modelDictionary["Notes"];
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var modelDictionary = new Dictionary<string, string>()
                {
                    { "Id", Tag.ToString() },
                    { "NameWebStore", textBoxNameWebStore.Text },
                    { "NameSupplier", textBoxNameSupplier.Text },

                    { "SupplierId", comboBoxSupplierName.SelectedValue.ToString() },
                    { "SupplierName", comboBoxSupplierName.Text },
                    { "CategoryId", comboBoxCategoryName.SelectedValue.ToString() },
                    { "CategoryName", comboBoxCategoryName.Text },
                    { "GroupId", comboBoxGroupName.SelectedValue.ToString() },
                    { "GroupName", comboBoxGroupName.Text },
                    { "UnitId", comboBoxUnitName.SelectedValue.ToString() },
                    { "UnitName", comboBoxUnitName.Text },

                    { "CodeWebStore", textBoxCodeWebStore.Text },
                    { "CodeSupplier", textBoxCodeSupplier.Text },
                    { "PriceWebStore", textBoxPriceWebStore.Text },
                    { "PriceSupplier", textBoxPriceSupplier.Text },
                    { "Currency", textBoxCurrency.Text },
                    { "Available", textBoxAvailable.Text },
                    { "LinkWebStore", textBoxLinkWebStore.Text },
                    { "LinkSupplier", textBoxLinkSupplier.Text },
                    { "Notes", richTextBox1.Text },
                };
                EventHelper.RaiseEvent(this, SaveProductsDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }

            ButtonCancel_Click(this, new EventArgs());
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelProductsDetailEventRaised, e);
        }
    }
}
