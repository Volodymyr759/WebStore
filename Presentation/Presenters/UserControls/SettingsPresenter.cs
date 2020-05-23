using Common;
using Presentation.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення налаштувань
    /// </summary>
    public class SettingsPresenter : ISettingsPresenter
    {
        private ISettingsUC settingsUC;

        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Конструктор презентера налаштувань
        /// </summary>
        /// <param name="settingsUC">Екземпляр представлення налашувань</param>
        /// <param name="errorMessageView">Екземпляр універсальної форми для відображення помилок</param>
        public SettingsPresenter(ISettingsUC settingsUC, IErrorMessageView errorMessageView)
        {
            this.settingsUC = settingsUC;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            settingsUC.SaveSheduleSettingsEventRaised += (sender, sheduleDictionary) => OnSaveSheduleSettingsEventRaised(sender, sheduleDictionary);
        }

        private void OnSaveSheduleSettingsEventRaised(object sender, DataEventArgs sheduleDictionary)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("textBoxFolderImagesOdesa");
            config.AppSettings.Settings.Remove("textBoxFolderImagesKyiv");
            config.AppSettings.Settings.Remove("checkBoxRunShedule");
            config.AppSettings.Settings.Remove("textBoxStart");
            config.AppSettings.Settings.Remove("textBoxInterval");
            config.AppSettings.Settings.Remove("checkBoxCheckAvailability");
            config.AppSettings.Settings.Remove("checkBoxCheckPrices");
            config.AppSettings.Settings.Remove("checkBoxLoadNewProducts");

            config.AppSettings.Settings.Add("textBoxFolderImagesOdesa", sheduleDictionary.ModelDictionary["textBoxFolderImagesOdesa"]);
            config.AppSettings.Settings.Add("textBoxFolderImagesKyiv", sheduleDictionary.ModelDictionary["textBoxFolderImagesKyiv"]);
            config.AppSettings.Settings.Add("checkBoxRunShedule", sheduleDictionary.ModelDictionary["checkBoxRunShedule"]);
            config.AppSettings.Settings.Add("textBoxStart", sheduleDictionary.ModelDictionary["textBoxStart"]);
            config.AppSettings.Settings.Add("textBoxInterval", sheduleDictionary.ModelDictionary["textBoxInterval"]);
            config.AppSettings.Settings.Add("checkBoxCheckAvailability", sheduleDictionary.ModelDictionary["checkBoxCheckAvailability"]);
            config.AppSettings.Settings.Add("checkBoxCheckPrices", sheduleDictionary.ModelDictionary["checkBoxCheckPrices"]);
            config.AppSettings.Settings.Add("checkBoxLoadNewProducts", sheduleDictionary.ModelDictionary["checkBoxLoadNewProducts"]);

            config.Save(ConfigurationSaveMode.Minimal);
        }

        /// <summary>
        /// Отримує попередньо збережені користувачем налаштування в app.config і повертає представлення налаштувань
        /// </summary>
        /// <returns>Представлення налаштувань</returns>
        public ISettingsUC GetSettingsUC()
        {
            Dictionary<string, string> setupValues = new Dictionary<string, string>
            {
                { "textBoxFolderImagesOdesa", ConfigurationManager.AppSettings["textBoxFolderImagesOdesa"] },
                { "textBoxFolderImagesKyiv", ConfigurationManager.AppSettings["textBoxFolderImagesKyiv"] },
                { "checkBoxRunShedule", ConfigurationManager.AppSettings["checkBoxRunShedule"] },
                { "textBoxStart", ConfigurationManager.AppSettings["textBoxStart"] },
                { "textBoxInterval", ConfigurationManager.AppSettings["textBoxInterval"] },
                { "checkBoxCheckAvailability", ConfigurationManager.AppSettings["checkBoxCheckAvailability"] },
                { "checkBoxCheckPrices", ConfigurationManager.AppSettings["checkBoxCheckPrices"] },
                { "checkBoxLoadNewProducts", ConfigurationManager.AppSettings["checkBoxLoadNewProducts"] },
            };

            settingsUC.SetupControls(setupValues);
            return settingsUC;
        }

        /// <summary>
        /// Повертає час початку розпорядку для виконання завдань
        /// </summary>
        /// <returns></returns>
        public DateTime GetSheduleStartTime() => Convert.ToDateTime(ConfigurationManager.AppSettings["textBoxStart"]);

        /// <summary>
        /// Повертає інтервал в годинах для виконання розпорядку завдань
        /// </summary>
        /// <returns></returns>
        public int GetSheduleInterval() => Convert.ToInt32(ConfigurationManager.AppSettings["textBoxInterval"]);

        /// <summary>
        /// Повертає значенняя, чи потрібно виконувати розпорядок
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        public bool IsNeedRunShedule() => ConfigurationManager.AppSettings["checkBoxRunShedule"] == "checked" ? true : false;

        /// <summary>
        /// Повертає значенняя, чи потрібно перевіряти наявність товарів у постачальників
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        public bool IsNeedToCheckAvailability() => ConfigurationManager.AppSettings["checkBoxCheckAvailability"] == "checked" ? true : false;

        /// <summary>
        /// Повертає значенняя, чи потрібно перевіряти ціни товарів у постачальників
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        public bool IsNeedToCheckPrices() => ConfigurationManager.AppSettings["checkBoxCheckPrices"] == "checked" ? true : false;

        /// <summary>
        /// Повертає значенняя, чи потрібно завантажувати нові товари
        /// </summary>
        /// <returns>Потрібно - true, не потрібно - false</returns>
        public bool IsNeedToLoadNewProducts() => ConfigurationManager.AppSettings["checkBoxLoadNewProducts"] == "checked" ? true : false;
    }
}
