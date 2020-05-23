using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення деталей характеристики товару
    /// </summary>
    public partial class ParametersDetailUC : UserControl, IParametersDetailUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія збереження запису обраної характеристики товару
        /// </summary>
        public event EventHandler<DataEventArgs> SaveParametersDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей характеристики товару
        /// </summary>
        public event EventHandler CancelParametersDetailEventRaised;

        /// <summary>
        /// Конструктор представлення деталей характеристики товару
        /// </summary>
        /// <param name="errorMessageView">Екземплря універсальної форми відображення помилки</param>
        public ParametersDetailUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Очищення елементів у представленні деталей обраної характеристики товару
        /// </summary>
        /// <param name="bindingSourceProductsDtoModel">Прив'язка до списку товарів</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        public void ResetControls(BindingSource bindingSourceProductsDtoModel, BindingSource bindingSourceUnitsDtoModel)
        {
            Tag = "";
            textBoxName.Text = "";

            comboBoxProductName.DisplayMember = "NameWebStore";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.DataSource = bindingSourceProductsDtoModel;
            comboBoxProductName.Text = "";

            comboBoxUnitName.DisplayMember = "Name";
            comboBoxUnitName.ValueMember = "Id";
            comboBoxUnitName.DataSource = bindingSourceUnitsDtoModel;
            comboBoxUnitName.Text = "";

            textBoxValue.Text = "";
        }

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної характеристики товару
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceProductsDtoModel">Прив'язка до списку товарів</param>
        /// <param name="bindingSourceUnitsDtoModel">Прив'язка до списку одиниць виміру</param>
        public void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceProductsDtoModel, BindingSource bindingSourceUnitsDtoModel)
        {
            this.Tag = modelDictionary["Id"];
            textBoxName.Text = modelDictionary["Name"];

            comboBoxProductName.DisplayMember = "NameWebStore";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.DataSource = bindingSourceProductsDtoModel;
            comboBoxProductName.Text = modelDictionary["ProductName"];

            comboBoxUnitName.DisplayMember = "Name";
            comboBoxUnitName.ValueMember = "Id";
            comboBoxUnitName.DataSource = bindingSourceUnitsDtoModel;
            comboBoxUnitName.Text = modelDictionary["UnitName"];

            textBoxValue.Text = modelDictionary["Value"];
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var modelDictionary = new Dictionary<string, string>()
                {
                    { "Id", this.Tag.ToString() },
                    { "ProductId", comboBoxProductName.SelectedValue.ToString() },
                    { "ProductName", comboBoxProductName.Text },
                    { "Name", textBoxName.Text },
                    { "UnitId", comboBoxUnitName.SelectedValue.ToString() },
                    { "UnitName", comboBoxUnitName.Text },
                    { "Value", textBoxValue.Text }
                };
                EventHelper.RaiseEvent(this, SaveParametersDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }

            ButtonCancel_Click(this, new EventArgs());
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelParametersDetailEventRaised, e);
        }
    }
}
