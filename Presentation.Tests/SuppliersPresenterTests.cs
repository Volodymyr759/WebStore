using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class SuppliersPresenterTests
    {
        private SuppliersPresenter suppliersPresenter;

        public SuppliersPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            suppliersPresenter = new SuppliersPresenter(new SuppliersUC(errorMessageView),
                new SuppliersDetailPresenter(new SuppliersDetailUC(errorMessageView), ServicesInitialiser.facade),
                ServicesInitialiser.facade, new DeleteConfirmView(), errorMessageView);
        }

        [TestMethod]
        public void GetSuppliersUCTest_ShouldReturnSuppliersUC()
        {
            string errorMessage = "";
            SuppliersUC suppliersUC = null;
            try
            {
                suppliersUC = (SuppliersUC)suppliersPresenter.GetSuppliersUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(suppliersUC, errorMessage);
        }
    }
}