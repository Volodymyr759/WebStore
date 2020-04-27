using Domain.Models.Suppliers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.SuppliersService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class SuppliersServiceTests
    {
        bool operationSucceeded;
        SuppliersService suppliersService;

        public SuppliersServiceTests()
        {
            suppliersService = new SuppliersService();
        }

        [TestMethod()]
        public void Add_ShouldReturn_Success()
        {
            operationSucceeded = false;
            SuppliersModel suppliersModel = new SuppliersModel();
            try
            {
                suppliersService.Add(suppliersModel);
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
                suppliersService.DeleteById(1);
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
            SuppliersModel suppliersModel = null;
            try
            {
                suppliersModel = (SuppliersModel)suppliersService.GetById(1);
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(suppliersModel);
        }

        [TestMethod()]
        public void GetSuppliersToList_ShouldReturn_NotEmpty()
        {
            var suppliersModels = new List<ISuppliersModel>();
            try
            {
                suppliersModels = suppliersService.GetSuppliersToList();
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(suppliersModels.Count > 0);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            SuppliersModel suppliersModel = new SuppliersModel();
            try
            {
                suppliersService.Update(suppliersModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}