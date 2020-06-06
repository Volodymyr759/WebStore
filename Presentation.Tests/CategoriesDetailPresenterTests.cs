using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class CategoriesDetailPresenterTests
    {
        private CategoriesDetailPresenter categoriesDetailPresenter;
        private string errorMessage;
        private bool operationSucceeded;

        public CategoriesDetailPresenterTests()
        {
            categoriesDetailPresenter = new CategoriesDetailPresenter(new CategoriesDetailUC(new ErrorMessageView()), 
                ServicesInitialiser.facade);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void GetCategoriesDetailUC_ShouldReturn_CategoriesDetailUC()
        {
            CategoriesDetailUC categoriesDetailUC = null;
            try
            {
                categoriesDetailUC = (CategoriesDetailUC)categoriesDetailPresenter.GetCategoriesDetailUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(categoriesDetailUC, errorMessage);
        }

        [TestMethod]
        public void SetupCategoriesDetailForAdd_ShouldReturn_Success()
        {
            try
            {
                categoriesDetailPresenter.SetupCategoriesDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SetupCategoriesDetailForEdit_ShouldReturn_Success()
        {
            try
            {
                categoriesDetailPresenter.SetupCategoriesDetailForEdit(2);
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