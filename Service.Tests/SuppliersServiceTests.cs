using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.SuppliersServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass()]
    public class SuppliersServiceTests
    {
        bool operationSucceeded;
        SuppliersService suppliersService;
        string errorMessage;
        const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        public SuppliersServiceTests()
        {
            suppliersService = new SuppliersService(new SuppliersRepository(connString));
        }

        [TestMethod()]
        public void AddSupplier_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            SuppliersDtoModel supplierDto = new SuppliersDtoModel()
            {
                Name = "New supplier",
                Link = "Suppliers link1",
                Currency = "Eur",
                Notes = "some notes for supplier1"
            };
            try
            {
                suppliersService.AddSupplier(supplierDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteSupplierById_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            try
            {
                suppliersService.DeleteSupplierById(11111);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetSupplierById_ShouldReturn_NotNull()
        {
            errorMessage = "";
            SuppliersDtoModel supplierDto = null;
            try
            {
                supplierDto = suppliersService.GetSupplierById(2);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(supplierDto, errorMessage);
        }

        [TestMethod()]
        public void GetSuppliers_ShouldReturn_ListSuppliersDtoModel()
        {
            errorMessage = "";
            var suppliersDtos = new List<SuppliersDtoModel>();
            try
            {
                suppliersDtos = (List<SuppliersDtoModel>)suppliersService.GetSuppliers();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(suppliersDtos.Count > 0, errorMessage);
        }

        [TestMethod()]
        public void UpdateSupplier_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            SuppliersDtoModel supplierDto = new SuppliersDtoModel()
            {
                Id = 3,
                Name = "New supplier",
                Link = "Suppliers link1",
                Currency = "Eur",
                Notes = "some notes for supplier1"
            };
            try
            {
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