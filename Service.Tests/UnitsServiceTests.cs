using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.UnitsServices;
using System;
using System.Collections.Generic;
using Moq;
using Domain.Models.Units;

namespace Service.Tests
{
    [TestClass]
    public class UnitsServiceTests
    {
        string errorMessage;
        bool operationSucceeded;
        UnitsService unitsService;
        Mock<IUnitsRepository> fakeUnitsRepository = new Mock<IUnitsRepository>();

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void AddUnit_ShouldReturn_Success()
        {
            try
            {
                UnitsModel unit = new UnitsModel { Name = "g", Notes = "gram" };
                fakeUnitsRepository.Setup(a => a.Add(unit));
                unitsService = new UnitsService(fakeUnitsRepository.Object);

                unitsService.AddUnit(new UnitsDtoModel { Name = unit.Name, Notes = unit.Notes });
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteUnitById_ShouldReturn_Success()
        {
            try
            {
                fakeUnitsRepository.Setup(a => a.DeleteById(1));
                unitsService = new UnitsService(fakeUnitsRepository.Object);

                unitsService.DeleteUnitById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetUnitById_ShouldReturn_NotNull()
        {
            UnitsDtoModel unitDto = null;
            try
            {
                fakeUnitsRepository.Setup(a => a.GetById(1)).Returns(new UnitsModel());
                unitsService = new UnitsService(fakeUnitsRepository.Object);

                unitDto = unitsService.GetUnitById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(unitDto, errorMessage);
        }

        [TestMethod]
        public void GetUnits_ShouldReturn_NotNull()
        {
            var units = new List<UnitsModel> { new UnitsModel() };
            var unitsDtos = new List<UnitsDtoModel>();
            try
            {
                fakeUnitsRepository.Setup(a => a.GetAll()).Returns(units);
                unitsService = new UnitsService(fakeUnitsRepository.Object);

                unitsDtos = (List<UnitsDtoModel>)unitsService.GetUnits();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(unitsDtos.Count > 0, errorMessage);
        }

        [TestMethod]
        public void Update_ShouldReturn_Success()
        {
            try
            {
                UnitsModel unit = new UnitsModel { Id = 1, Name = "g", Notes = "gram" };
                fakeUnitsRepository.Setup(a => a.Update(unit));
                unitsService = new UnitsService(fakeUnitsRepository.Object);

                UnitsDtoModel unitDto = new UnitsDtoModel { Id = 1, Name = "g", Notes = "updated notes" };
                unitsService.UpdateUnit(unitDto);
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
