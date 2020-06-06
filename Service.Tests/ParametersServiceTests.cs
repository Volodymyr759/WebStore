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
        string errorMessage;
        bool operationSucceeded;
        ParametersService parametersService;
        Mock<IParametersRepository> fakeParametersRepository = new Mock<IParametersRepository>();

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void AddParameter_ShouldReturn_Success()
        {
            try
            {
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
                parametersService.AddParameter(parameterDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteParameterById_ShouldReturn_Success()
        {
            try
            {
                fakeParametersRepository.Setup(a => a.DeleteById(1));
                parametersService = new ParametersService(fakeParametersRepository.Object, new Mock<ICommonRepository>().Object);
                parametersService.DeleteParameterById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetParameterById_ShouldReturn_NotNull()
        {
            ParametersDtoModel parametersModel = null;
            try
            {
                fakeParametersRepository.Setup(a => a.GetById(1)).Returns(new ParametersModel { Id = 1, Name = "Param", ProductId = 1, UnitId = 1, Value = "W" });
                Mock<ICommonRepository> fakeCommonRepository = new Mock<ICommonRepository>();
                fakeCommonRepository.Setup(a => a.GetProductsIdNames()).Returns(new Dictionary<int, string> { { 1, "Product name" } });
                fakeCommonRepository.Setup(a => a.GetUnitsIdNames()).Returns(new Dictionary<int, string> { { 1, "p." } });

                parametersService = new ParametersService(fakeParametersRepository.Object, fakeCommonRepository.Object);

                parametersModel = parametersService.GetParameterById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(parametersModel, errorMessage);
        }

        [TestMethod]
        public void GetParameters_ShouldReturn_NotNull()
        {
            List<ParametersDtoModel> parametersDtos = new List<ParametersDtoModel>();
            try
            {
                fakeParametersRepository.Setup(a => a.GetAll()).Returns(new List<ParametersModel>());
                parametersService = new ParametersService(fakeParametersRepository.Object, new Mock<ICommonRepository>().Object);

                parametersDtos = (List<ParametersDtoModel>)parametersService.GetParameters();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(parametersDtos, errorMessage);
        }

        [TestMethod]
        public void UpdateParameter_ShouldReturn_Success()
        {
            try
            {
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

                parametersService.UpdateParameter(parameterDto);
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