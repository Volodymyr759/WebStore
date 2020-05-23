using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class GroupsDetailPresenterTests
    {
        private GroupsDetailPresenter groupsDetailPresenter;
        string errorMessage;

        public GroupsDetailPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            //DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            GroupsDetailUC groupsDetailUC = new GroupsDetailUC(errorMessageView);
            groupsDetailPresenter = new GroupsDetailPresenter(groupsDetailUC, ServicesInitializator.facade);
        }

        [TestMethod()]
        public void GetGroupsDetailUC_ShouldReturnGroupsDetailUC()
        {
            GroupsDetailUC groupsDetailUC = null;
            errorMessage = "";
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

        [TestMethod()]
        public void SetupGroupsDetailForAdd()
        {
            errorMessage = "";
            bool operationSucceeded = false;
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

        [TestMethod()]
        public void SetupGroupsDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            errorMessage = "";
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