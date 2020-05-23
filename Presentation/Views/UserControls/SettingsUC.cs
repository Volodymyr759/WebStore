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
            textBoxFolderImages1.Text = setupValues["textBoxFolderImages1"];
            textBoxFolderImages2.Text = setupValues["textBoxFolderImages2"];
            checkBoxRunShedule.Checked = setupValues["checkBoxRunShedule"] == "checked" ? true : false;
            textBoxStart.Text = setupValues["textBoxStart"];
            textBoxInterval.Text = setupValues["textBoxInterval"];
            checkBoxCheckAvailability.Checked = setupValues["checkBoxCheckAvailability"] == "checked" ? true : false;
            checkBoxCheckPrices.Checked = setupValues["checkBoxCheckPrices"] == "checked" ? true : false;
            checkBoxLoadNewProducts.Checked = setupValues["checkBoxLoadNewProducts"] == "checked" ? true : false;
        }

        private void ButtonSetFolderImages1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    config.AppSettings.Settings.Remove("textBoxFolderImages1");
                    config.AppSettings.Settings.Add("textBoxFolderImages1", folder.SelectedPath);
                    textBoxFolderImages1.Text = folder.SelectedPath;
                    config.Save(ConfigurationSaveMode.Minimal);
                }
            }
            catch
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", "Помилка збереження каталогу зображень.");
            }
        }

        private void ButtonSetFolderImages2_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                DialogResult result = folder.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    config.AppSettings.Settings.Remove("textBoxFolderImages2");
                    config.AppSettings.Settings.Add("textBoxFolderImages2", folder.SelectedPath);
                    textBoxFolderImages2.Text = folder.SelectedPath;
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
                    { "textBoxFolderImages1", textBoxFolderImages1.Text },
                    { "textBoxFolderImages2", textBoxFolderImages2.Text },
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
