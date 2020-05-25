using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class SettingsPresenterTests
    {
        private SettingsPresenter settingsPresenter;

        public SettingsPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            settingsPresenter = new SettingsPresenter(new SettingsUC(errorMessageView), errorMessageView);
        }

        [TestMethod]
        public void GetSettingsUCTest_ShouldReturn_SettingsUC()
        {
            SettingsUC settingsUC = null;
            string errorMessage = "";
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