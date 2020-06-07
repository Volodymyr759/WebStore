using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services;
using Services.CategoriesServices;
using Services.SuppliersServices;
using System;
using System.Collections.Generic;

namespace Presentation.Tests
{
    [TestClass]
    public class CategoriesDetailPresenterTests
    {
        private Mock<IStoreFacade> fakeFacadeService;

        private CategoriesDetailUC categoriesDetailUC;

        private ErrorMessageView errorMessageView = new ErrorMessageView();

        private CategoriesDetailPresenter categoriesDetailPresenter;

        private string errorMessage;

        private bool operationSucceeded;

        [TestInitialize]
        public void TestInit()
        {
            fakeFacadeService = new Mock<IStoreFacade>();
            categoriesDetailUC = new CategoriesDetailUC(errorMessageView);
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeFacadeService = null;
            categoriesDetailUC = null;
        }

        [TestMethod]
        public void SetupCategoriesDetailForAdd_ShouldReturn_Success()
        {
            // Arrange
            fakeFacadeService.Setup(c => c.GetSuppliersDto()).Returns(new List<SuppliersDtoModel>());
            categoriesDetailPresenter = new CategoriesDetailPresenter(categoriesDetailUC, fakeFacadeService.Object);

            try
            {
                // Act
                categoriesDetailPresenter.SetupCategoriesDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SetupCategoriesDetailForEdit_ShouldReturn_Success()
        {
            // Arrange
            CategoriesDtoModel categoriesDto = new CategoriesDtoModel
            {
                Id = 1,
                Name = "name",
                SupplierId = 1,
                SupplierName = "supplier",
                Link = "link",
                Rate = 1.5m,
                Notes = "notes"
            };
            fakeFacadeService.Setup(c => c.GetCategoryById(1)).Returns(categoriesDto);
            categoriesDetailPresenter = new CategoriesDetailPresenter(categoriesDetailUC, fakeFacadeService.Object);

            try
            {
                // Act
                categoriesDetailPresenter.SetupCategoriesDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(operationSucceeded, errorMessage);
        }
    }
}