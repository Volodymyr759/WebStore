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
        private string errorMessage;
        private bool operationSucceeded;
        private GroupsService groupsService;
        private Mock<IGroupsRepository> fakeGroupsRepository;

        [TestInitialize]
        public void TestInit()
        {
            fakeGroupsRepository = new Mock<IGroupsRepository>();
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeGroupsRepository = null;
        }

        [TestMethod]
        public void AddGroup_ShouldReturn_Success()
        {
            // Arrange
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

            try
            {
                // Act
                groupsService.AddGroup(groupDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteById_ShouldReturn_Success()
        {
            // Arrange
            fakeGroupsRepository.Setup(a => a.DeleteById(1));
            groupsService = new GroupsService(fakeGroupsRepository.Object);

            try
            {
                // Act
                groupsService.DeleteGroupById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetGroupById_ShouldReturn_NotNull()
        {
            // Arrange
            GroupsDtoModel group = null;
            fakeGroupsRepository.Setup(a => a.GetById(1)).Returns(new GroupsModel());
            groupsService = new GroupsService(fakeGroupsRepository.Object);

            try
            {
                // Act
                group = groupsService.GetGroupById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsNotNull(group, errorMessage);
        }

        [TestMethod]
        public void GetGroups_ShouldReturn_NotNull()
        {
            // Arrange
            var groups = new List<GroupsModel> { new GroupsModel() };
            List<GroupsDtoModel> groupsDtos = new List<GroupsDtoModel>();
            fakeGroupsRepository.Setup(a => a.GetAll()).Returns(groups);
            groupsService = new GroupsService(fakeGroupsRepository.Object);

            try
            {
                // Act
                groupsDtos = (List<GroupsDtoModel>)groupsService.GetGroups();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(groupsDtos.Count > 0, errorMessage);
        }

        [TestMethod]
        public void Update_ShouldReturn_Success()
        {
            // Arrange
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

            try
            {
                // Act
                groupsService.UpdateGroup(groupDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(operationSucceeded, errorMessage);
        }
    }
}