using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Tests
{
    [TestClass()]
    public class ProductsDetailPresenterTests
    {
        private ProductsDetailPresenter productsDetailPresenter;

        public ProductsDetailPresenterTests()
        {
            productsDetailPresenter = new ProductsDetailPresenter();
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