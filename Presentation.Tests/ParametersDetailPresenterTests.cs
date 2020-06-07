using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services;
using Services.ParametersServices;
using Services.ProductsServices;
using Services.UnitsServices;
using System;
using System.Collections.Generic;

namespace Presentation.Tests
{
    [TestClass]
    public class ParametersDetailPresenterTests
    {
        private Mock<IStoreFacade> fakeFacadeService;

        private ErrorMessageView errorMessageView = new ErrorMessageView();

        ParametersDetailPresenter parametersDetailPresenter;

        private string errorMessage;

        private bool operationSucceeded;

        [TestInitialize]
        public void TestInit()
        {
            List<ProductsDtoModel> productsDtos = new List<ProductsDtoModel>
            {
               new ProductsDtoModel{ Id = 1, NameSupplier = "product name" }
            };
            List<UnitsDtoModel> unitsDtos = new List<UnitsDtoModel>
            {
                new UnitsDtoModel{ Id = 1, Name = "unitname" }
            };
            fakeFacadeService = new Mock<IStoreFacade>();
            fakeFacadeService.Setup(p => p.GetProductsDto()).Returns(productsDtos);
            fakeFacadeService.Setup(p => p.GetUnitsDto()).Returns(unitsDtos);
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeFacadeService = null;
        }

        [TestMethod]
        public void SetupParametersDetailForAdd_ShouldReturn_Success()
        {
            // Arrange
            parametersDetailPresenter = new ParametersDetailPresenter(new ParametersDetailUC(errorMessageView),
                fakeFacadeService.Object);

            try
            {
                // Act
                parametersDetailPresenter.SetupParametersDetailForAdd();
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
        public void SetupParametersDetailForEdit_ShouldReturn_Success()
        {
            // Arrange
            ParametersDtoModel parametersDto = new ParametersDtoModel
            {
                Id = 1,
                Name = "parameter",
                ProductId =1,
                ProductName = "product name",
                UnitId = 1,
                UnitName = "unit",
                Value = "value"
            };
            fakeFacadeService.Setup(p => p.GetParameterById(1)).Returns(parametersDto);
            parametersDetailPresenter = new ParametersDetailPresenter(new ParametersDetailUC(errorMessageView),
               fakeFacadeService.Object);

            try
            {
                // Act
                parametersDetailPresenter.SetupParametersDetailForEdit(1);
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