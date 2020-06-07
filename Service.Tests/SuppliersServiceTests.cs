using Domain.Models.Suppliers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.SuppliersServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass]
    public class SuppliersServiceTests
    {
        private string errorMessage;
        private bool operationSucceeded;
        private SuppliersService suppliersService;
        private Mock<ISuppliersRepository> fakeSuppliersRepository;

        [TestInitialize]
        public void TestInit()
        {
            fakeSuppliersRepository = new Mock<ISuppliersRepository>();
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeSuppliersRepository = null;
        }

        [TestMethod]
        public void AddSupplier_ShouldReturn_Success()
        {
            // Arrange
            SuppliersModel supplier = new SuppliersModel
            {
                Name = "New supplier",
                Link = "Suppliers link1",
                Currency = "Eur",
                Notes = "some notes for supplier1"
            };
            fakeSuppliersRepository.Setup(a => a.Add(supplier));
            suppliersService = new SuppliersService(fakeSuppliersRepository.Object);
            SuppliersDtoModel supplierDto = new SuppliersDtoModel()
            {
                Name = supplier.Name,
                Link = supplier.Link,
                Currency = supplier.Currency,
                Notes = supplier.Notes
            };

            try
            {
                // Act
                suppliersService.AddSupplier(supplierDto);
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
        public void DeleteSupplierById_ShouldReturn_Success()
        {
            // Arrange
            fakeSuppliersRepository.Setup(a => a.DeleteById(1));
            suppliersService = new SuppliersService(fakeSuppliersRepository.Object);

            try
            {
                // Act
                suppliersService.DeleteSupplierById(1);
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
        public void GetSupplierById_ShouldReturn_NotNull()
        {
            // Arrange
            fakeSuppliersRepository.Setup(a => a.GetById(1)).Returns(new SuppliersModel());
            suppliersService = new SuppliersService(fakeSuppliersRepository.Object);
            SuppliersDtoModel supplierDto = null;
            try
            {
                // Act
                supplierDto = suppliersService.GetSupplierById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsNotNull(supplierDto, errorMessage);
        }

        [TestMethod]
        public void GetSuppliers_ShouldReturn_NotNull()
        {
            // Arrange
            List<SuppliersModel> suppliers = new List<SuppliersModel> { new SuppliersModel() };
            List<SuppliersDtoModel> suppliersDtos = new List<SuppliersDtoModel>();
            fakeSuppliersRepository.Setup(a => a.GetAll()).Returns(suppliers);
            suppliersService = new SuppliersService(fakeSuppliersRepository.Object);

            try
            {
                // Act
                suppliersDtos = (List<SuppliersDtoModel>)suppliersService.GetSuppliers();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsTrue(suppliersDtos.Count > 0, errorMessage);
        }

        [TestMethod]
        public void UpdateSupplier_ShouldReturn_Success()
        {
            // Arrange
            SuppliersModel supplier = new SuppliersModel
            {
                Name = "Name to update",
                Link = "link to update",
                Currency = "Eur",
                Notes = "notes to update"
            };
            fakeSuppliersRepository.Setup(a => a.Update(supplier));
            suppliersService = new SuppliersService(fakeSuppliersRepository.Object);
            SuppliersDtoModel supplierDto = new SuppliersDtoModel()
            {
                Name = supplier.Name,
                Link = supplier.Link,
                Currency = supplier.Currency,
                Notes = supplier.Notes
            };

            try
            {
                // Act
                suppliersService.UpdateSupplier(supplierDto);
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