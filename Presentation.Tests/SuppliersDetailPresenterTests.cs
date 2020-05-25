using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class SuppliersDetailPresenterTests
    {
        private SuppliersDetailPresenter suppliersDetailPresenter;
        private string errorMessage;
        private bool operationSucceeded;

        public SuppliersDetailPresenterTests()
        {
            suppliersDetailPresenter = new SuppliersDetailPresenter(
                new SuppliersDetailUC(new ErrorMessageView()),
                ServicesInitializator.facade);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void GetSuppliersDetailUC_ShouldReturnSuppliersDetailUC()
        {
            SuppliersDetailUC suppliersDetailUC = null;
            try
            {
                suppliersDetailUC = (SuppliersDetailUC)suppliersDetailPresenter.GetSuppliersDetailUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(suppliersDetailUC, errorMessage);
        }

        [TestMethod]
        public void SetupSuppliersDetailForAdd_ShouldReturn_Success()
        {
            try
            {
                suppliersDetailPresenter.SetupSuppliersDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SetupSuppliersDetailForEdit_ShouldReturn_Success()
        {
            try
            {
                suppliersDetailPresenter.SetupSuppliersDetailForEdit(1);
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