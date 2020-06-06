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
        string errorMessage;
        bool operationSucceeded;
        SuppliersService suppliersService;
        Mock<ISuppliersRepository> fakeSuppliersRepository = new Mock<ISuppliersRepository>();

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void AddSupplier_ShouldReturn_Success()
        {
            try
            {
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

                suppliersService.AddSupplier(supplierDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteSupplierById_ShouldReturn_Success()
        {
            try
            {
                fakeSuppliersRepository.Setup(a => a.DeleteById(1));
                suppliersService = new SuppliersService(fakeSuppliersRepository.Object);

                suppliersService.DeleteSupplierById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetSupplierById_ShouldReturn_NotNull()
        {
            SuppliersDtoModel supplierDto = null;
            try
            {
                fakeSuppliersRepository.Setup(a => a.GetById(1)).Returns(new SuppliersModel());
                suppliersService = new SuppliersService(fakeSuppliersRepository.Object);

                supplierDto = suppliersService.GetSupplierById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(supplierDto, errorMessage);
        }

        [TestMethod]
        public void GetSuppliers_ShouldReturn_NotNull()
        {
            var suppliers = new List<SuppliersModel> { new SuppliersModel() };
            var suppliersDtos = new List<SuppliersDtoModel>();
            try
            {
                fakeSuppliersRepository.Setup(a => a.GetAll()).Returns(suppliers);
                suppliersService = new SuppliersService(fakeSuppliersRepository.Object);

                suppliersDtos = (List<SuppliersDtoModel>)suppliersService.GetSuppliers();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(suppliersDtos.Count > 0, errorMessage);
        }

        [TestMethod]
        public void UpdateSupplier_ShouldReturn_Success()
        {
            try
            {
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

                suppliersService.UpdateSupplier(supplierDto);
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