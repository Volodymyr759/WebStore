using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення деталей зображення товару
    /// </summary>
    public partial class ImagesDetailUC : UserControl, IImagesDetailUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія збереження запису обраного зображення товару
        /// </summary>
        public event EventHandler<DataEventArgs> SaveImagesDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей зображення товару
        /// </summary>
        public event EventHandler CancelImagesDetailEventRaised;

        /// <summary>
        /// Конструктор представлення деталей зображення товару
        /// </summary>
        /// <param name="errorMessageView"></param>
        public ImagesDetailUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Очищення елементів представлення деталей зображення
        /// </summary>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        public void ResetControls(BindingSource bindingSourceSuppliersDtoModel)
        {
            Tag = "";
            textBoxFileName.Text = "";

            comboBoxProductName.DisplayMember = "NameWebStore";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.DataSource = bindingSourceSuppliersDtoModel;
            comboBoxProductName.Text = "";

            textBoxLinkWebStore.Text = "";
            textBoxLinkSupplier.Text = "";
            textBoxLocalPath.Text = "";
        }

        /// <summary>
        /// Ініціалізація значень елементів представлення деталей зображення
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        /// <param name="bindingSourceSuppliersDtoModel">Прив'язка до списку постачальників</param>
        public void SetupControls(Dictionary<string, string> modelDictionary, BindingSource bindingSourceSuppliersDtoModel)
        {
            Tag = modelDictionary["Id"];
            textBoxFileName.Text = modelDictionary["FileName"];

            comboBoxProductName.DisplayMember = "NameWebStore";
            comboBoxProductName.ValueMember = "Id";
            comboBoxProductName.DataSource = bindingSourceSuppliersDtoModel;
            comboBoxProductName.Text = modelDictionary["ProductName"];

            textBoxLinkWebStore.Text = modelDictionary["LinkWebStore"];
            textBoxLinkSupplier.Text = modelDictionary["LinkSupplier"];
            textBoxLocalPath.Text = modelDictionary["LocalPath"];
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var modelDictionary = new Dictionary<string, string>()
                {
                    { "Id", Tag.ToString() },
                    { "FileName", textBoxFileName.Text },
                    { "ProductId", comboBoxProductName.SelectedValue.ToString() },
                    { "ProductName", comboBoxProductName.Text },
                    { "LinkWebStore", textBoxLinkWebStore.Text },
                    { "LinkSupplier", textBoxLinkSupplier.Text },
                    { "LocalPath", textBoxLocalPath.Text }
                };
                EventHelper.RaiseEvent(this, SaveImagesDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }

            ButtonCancel_Click(this, new EventArgs());
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelImagesDetailEventRaised, new EventArgs());
        }
    }
}
