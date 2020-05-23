using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення деталей одиниці виміру
    /// </summary>
    public partial class UnitsDetailUC : UserControl, IUnitsDetailUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія збереження запису обраної одиниці виміру
        /// </summary>
        public event EventHandler<DataEventArgs> SaveUnitsDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей одиниці виміру
        /// </summary>
        public event EventHandler CancelUnitsDetailEventRaised;

        /// <summary>
        /// Конструктор представлення деталей одиниці виміру
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення помилки</param>
        public UnitsDetailUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Очищення елементів у представленні деталей обраної одиниці виміру
        /// </summary>
        public void ResetControls()
        {
            Tag = "";
            textBoxName.Text = "";
            textBoxNotes.Text = "";
        }

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної одиниці виміру
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        public void SetupControls(Dictionary<string, string> modelDictionary)
        {
            Tag = modelDictionary["Id"];
            textBoxName.Text = modelDictionary["Name"];
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
                    { "Notes", textBoxNotes.Text }
                };
                EventHelper.RaiseEvent(this, SaveUnitsDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch(Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }

            ButtonCancel_Click(this, new EventArgs());
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelUnitsDetailEventRaised, e);
        }
    }
}
