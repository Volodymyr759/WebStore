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
    public class GroupsPresenterTests
    {
        private GroupsPresenter groupsPresenter;

        [TestMethod()]
        public void GetGroupsUCTest_ShouldReturnGroupsUC()
        {
            groupsPresenter = new GroupsPresenter();
            GroupsUC groupsUC = null;

            try
            {
                groupsUC = (GroupsUC)groupsPresenter.GetGroupsUC();
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(groupsUC);
        }
    }
}