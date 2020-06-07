using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services;
using Services.SuppliersServices;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class SuppliersDetailPresenterTests
    {
        [TestMethod]
        public void SetupSuppliersDetailForEdit_ShouldReturn_Success()
        {
            // Arrange
            SuppliersDtoModel suppliersDto = new SuppliersDtoModel
            {
                Id = 1,
                Name = "supplier",
                Link = "link",
                Currency = "USD",
                Notes = "notes"
            };
            Mock<IStoreFacade> fakeFacadeService = new Mock<IStoreFacade>();
            fakeFacadeService.Setup(s => s.GetSupplierById(1)).Returns(suppliersDto);
            SuppliersDetailPresenter suppliersDetailPresenter = new SuppliersDetailPresenter(
                new SuppliersDetailUC(new ErrorMessageView()), fakeFacadeService.Object);
            bool operationSucceeded = false;
            string errorMessage = "";

            try
            {
                // Act
                suppliersDetailPresenter.SetupSuppliersDetailForEdit(1);
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