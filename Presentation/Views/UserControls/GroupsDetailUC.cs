using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення деталей групи власного каталогу
    /// </summary>
    public partial class GroupsDetailUC : UserControl, IGroupsDetailUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія збереження запису обраної групи
        /// </summary>
        public event EventHandler<DataEventArgs> SaveGroupsDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей групи
        /// </summary>
        public event EventHandler CancelGroupsDetailEventRaised;

        /// <summary>
        /// Конструктор представлення деталей груп власного каталогу
        /// </summary>
        /// <param name="errorMessageView"></param>
        public GroupsDetailUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Очищення елементів у представленні деталей обраної групи
        /// </summary>
        public void ResetControls()
        {
            Tag = "";
            textBoxName.Text = "";
            textBoxNumber.Text = "";
            textBoxIdentifier.Text = "";
            textBoxAncestorNumber.Text = "";
            textBoxAncestorIdentifier.Text = "";
            textBoxProductType.Text = "";
            textBoxLink.Text = "";
            textBoxNotes.Text = "";
        }

        /// <summary>
        /// Ініціалізація елементів представлення деталей обраної групи
        /// </summary>
        /// <param name="modelDictionary">Словник значень елементів управління</param>
        public void SetupControls(Dictionary<string, string> modelDictionary)
        {
            Tag = modelDictionary["Id"];
            textBoxName.Text = modelDictionary["Name"];
            textBoxNumber.Text = modelDictionary["Number"];
            textBoxIdentifier.Text = modelDictionary["Identifier"];
            textBoxAncestorNumber.Text = modelDictionary["AncestorNumber"];
            textBoxAncestorIdentifier.Text = modelDictionary["AncestorIdentifier"];
            textBoxProductType.Text = modelDictionary["ProductType"];
            textBoxLink.Text = modelDictionary["Link"];
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
                    { "Number", textBoxNumber.Text },
                    { "Identifier", textBoxIdentifier.Text },
                    { "AncestorNumber", textBoxAncestorNumber.Text },
                    { "AncestorIdentifier", textBoxAncestorIdentifier.Text },
                    { "ProductType", textBoxProductType.Text },
                    { "Link", textBoxLink.Text },
                    { "Notes", textBoxNotes.Text }
                };
                EventHelper.RaiseEvent(this, SaveGroupsDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }

            ButtonCancel_Click(this, new EventArgs());
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => EventHelper.RaiseEvent(this, CancelGroupsDetailEventRaised, e);
    }
}
