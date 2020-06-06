using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class GroupsPresenterTests
    {
        private GroupsPresenter groupsPresenter;

        public GroupsPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            GroupsDetailUC groupsDetailUC = new GroupsDetailUC(errorMessageView);
            GroupsDetailPresenter groupsDetailPresenter = new GroupsDetailPresenter(groupsDetailUC, ServicesInitialiser.facade);
            groupsPresenter = new GroupsPresenter(new GroupsUC(errorMessageView), groupsDetailPresenter, ServicesInitialiser.facade, deleteConfirmView, errorMessageView);
        }

        [TestMethod]
        public void GetGroupsUCTest_ShouldReturnGroupsUC()
        {
            GroupsUC groupsUC = null;
            string errorMessage = "";
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