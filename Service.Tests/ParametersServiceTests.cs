using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ParametersServices;
using System;
using System.Collections.Generic;
using Moq;
using Domain.Models.Parameters;
using Services;

namespace Service.Tests
{
    [TestClass]
    public class ParametersServiceTests
    {
        private string errorMessage;
        private bool operationSucceeded;
        private ParametersService parametersService;
        private Mock<IParametersRepository> fakeParametersRepository;

        [TestInitialize]
        public void TestInit()
        {
            fakeParametersRepository = new Mock<IParametersRepository>();
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeParametersRepository = null;
        }

        [TestMethod]
        public void AddParameter_ShouldReturn_Success()
        {
            // Arrange
            ParametersModel parameter = new ParametersModel
            {
                Name = "Parameter1",
                ProductId = 1,
                UnitId = 1,
                Value = "value1"
            };
            fakeParametersRepository.Setup(a => a.Add(parameter));
            parametersService = new ParametersService(fakeParametersRepository.Object, new Mock<ICommonRepository>().Object);
            ParametersDtoModel parameterDto = new ParametersDtoModel
            {
                Name = parameter.Name,
                ProductId = parameter.ProductId,
                ProductName = "Product name",
                UnitId = parameter.UnitId,
                UnitName = "Unit",
                Value = parameter.Value
            };

            try
            {
                // Act
                parametersService.AddParameter(parameterDto);
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
        public void DeleteParameterById_ShouldReturn_Success()
        {
            // Arrange
            fakeParametersRepository.Setup(a => a.DeleteById(1));
            parametersService = new ParametersService(fakeParametersRepository.Object, new Mock<ICommonRepository>().Object);

            try
            {
                // Act
                parametersService.DeleteParameterById(1);
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
        public void GetParameterById_ShouldReturn_NotNull()
        {
            // Arrange
            fakeParametersRepository.Setup(a => a.GetById(1)).Returns(new ParametersModel { Id = 1, Name = "Param", ProductId = 1, UnitId = 1, Value = "W" });
            Mock<ICommonRepository> fakeCommonRepository = new Mock<ICommonRepository>();
            fakeCommonRepository.Setup(a => a.GetProductsIdNames()).Returns(new Dictionary<int, string> { { 1, "Product name" } });
            fakeCommonRepository.Setup(a => a.GetUnitsIdNames()).Returns(new Dictionary<int, string> { { 1, "p." } });
            parametersService = new ParametersService(fakeParametersRepository.Object, fakeCommonRepository.Object);
            ParametersDtoModel parametersModel = null;

            try
            {
                // Act
                parametersModel = parametersService.GetParameterById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsNotNull(parametersModel, errorMessage);
        }

        [TestMethod]
        public void GetParameters_ShouldReturn_NotNull()
        {
            // Arrange
            List<ParametersDtoModel> parametersDtos = new List<ParametersDtoModel>();
            fakeParametersRepository.Setup(a => a.GetAll()).Returns(new List<ParametersModel>());
            parametersService = new ParametersService(fakeParametersRepository.Object, new Mock<ICommonRepository>().Object);

            try
            {
                // Act
                parametersDtos = (List<ParametersDtoModel>)parametersService.GetParameters();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsNotNull(parametersDtos, errorMessage);
        }

        [TestMethod]
        public void UpdateParameter_ShouldReturn_Success()
        {
            // Arrange
            ParametersModel parameter = new ParametersModel
            {
                Name = "NewParameter",
                ProductId = 1,
                UnitId = 1,
                Value = "New value"
            };
            fakeParametersRepository.Setup(a => a.Update(parameter));
            parametersService = new ParametersService(fakeParametersRepository.Object, new Mock<ICommonRepository>().Object);
            ParametersDtoModel parameterDto = new ParametersDtoModel
            {
                Name = parameter.Name,
                ProductId = parameter.ProductId,
                ProductName = "Product name",
                UnitId = parameter.UnitId,
                UnitName = "Unit",
                Value = parameter.Value
            };

            try
            {
                // Act
                parametersService.UpdateParameter(parameterDto);
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