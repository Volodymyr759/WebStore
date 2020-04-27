using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class UnitsDetailUC : UserControl, IUnitsDetailUC
    {
        private BasePresenter basePresenter;

        public event EventHandler<DataEventArgs> SaveUnitsDetailEventRaised;
        public event EventHandler CancelUnitsDetailEventRaised;

        public UnitsDetailUC()
        {
            InitializeComponent();
            basePresenter = new BasePresenter();
        }

        public void ResetControls()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxNotes.Text = "";
        }

        public void SetupControls(Dictionary<string, string> modelDictionary)
        {
            textBoxId.Text = modelDictionary["Id"];
            textBoxName.Text = modelDictionary["Name"];
            textBoxNotes.Text = modelDictionary["Notes"];
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var modelDictionary = new Dictionary<string, string>()
                {
                    { "Id", textBoxId.Text },
                    { "Name", textBoxName.Text },
                    { "Notes", textBoxNotes.Text }
                };
                EventHelper.RaiseEvent(this, SaveUnitsDetailEventRaised, new DataEventArgs { ModelDictionary = modelDictionary });
            }
            catch
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка збереження одиниці виміру.");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, CancelUnitsDetailEventRaised, e);
        }
    }
}
