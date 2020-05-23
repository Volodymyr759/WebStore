using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class GroupsPresenterTests
    {
        private GroupsPresenter groupsPresenter;
        string errorMessage;

        public GroupsPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            GroupsDetailUC groupsDetailUC = new GroupsDetailUC(errorMessageView);
            GroupsDetailPresenter groupsDetailPresenter = new GroupsDetailPresenter(groupsDetailUC, ServicesInitializator.facade);
            groupsPresenter = new GroupsPresenter(new GroupsUC(errorMessageView), groupsDetailPresenter, ServicesInitializator.facade, deleteConfirmView, errorMessageView);
        }

        [TestMethod()]
        public void GetGroupsUCTest_ShouldReturnGroupsUC()
        {
            GroupsUC groupsUC = null;
            errorMessage = "";
            try
            {
                groupsUC = (GroupsUC)groupsPresenter.GetGroupsUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(groupsUC, errorMessage);
        }
    }
}