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
        private string errorMessage;
        private bool operationSucceeded;
        private UnitsService unitsService;
        private Mock<IUnitsRepository> fakeUnitsRepository;

        [TestInitialize]
        public void TestInit()
        {
            fakeUnitsRepository = new Mock<IUnitsRepository>();
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeUnitsRepository = null;
        }

        [TestMethod]
        public void AddUnit_ShouldReturn_Success()
        {
            // Arrange
            UnitsModel unit = new UnitsModel { Name = "g", Notes = "gram" };
            fakeUnitsRepository.Setup(a => a.Add(unit));
            unitsService = new UnitsService(fakeUnitsRepository.Object);

            try
            {
                // Act
                unitsService.AddUnit(new UnitsDtoModel { Name = unit.Name, Notes = unit.Notes });
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
        public void DeleteUnitById_ShouldReturn_Success()
        {
            // Arrange
            fakeUnitsRepository.Setup(a => a.DeleteById(1));
            unitsService = new UnitsService(fakeUnitsRepository.Object);

            try
            {
                // Act
                unitsService.DeleteUnitById(1);
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
        public void GetUnitById_ShouldReturn_NotNull()
        {
            // Arrange
            fakeUnitsRepository.Setup(a => a.GetById(1)).Returns(new UnitsModel());
            unitsService = new UnitsService(fakeUnitsRepository.Object);

            UnitsDtoModel unitDto = null;
            try
            {
                // Act
                unitDto = unitsService.GetUnitById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsNotNull(unitDto, errorMessage);
        }

        [TestMethod]
        public void GetUnits_ShouldReturn_NotNull()
        {
            // Arrange
            List<UnitsModel> units = new List<UnitsModel> { new UnitsModel() };
            fakeUnitsRepository.Setup(a => a.GetAll()).Returns(units);
            unitsService = new UnitsService(fakeUnitsRepository.Object);

            List<UnitsDtoModel> unitsDtos = new List<UnitsDtoModel>();
            try
            {
                // Act
                unitsDtos = (List<UnitsDtoModel>)unitsService.GetUnits();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(unitsDtos.Count > 0, errorMessage);
        }

        [TestMethod]
        public void Update_ShouldReturn_Success()
        {
            // Arrange
            UnitsModel unit = new UnitsModel { Id = 1, Name = "g", Notes = "gram" };
            fakeUnitsRepository.Setup(a => a.Update(unit));
            unitsService = new UnitsService(fakeUnitsRepository.Object);
            UnitsDtoModel unitDto = new UnitsDtoModel { Id = 1, Name = "g", Notes = "updated notes" };

            try
            {
                // Act
                unitsService.UpdateUnit(unitDto);
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
