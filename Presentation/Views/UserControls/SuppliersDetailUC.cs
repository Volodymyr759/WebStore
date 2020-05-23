using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення деталей постачальника
    /// </summary>
    public partial class SuppliersDetailUC : UserControl, ISuppliersDetailUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія збереження запису обраного постачальника
        /// </summary>
        public event EventHandler<DataEventArgs> SaveSuppliersDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей постачальника
        /// </summary>
        public event EventHandler CancelSuppliersDetailEventRaised;

        /// <summary>
        /// Конструктор представлення деталей постачальника
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальной форми відображення помилки</param>
        public SuppliersDetailUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Очищення елементів у представленні деталей обраного постачальника
        /// </summary>
        public void ResetControls()
        {
            Tag = "";
            textBoxName.Text = "";
            textBoxLink.Text = "";
            textBoxCurrency.Text = "";
            richTextBoxNotes.Text = "";
        }

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраного постачальника
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        public void SetupControls(Dictionary<string, string> modelDictionary)
        {
            Tag = modelDictionary["Id"];
            textBoxName.Text = modelDictionary["Name"];
            textBoxLink.Text = modelDictionary["Link"];
            textBoxCurrency.Text = modelDictionary["Currency"];
            richTextBoxNotes.Text = modelDictionary["Notes"];
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var modelDictionary = new Dictionary<string, string>()
                {
                    { "Id", Tag.ToString() },
                    { "Name", textBoxName.Text },
                    { "Link", textBoxLink.Text },
                    { "Currency", textBoxCurrency.Text },
                    { "Notes", richTextBoxNotes.Text }
                };
                EventHelper.RaiseEvent(this, SaveSuppliersDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }

            ButtonCancel_Click(this, new EventArgs());
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelSuppliersDetailEventRaised, e);
        }
    }
}
