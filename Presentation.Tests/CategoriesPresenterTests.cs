using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class CategoriesPresenterTests
    {
        private CategoriesPresenter categoriesPresenter;

        public CategoriesPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            CategoriesDetailUC categoriesDetailUC = new CategoriesDetailUC(errorMessageView);
            CategoriesDetailPresenter categoriesDetailPresenter = new CategoriesDetailPresenter(categoriesDetailUC, ServicesInitializator.facade);
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            categoriesPresenter = new CategoriesPresenter(new CategoriesUC(errorMessageView), 
                categoriesDetailPresenter, ServicesInitializator.facade, deleteConfirmView, errorMessageView);
        }

        [TestMethod]
        public void GetCategoriesUCTest_ShouldReturnCategoriesUC()
        {
            string errorMessage = "";
            CategoriesUC categoriesUC = null;
            try
            {
                categoriesUC = (CategoriesUC)categoriesPresenter.GetCategoriesUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(categoriesUC, errorMessage);
        }
    }
}