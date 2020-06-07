using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services;
using Services.GroupsServices;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class GroupsDetailPresenterTests
    {
        [TestMethod]
        public void SetupGroupsDetailForEdit_ShouldReturn_Success()
        {
            // Arrange
            GroupsDtoModel groupsDto = new GroupsDtoModel
            {
                Id = 1,
                Name = "name",
                ProductType = "r",
                Number = "number",
                Identifier = "identifier",
                AncestorNumber = "ancestornumber",
                AncestorIdentifier = "ancestoridentifier",
                Link = "link",
                Notes = "notes"
            };
            Mock<IStoreFacade> fakeFacadeService = new Mock<IStoreFacade>();
            fakeFacadeService.Setup(g => g.GetGroupById(1)).Returns(groupsDto);
            GroupsDetailPresenter groupsDetailPresenter = new GroupsDetailPresenter(
                new GroupsDetailUC(new ErrorMessageView()), fakeFacadeService.Object);
            bool operationSucceeded = false;
            string errorMessage = "";

            try
            {
                // Act
                groupsDetailPresenter.SetupGroupsDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            //Assert
            Assert.IsTrue(operationSucceeded, errorMessage);
        }
    }
}