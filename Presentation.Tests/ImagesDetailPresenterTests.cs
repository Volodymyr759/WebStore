using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services;
using Services.ImagesServices;
using Services.ProductsServices;
using System;
using System.Collections.Generic;

namespace Presentation.Tests
{
    [TestClass]
    public class ImagesDetailPresenterTests
    {
        private Mock<IStoreFacade> fakeFacadeService;

        private ErrorMessageView errorMessageView = new ErrorMessageView();

        private ImagesDetailPresenter imagesDetailPresenter;

        private string errorMessage;

        private bool operationSucceeded;

        [TestInitialize]
        public void TestInit()
        {
            fakeFacadeService = new Mock<IStoreFacade>();
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeFacadeService = null;
        }

        [TestMethod]
        public void SetupImagesDetailForAdd_ShouldReturn_Success()
        {
            // Arrange
            fakeFacadeService.Setup(p => p.GetProductsDto()).Returns(new List<ProductsDtoModel>());
            imagesDetailPresenter = new ImagesDetailPresenter(new ImagesDetailUC(errorMessageView), 
                fakeFacadeService.Object);

            try
            {
                // Act
                imagesDetailPresenter.SetupImagesDetailForAdd();
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
        public void SetupImagesDetailForEdit_ShouldReturn_Success()
        {
            // Arrange
            ImagesDtoModel imagesDto = new ImagesDtoModel
            {
                Id = 1,
                ProductId = 1,
                ProductName = "product",
                FileName = "filename",
                LinkSupplier = "linksupplier",
                LinkWebStore = "linkwebstore",
                LocalPath = "localpath"
            };
            fakeFacadeService.Setup(i => i.GetImageById(1)).Returns(imagesDto);
            imagesDetailPresenter = new ImagesDetailPresenter(new ImagesDetailUC(errorMessageView), 
                fakeFacadeService.Object);

            try
            {
                // Act
                imagesDetailPresenter.SetupImagesDetailForEdit(1);
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