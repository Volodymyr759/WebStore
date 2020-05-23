using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ParametersServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass()]
    public class ParametersServiceTests
    {
        bool operationSucceeded;
        string errorMessage;
        ParametersService parametersService;
        const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        public ParametersServiceTests()
        {
            UnitsService unitsService = new UnitsService(new UnitsRepository(connString));
            SuppliersService suppliersService = new SuppliersService(new SuppliersRepository(connString));
            ParametersService parametersService = new ParametersService(new ParametersRepository(connString),
                                    new ProductsService(new ProductsRepository(connString),
                                        new CategoriesService(new CategoriesRepository(connString), suppliersService),
                                        new GroupsService(new GroupsRepository(connString)),
                                        suppliersService, unitsService),
                                    unitsService);
            this.parametersService = parametersService;
        }

        [TestMethod()]
        public void AddParameter_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            ParametersDtoModel parameterDto = new ParametersDtoModel()
            {
                Name = "Parameter1",
                ProductId = 1,
                ProductName = "Product name",
                UnitId = 1,
                UnitName = "Unit",
                Value = "value1"
            };
            try
            {
                parametersService.AddParameter(parameterDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteParameterById_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                parametersService.DeleteParameterById(11111);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetParameterById_ShouldReturn_NotNull()
        {
            errorMessage = "";
            ParametersDtoModel parametersModel = null;
            try
            {
                parametersModel = parametersService.GetParameterById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(parametersModel, errorMessage);
        }

        [TestMethod()]
        public void GetParameters_ShouldReturn_ListParameterDtoModel()
        {
            errorMessage = "";
            List<ParametersDtoModel> parametersDtos = new List<ParametersDtoModel>();
            try
            {
                parametersDtos = (List<ParametersDtoModel>)parametersService.GetParameters();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(parametersDtos.Count > 0, errorMessage);
        }

        [TestMethod()]
        public void UpdateParameter_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            ParametersDtoModel parameterDto = new ParametersDtoModel()
            {
                Id = 1,
                ProductId = 1,
                Name = "Updated Parameter1",
                UnitId = 2,
                Value = "value1"
            };
            try
            {
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