﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class ProductsPresenterTests
    {
        private ProductsPresenter productsPresenter;
        private string errorMessage;
        private ProductsUC productsUC;

        public ProductsPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            ProductsDetailUC productsDetailUC = new ProductsDetailUC(errorMessageView);
            ProductsDetailPresenter productsDetailPresenter = new ProductsDetailPresenter(productsDetailUC, ServicesInitialiser.facade);
            productsPresenter = new ProductsPresenter(new ProductsUC(errorMessageView), productsDetailPresenter,
                ServicesInitialiser.facade,
                deleteConfirmView, errorMessageView);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            productsUC = null;
        }

        [TestMethod]
        public void GetProductsUCTest_ShouldReturn_ProductsUC()
        {
            try
            {
                productsUC = (ProductsUC)productsPresenter.GetProductsUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsUC, errorMessage);
        }

        [TestMethod]
        public void GetNewProductsTest_ShouldReturn_ProductsUC()
        {
            try
            {
                productsUC = (ProductsUC)productsPresenter.GetNewProducts();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsUC, errorMessage);
        }

        [TestMethod]
        public void CheckAvailabilityTest_ShouldReturn_ProductsUC()
        {
            try
            {
                productsUC = (ProductsUC)productsPresenter.CheckAvailability();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsUC, errorMessage);
        }

        [TestMethod]
        public void CheckPricesTest_ShouldReturn_ProductsUC()
        {
            try
            {
                productsUC = (ProductsUC)productsPresenter.CheckPrices();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsUC, errorMessage);
        }
    }
}