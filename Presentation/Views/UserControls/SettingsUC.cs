using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using Common;

namespace Presentation.Views.UserControls
{
    /// <summary>
    /// Представлення налаштувань
    /// </summary>
    public partial class SettingsUC : UserControl, ISettingsUC
    {
        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія для збереження налаштувань, внесених користувачем у представленні
        /// </summary>
        public event EventHandler<DataEventArgs> SaveSheduleSettingsEventRaised;

        /// <summary>
        /// Конструктор представлення налаштувань
        /// </summary>
        /// <param name="errorMessageView">Універсальна форма для відображення помилок</param>
        public SettingsUC(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        /// <summary>
        /// Ініціалізує візуальні компоненти представлення налаштувань
        /// </summary>
        /// <param name="setupValues">отримує Dictionary з презентера</param>
        public void SetupControls(Dictionary<string, string> setupValues)
        {
            textBoxFolderImagesOdesa.Text = setupValues["textBoxFolderImagesOdesa"];
            textBoxFolderImagesKyiv.Text = setupValues["textBoxFolderImagesKyiv"];
            checkBoxRunShedule.Checked = setupValues["checkBoxRunShedule"] == "checked" ? true : false;
            textBoxStart.Text = setupValues["textBoxStart"];
            textBoxInterval.Text = setupValues["textBoxInterval"];
            checkBoxCheckAvailability.Checked = setupValues["checkBoxCheckAvailability"] == "checked" ? true : false;
            checkBoxCheckPrices.Checked = setupValues["checkBoxCheckPrices"] == "checked" ? true : false;
            checkBoxLoadNewProducts.Checked = setupValues["checkBoxLoadNewProducts"] == "checked" ? true : false;
        }

        private void ButtonSetFolderImagesOdesa_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    config.AppSettings.Settings.Remove("textBoxFolderImagesOdesa");
                    config.AppSettings.Settings.Add("textBoxFolderImagesOdesa", folder.SelectedPath);
                    textBoxFolderImagesOdesa.Text = folder.SelectedPath;
                    config.Save(ConfigurationSaveMode.Minimal);
                }
            }
            catch
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", "Помилка збереження каталогу зображень.");
            }
        }

        private void ButtonSetFolderImagesKyiv_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    config.AppSettings.Settings.Remove("textBoxFolderImagesKyiv");
                    config.AppSettings.Settings.Add("textBoxFolderImagesKyiv", folder.SelectedPath);
                    textBoxFolderImagesKyiv.Text = folder.SelectedPath;
                    config.Save(ConfigurationSaveMode.Minimal);
                }
            }
            catch
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", "Помилка збереження каталогу зображень.");
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                const string isChecked = "checked";
                var sheduleDictionary = new Dictionary<string, string>()
                {
                    { "textBoxFolderImagesOdesa", textBoxFolderImagesOdesa.Text },
                    { "textBoxFolderImagesKyiv", textBoxFolderImagesKyiv.Text },
                    { "textBoxStart", textBoxStart.Text },
                    { "textBoxInterval", textBoxInterval.Text },
                };

                if (checkBoxRunShedule.Checked) sheduleDictionary.Add("checkBoxRunShedule", isChecked);
                    else sheduleDictionary.Add("checkBoxRunShedule", "un" + isChecked);

                if (checkBoxCheckAvailability.Checked) sheduleDictionary.Add("checkBoxCheckAvailability", isChecked);
                    else sheduleDictionary.Add("checkBoxCheckAvailability", "un" + isChecked);

                if (checkBoxCheckPrices.Checked) sheduleDictionary.Add("checkBoxCheckPrices", isChecked);
                    else sheduleDictionary.Add("checkBoxCheckPrices", "un" + isChecked);

                if (checkBoxLoadNewProducts.Checked) sheduleDictionary.Add("checkBoxLoadNewProducts", isChecked);
                    else sheduleDictionary.Add("checkBoxLoadNewProducts", "un" + isChecked);

                EventHelper.RaiseEvent(this, SaveSheduleSettingsEventRaised, new DataEventArgs { ModelDictionary = sheduleDictionary });
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }
    }
}
