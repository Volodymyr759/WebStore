using DataAccess.RepositoriesSqlCE;
using Domain.Models.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.UnitsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class UnitsServiceTests
    {
        bool operationSucceeded;
        UnitsService unitsService;
        string errorMessage;

        public UnitsServiceTests()
        {
            unitsService = new UnitsService(new UnitsRepository(@"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf"));
        }

        [TestMethod()]
        public void Add_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            UnitsModel unitsModel = new UnitsModel { Name = DateTime.Now.Millisecond.ToString(), Notes = "Test" };
            try
            {
                unitsService.Add(unitsModel);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteById_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                unitsService.DeleteById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetById_ShouldReturn_Success()
        {
            errorMessage = "";
            UnitsModel unitsModel = null;
            try
            {
                unitsModel = (UnitsModel)unitsService.GetById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.StackTrace;
            }
            Assert.IsNotNull(unitsModel, errorMessage);
        }

        [TestMethod()]
        public void GetUnitsToList_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                var unitsModels = unitsService.GetUnitsToList();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            UnitsModel unitsModel = new UnitsModel { Id =1, Name = DateTime.Now.Millisecond.ToString(), Notes = "Test" };
            try
            {
                unitsService.Update(unitsModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}