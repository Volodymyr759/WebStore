using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Views.UserControls;
using Services;
using Services.UnitsServices;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class UnitsDetailPresenterTests
    {
        [TestMethod]
        public void SetupUnitsDetailForEdit_ShouldReturn_Success()
        {
            // Arrange
            UnitsDtoModel unitsDto = new UnitsDtoModel
            {
                Id = 1,
                Name = "unit",
                Notes = "notes"
            };
            Mock<IStoreFacade> fakeFacadeService = new Mock<IStoreFacade>();
            fakeFacadeService.Setup(u => u.GetUnitById(1)).Returns(unitsDto);
            UnitsDetailPresenter unitsDetailPresenter = new UnitsDetailPresenter(
                new UnitsDetailUC(new ErrorMessageView()), fakeFacadeService.Object);
            bool operationSucceeded = false;
            string errorMessage = "";

            try
            {
                // Act
                unitsDetailPresenter.SetupUnitsDetailForEdit(1);
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