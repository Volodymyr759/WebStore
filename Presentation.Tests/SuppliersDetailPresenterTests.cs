using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class SuppliersDetailPresenterTests
    {
        private SuppliersDetailPresenter suppliersDetailPresenter;
        bool operationSucceeded;

        public SuppliersDetailPresenterTests()
        {
            suppliersDetailPresenter = new SuppliersDetailPresenter(
                new SuppliersDetailUC(new ErrorMessageView()),
                ServicesInitializator.facade);
        }

        [TestMethod()]
        public void GetSuppliersDetailUC_ShouldReturnSuppliersDetailUC()
        {
            SuppliersDetailUC suppliersDetailUC = null;
            try
            {
                suppliersDetailUC = (SuppliersDetailUC)suppliersDetailPresenter.GetSuppliersDetailUC();
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(suppliersDetailUC);
        }

        [TestMethod()]
        public void SetupSuppliersDetailForAdd_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                suppliersDetailPresenter.SetupSuppliersDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupSuppliersDetailForEdit_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                suppliersDetailPresenter.SetupSuppliersDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}