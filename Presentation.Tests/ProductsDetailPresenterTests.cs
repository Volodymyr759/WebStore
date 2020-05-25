using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class ProductsDetailPresenterTests
    {
        private ProductsDetailPresenter productsDetailPresenter;
        private string errorMessage;
        private bool operationSucceeded;

        public ProductsDetailPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            ProductsDetailUC productsDetailUC = new ProductsDetailUC(errorMessageView);
            productsDetailPresenter = new ProductsDetailPresenter(productsDetailUC, ServicesInitializator.facade);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void GetProductsDetailUC_ShouldReturnProductsDetailUC()
        {
            ProductsDetailUC productsDetailUC = null;
            try
            {
                productsDetailUC = (ProductsDetailUC)productsDetailPresenter.GetProductsDetailUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            Assert.IsNotNull(productsDetailUC, errorMessage);
        }

        [TestMethod]
        public void SetupProductsDetailForAdd_ShouldReturn_Success()
        {
            try
            {
                productsDetailPresenter.SetupProductsDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SetupProductsDetailForEdit_ShouldReturn_Success()
        {
            try
            {
                productsDetailPresenter.SetupProductsDetailForEdit(1);
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