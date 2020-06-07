using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using System;
using System.Collections.Generic;

namespace Presentation.Tests
{
    [TestClass]
    public class ProductsDetailPresenterTests
    {
        private Mock<IStoreFacade> fakeFacadeService;

        private ProductsDetailUC productsDetailUC;

        private ErrorMessageView errorMessageView = new ErrorMessageView();

        private ProductsDetailPresenter productsDetailPresenter;

        private string errorMessage;

        private bool operationSucceeded;

        [TestInitialize]
        public void TestInit()
        {
            fakeFacadeService = new Mock<IStoreFacade>();
            productsDetailUC = new ProductsDetailUC(errorMessageView);
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeFacadeService = null;
            productsDetailUC = null;
        }

        [TestMethod]
        public void SetupProductsDetailForAdd_ShouldReturn_Success()
        {
            // Arrange
            fakeFacadeService.Setup(s => s.GetSuppliersDto()).Returns(new List<SuppliersDtoModel>());
            fakeFacadeService.Setup(c => c.GetCategoriesDto()).Returns(new List<CategoriesDtoModel>());
            fakeFacadeService.Setup(g => g.GetGroupsDto()).Returns(new List<GroupsDtoModel>());
            fakeFacadeService.Setup(u => u.GetUnitsDto()).Returns(new List<UnitsDtoModel>());
            productsDetailPresenter = new ProductsDetailPresenter(productsDetailUC,
                fakeFacadeService.Object);

            try
            {
                // Act
                productsDetailPresenter.SetupProductsDetailForAdd();
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
        public void SetupProductsDetailForEdit_ShouldReturn_Success()
        {
            // Arrange
            ProductsDtoModel productsDto = new ProductsDtoModel
            {
                Id = 1,
                SupplierId = 4,
                SupplierName = "supplier",
                CategoryId = 2,
                CategoryName = "category",
                GroupId = 1,
                GroupName = "group",
                UnitId = 1,
                UnitName = "unit",
                NameWebStore = "product1",
                NameSupplier = "Product1",
                CodeWebStore = "111",
                CodeSupplier = "112",
                PriceWebStore = 1.5m,
                PriceSupplier = 1,
                Currency = "USD",
                Available = "+",
                LinkWebStore = "link1",
                LinkSupplier = "link2",
                Notes = "some notes"
            };
            fakeFacadeService.Setup(s => s.GetSuppliersDto()).Returns(new List<SuppliersDtoModel>());
            fakeFacadeService.Setup(c => c.GetCategoriesDto()).Returns(new List<CategoriesDtoModel>());
            fakeFacadeService.Setup(g => g.GetGroupsDto()).Returns(new List<GroupsDtoModel>());
            fakeFacadeService.Setup(u => u.GetUnitsDto()).Returns(new List<UnitsDtoModel>());
            fakeFacadeService.Setup(p => p.GetProductById(1)).Returns(productsDto);
            productsDetailPresenter = new ProductsDetailPresenter(productsDetailUC,
                fakeFacadeService.Object);

            try
            {
                // Act
                productsDetailPresenter.SetupProductsDetailForEdit(1);
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