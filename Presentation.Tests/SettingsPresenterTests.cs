using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class SettingsPresenterTests
    {
        private SettingsPresenter settingsPresenter;
        private string errorMessage;

        public SettingsPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            settingsPresenter = new SettingsPresenter(new SettingsUC(errorMessageView), errorMessageView);
        }

        [TestMethod()]
        public void GetSettingsUCTest_ShouldReturn_SettingsUC()
        {
            SettingsUC settingsUC = null;
            errorMessage = "";
            try
            {
                settingsUC = (SettingsUC)settingsPresenter.GetSettingsUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(settingsUC, errorMessage);
        }
    }
}