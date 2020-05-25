using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class ParametersDetailPresenterTests
    {
        private ParametersDetailPresenter parametersDetailPresenter;
        private string errorMessage;
        private bool operationSucceeded;

        public ParametersDetailPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            ParametersDetailUC parametersDetailUC = new ParametersDetailUC(errorMessageView);
            parametersDetailPresenter = new ParametersDetailPresenter(parametersDetailUC, ServicesInitializator.facade);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void GetParametersDetailUC_ShouldReturnParametersDetailUC()
        {
            ParametersDetailUC parametersDetailUC = null;
            try
            {
                parametersDetailUC = (ParametersDetailUC)parametersDetailPresenter.GetParametersDetailUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            Assert.IsNotNull(parametersDetailUC, errorMessage);
        }

        [TestMethod]
        public void SetupParametersDetailForAdd_ShouldReturn_Success()
        {
            try
            {
                parametersDetailPresenter.SetupParametersDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SetupParametersDetailForEdit_ShouldReturn_Success()
        {
            try
            {
                parametersDetailPresenter.SetupParametersDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            Assert.IsTrue(operationSucceeded, errorMessage);
        }
    }
}