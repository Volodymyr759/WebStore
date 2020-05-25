using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class UnitsPresenterTests
    {
        private UnitsPresenter unitsPresenter;

        public UnitsPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            unitsPresenter = new UnitsPresenter(
                new UnitsUC(errorMessageView),
                ServicesInitializator.facade, 
                new UnitsDetailPresenter(new UnitsDetailUC(errorMessageView), ServicesInitializator.facade), 
                new DeleteConfirmView(), errorMessageView);
        }

        [TestMethod]
        public void GetUnitsUCTest_ShouldReturn_UnitsUC()
        {
            UnitsUC unitsUC = null;
            string errorMessage = "";
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