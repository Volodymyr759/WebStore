using Domain.Models.Groups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.GroupsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class GroupsServiceTests
    {
        bool operationSucceeded;
        GroupsService groupsService;

        public GroupsServiceTests()
        {
            groupsService = new GroupsService();
        }

        [TestMethod()]
        public void Add_ShouldReturn_Success()
        {
            operationSucceeded = false;
            GroupsModel groupsModel = new GroupsModel();
            try
            {
                groupsService.Add(groupsModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void DeleteById_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                groupsService.DeleteById(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void GetById_ShouldReturn_Success()
        {
            GroupsModel groupsModel = null;
            try
            {
                groupsModel = (GroupsModel)groupsService.GetById(1);
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(groupsModel);
        }

        [TestMethod()]
        public void GetGroupsToList_ShouldReturn_NotEmpty()
        {
            var groupsModels = new List<IGroupsModel>();
            try
            {
                groupsModels = groupsService.GetGroupsToList();
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(groupsModels.Count > 0);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            GroupsModel groupsModel = new GroupsModel();
            try
            {
                groupsService.Update(groupsModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}