using Domain.Models.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ParametersService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class ParametersServiceTests
    {
        bool operationSucceeded;
        ParametersService parametersService;

        public ParametersServiceTests()
        {
            parametersService = new ParametersService();
        }

        [TestMethod()]
        public void Add_ShouldReturn_Success()
        {
            operationSucceeded = false;
            ParametersModel parametersModel = new ParametersModel();
            try
            {
                parametersService.Add(parametersModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void DeleteById_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                parametersService.DeleteById(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void GetById_ShouldReturn_Success()
        {
            ParametersModel parametersModel = null;
            try
            {
                parametersModel = (ParametersModel)parametersService.GetById(1);
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(parametersModel);
        }

        [TestMethod()]
        public void GetParametersToList_ShouldReturn_NotEmpty()
        {
            var parametersModels = new List<ParametersDtoModel>();
            try
            {
                parametersModels = parametersService.GetParametersToList();
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(parametersModels.Count > 0);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            ParametersModel parametersModel = new ParametersModel();
            try
            {
                parametersService.Update(parametersModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}