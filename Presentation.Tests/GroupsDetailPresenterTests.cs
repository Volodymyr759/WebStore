using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class GroupsDetailPresenterTests
    {
        private GroupsDetailPresenter groupsDetailPresenter;
        private string errorMessage;
        private bool operationSucceeded;

        public GroupsDetailPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            GroupsDetailUC groupsDetailUC = new GroupsDetailUC(errorMessageView);
            groupsDetailPresenter = new GroupsDetailPresenter(groupsDetailUC, ServicesInitializator.facade);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void GetGroupsDetailUC_ShouldReturnGroupsDetailUC()
        {
            GroupsDetailUC groupsDetailUC = null;
            try
            {
                groupsDetailUC = (GroupsDetailUC)groupsDetailPresenter.GetGroupsDetailUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            Assert.IsNotNull(groupsDetailUC, errorMessage);
        }

        [TestMethod]
        public void SetupGroupsDetailForAdd()
        {
            try
            {
                groupsDetailPresenter.SetupGroupsDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SetupGroupsDetailForEdit_ShouldReturn_Success()
        {
            try
            {
                groupsDetailPresenter.SetupGroupsDetailForEdit(1);
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