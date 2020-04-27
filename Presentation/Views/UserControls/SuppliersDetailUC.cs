using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class SuppliersDetailUC : UserControl, ISuppliersDetailUC
    {
        private BasePresenter basePresenter;

        public event EventHandler<DataEventArgs> SaveSuppliersDetailEventRaised;

        public event EventHandler CancelSuppliersDetailEventRaised;

        public SuppliersDetailUC()
        {
            InitializeComponent();
            basePresenter = new BasePresenter();
        }

        public void ResetControls()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxLink.Text = "";
            textBoxCurrency.Text = "";
            richTextBoxNotes.Text = "";
        }

        public void SetupControls(Dictionary<string, string> modelDictionary)
        {
            textBoxId.Text = modelDictionary["Id"];
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
                    { "Id", textBoxId.Text },
                    { "Name", textBoxName.Text },
                    { "Link", textBoxLink.Text },
                    { "Currency", textBoxCurrency.Text },
                    { "Notes", richTextBoxNotes.Text }
                };
                EventHelper.RaiseEvent(this, SaveSuppliersDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка збереження одиниці виміру.");
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelSuppliersDetailEventRaised, e);
        }
    }
}
