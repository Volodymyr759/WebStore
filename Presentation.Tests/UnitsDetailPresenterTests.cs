using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class UnitsDetailPresenterTests
    {
        private UnitsDetailPresenter unitsDetailPresenter;
        bool operationSucceeded;
        string errorMessage;

        public UnitsDetailPresenterTests()
        {
            unitsDetailPresenter = new UnitsDetailPresenter(
                new UnitsDetailUC(new ErrorMessageView()),
                ServicesInitializator.facade);
        }

        [TestMethod()]
        public void GetUnitsDetailUC_ShouldReturnUnitsDetailUC()
        {
            errorMessage = "";
            UnitsDetailUC unitsDetailUC = null;
            try
            {
                unitsDetailUC = (UnitsDetailUC)unitsDetailPresenter.GetUnitsDetailUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(unitsDetailUC, errorMessage);
        }

        [TestMethod()]
        public void SetupUnitsDetailForAdd_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                unitsDetailPresenter.SetupUnitsDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void SetupUnitsDetailForEdit_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                unitsDetailPresenter.SetupUnitsDetailForEdit(1);
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