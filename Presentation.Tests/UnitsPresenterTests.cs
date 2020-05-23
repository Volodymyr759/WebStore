using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class UnitsPresenterTests
    {
        private UnitsPresenter unitsPresenter;
        string errorMessage;

        public UnitsPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            unitsPresenter = new UnitsPresenter(
                new UnitsUC(errorMessageView),
                ServicesInitializator.facade, 
                new UnitsDetailPresenter(new UnitsDetailUC(errorMessageView), ServicesInitializator.facade), 
                new DeleteConfirmView(), errorMessageView);
        }

        [TestMethod()]
        public void GetUnitsUCTest_ShouldReturnUnitsUC()
        {
            UnitsUC unitsUC = null;
            errorMessage = "";
            try
            {
                unitsUC = (UnitsUC)unitsPresenter.GetUnitsUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(unitsUC, errorMessage);
        }
    }
}