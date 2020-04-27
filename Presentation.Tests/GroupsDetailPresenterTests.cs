using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Tests
{
    [TestClass()]
    public class GroupsDetailPresenterTests
    {
        private GroupsDetailPresenter groupsDetailPresenter;

        public GroupsDetailPresenterTests()
        {
            groupsDetailPresenter = new GroupsDetailPresenter();
        }

        [TestMethod()]
        public void GetGroupsDetailUC_ShouldReturnGroupsDetailUC()
        {
            GroupsDetailUC groupsDetailUC = null;

            try
            {
                groupsDetailUC = (GroupsDetailUC)groupsDetailPresenter.GetGroupsDetailUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(groupsDetailUC);
        }

        [TestMethod()]
        public void SetupGroupsDetailForAddv()
        {
            bool operationSucceeded = false;
            try
            {
                groupsDetailPresenter.SetupGroupsDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupGroupsDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                groupsDetailPresenter.SetupGroupsDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }
    }
}