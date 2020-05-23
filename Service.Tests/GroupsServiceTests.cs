using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.GroupsServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass()]
    public class GroupsServiceTests
    {
        bool operationSucceeded;
        GroupsService groupsService;
        string errorMessage;
        const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        public GroupsServiceTests()
        {
            groupsService = new GroupsService(new GroupsRepository(connString));
        }

        [TestMethod()]
        public void AddGroup_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            GroupsDtoModel group = new GroupsDtoModel()
            {
                Name = "Group 1",
                Number = "1",
                Identifier = "_1",
                AncestorNumber = "2",
                AncestorIdentifier = "_2",
                ProductType = "r",
                Link = "some link",
                Notes = "some notes"
            };
            try
            {
                groupsService.AddGroup(group);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteById_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                groupsService.DeleteGroupById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetGroupById_ShouldReturn_NotNull()
        {
            errorMessage ="";
            GroupsDtoModel group = null;
            try
            {
                group = groupsService.GetGroupById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(group, errorMessage);
        }

        [TestMethod()]
        public void GetGroups_ShouldReturn_ListGroupsDtoModel()
        {
            errorMessage = "";
            operationSucceeded = false;
            List<GroupsDtoModel> groupsDtos = new List<GroupsDtoModel>();
            try
            {
                groupsDtos = (List<GroupsDtoModel>)groupsService.GetGroups();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(groupsDtos.Count>0, errorMessage);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            GroupsDtoModel groupDto = new GroupsDtoModel()
            {
                Id = 1,
                Name = "Updated Group 1",
                Number = "1",
                Identifier = "_1",
                AncestorNumber = "2",
                AncestorIdentifier = "_2",
                ProductType = "r",
                Link = "some link",
                Notes = "some notes"
            };
            try
            {
                groupsService.UpdateGroup(groupDto);
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