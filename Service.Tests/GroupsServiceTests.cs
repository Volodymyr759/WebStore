using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.GroupsServices;
using System;
using System.Collections.Generic;
using Domain.Models.Groups;

namespace Service.Tests
{
    [TestClass]
    public class GroupsServiceTests
    {
        string errorMessage;
        bool operationSucceeded;
        GroupsService groupsService;
        Mock<IGroupsRepository> fakeGroupsRepository = new Mock<IGroupsRepository>();

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void AddGroup_ShouldReturn_Success()
        {
            try
            {
                GroupsModel group = new GroupsModel()
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
                fakeGroupsRepository.Setup(a => a.Add(group));
                groupsService = new GroupsService(fakeGroupsRepository.Object);

                GroupsDtoModel groupDto = new GroupsDtoModel()
                {
                    Name = group.Name,
                    Number = group.Number,
                    Identifier = group.Identifier,
                    AncestorNumber = group.AncestorNumber,
                    AncestorIdentifier = group.AncestorIdentifier,
                    ProductType = group.ProductType,
                    Link = group.Link,
                    Notes = group.Notes
                };

                groupsService.AddGroup(groupDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteById_ShouldReturn_Success()
        {
            try
            {
                fakeGroupsRepository.Setup(a => a.DeleteById(1));
                groupsService = new GroupsService(fakeGroupsRepository.Object);

                groupsService.DeleteGroupById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetGroupById_ShouldReturn_NotNull()
        {
            GroupsDtoModel group = null;
            try
            {
                fakeGroupsRepository.Setup(a => a.GetById(1)).Returns(new GroupsModel());
                groupsService = new GroupsService(fakeGroupsRepository.Object);

                group = groupsService.GetGroupById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(group, errorMessage);
        }

        [TestMethod]
        public void GetGroups_ShouldReturn_NotNull()
        {
            var groups = new List<GroupsModel> { new GroupsModel() };
            List<GroupsDtoModel> groupsDtos = new List<GroupsDtoModel>();
            try
            {
                fakeGroupsRepository.Setup(a => a.GetAll()).Returns(groups);
                groupsService = new GroupsService(fakeGroupsRepository.Object);

                groupsDtos = (List<GroupsDtoModel>)groupsService.GetGroups();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(groupsDtos.Count > 0, errorMessage);
        }

        [TestMethod]
        public void Update_ShouldReturn_Success()
        {
            try
            {
                GroupsModel group = new GroupsModel()
                {
                    Name = "name to update",
                    Number = "1",
                    Identifier = "_1",
                    AncestorNumber = "2",
                    AncestorIdentifier = "_2",
                    ProductType = "r",
                    Link = "some link",
                    Notes = "some notes"
                };
                fakeGroupsRepository.Setup(a => a.Update(group));
                groupsService = new GroupsService(fakeGroupsRepository.Object);

                GroupsDtoModel groupDto = new GroupsDtoModel()
                {
                    Name = group.Name,
                    Number = group.Number,
                    Identifier = group.Identifier,
                    AncestorNumber = group.AncestorNumber,
                    AncestorIdentifier = group.AncestorIdentifier,
                    ProductType = group.ProductType,
                    Link = group.Link,
                    Notes = group.Notes
                };
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