using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class ParametersPresenterTests
    {
        private ParametersPresenter parametersPresenter;
        private string errorMessage;
        private ParametersUC parametersUC;

        public ParametersPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            ParametersDetailUC parametersDetailUC = new ParametersDetailUC(errorMessageView);
            ParametersDetailPresenter parametersDetailPresenter = new ParametersDetailPresenter(parametersDetailUC, ServicesInitializator.facade);
            parametersPresenter = new ParametersPresenter(new ParametersUC(errorMessageView), 
                parametersDetailPresenter, 
                ServicesInitializator.facade,
                deleteConfirmView, errorMessageView);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            parametersUC = null;
        }

        [TestMethod]
        public void GetParametersUCTest_ShouldReturn_ParametersUC()
        {
            try
            {
                parametersUC = (ParametersUC)parametersPresenter.GetParametersUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(parametersUC, errorMessage);
        }

        [TestMethod()]
        public void LoadParametersTest_ShouldReturn_ParametersUC()
        {
            try
            {
                parametersUC = (ParametersUC)parametersPresenter.LoadParameters();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(parametersUC, errorMessage);
        }
    }
}