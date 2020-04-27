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
    public class ProductsPresenterTests
    {
        private ProductsPresenter productsPresenter;

        [TestMethod()]
        public void GetProductsUCTest_ShouldReturnProductsUC()
        {
            productsPresenter = new ProductsPresenter();
            ProductsUC productsUC = null;

            try
            {
                productsUC = (ProductsUC)productsPresenter.GetProductsUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(productsUC);
        }
    }
}