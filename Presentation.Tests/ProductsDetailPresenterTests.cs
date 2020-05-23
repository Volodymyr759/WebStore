using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class ProductsDetailPresenterTests
    {
        private ProductsDetailPresenter productsDetailPresenter;

        public ProductsDetailPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            ProductsDetailUC productsDetailUC = new ProductsDetailUC(errorMessageView);
            productsDetailPresenter = new ProductsDetailPresenter(productsDetailUC, ServicesInitializator.facade);
        }

        [TestMethod()]
        public void GetProductsDetailUC_ShouldReturnProductsDetailUC()
        {
            ProductsDetailUC productsDetailUC = null;
            try
            {
                productsDetailUC = (ProductsDetailUC)productsDetailPresenter.GetProductsDetailUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(productsDetailUC);
        }

        [TestMethod()]
        public void SetupProductsDetailForAdd_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                productsDetailPresenter.SetupProductsDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupProductsDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                productsDetailPresenter.SetupProductsDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }
    }
}