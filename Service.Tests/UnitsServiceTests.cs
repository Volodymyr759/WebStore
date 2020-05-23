using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.UnitsServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass()]
    public class UnitsServiceTests
    {
        bool operationSucceeded;
        UnitsService unitsService;
        string errorMessage;
        const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        public UnitsServiceTests()
        {
            unitsService = new UnitsService(new UnitsRepository(connString));
        }

        [TestMethod()]
        public void AddUnit_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            UnitsDtoModel unitDto = new UnitsDtoModel { Name = DateTime.Now.Millisecond.ToString(), Notes = "Test" };
            try
            {
                unitsService.AddUnit(unitDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteUnitById_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                unitsService.DeleteUnitById(11111);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetUnitById_ShouldReturn_NotNull()
        {
            errorMessage = "";
            UnitsDtoModel unitDto = null;
            try
            {
                unitDto = unitsService.GetUnitById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(unitDto, errorMessage);
        }

        [TestMethod()]
        public void GetUnits_ShouldReturn_ListUnitsDtoModel()
        {
            errorMessage = "";
            var unitsDtos = new List<UnitsDtoModel>();
            try
            {
                unitsDtos = (List<UnitsDtoModel>)unitsService.GetUnits();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(unitsDtos.Count > 0, errorMessage);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            UnitsDtoModel unitDto = new UnitsDtoModel { Id = 1, Name = DateTime.Now.Millisecond.ToString(), Notes = "Test" };
            try
            {
                unitsService.UpdateUnit(unitDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded,errorMessage);
        }
    }
}