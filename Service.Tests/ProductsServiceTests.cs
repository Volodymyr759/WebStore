using Domain.Models.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ProductsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class ProductsServiceTests
    {
        bool operationSucceeded;
        ProductsService productsService;

        public ProductsServiceTests()
        {
            productsService = new ProductsService();
        }

        [TestMethod()]
        public void Add_ShouldReturn_Success()
        {
            operationSucceeded = false;
            ProductsModel productsModel = new ProductsModel();
            try
            {
                productsService.Add(productsModel);
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
                productsService.DeleteById(1);
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
            ProductsModel productsModel = null;
            try
            {
                productsModel = (ProductsModel)productsService.GetById(1);
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(productsModel);
        }

        [TestMethod()]
        public void GetProductsToList_ShouldReturn_NotEmpty()
        {
            var productsModels = new List<ProductsDtoModel>();
            try
            {
                productsModels = productsService.GetProductsToList();
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(productsModels.Count > 0);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            ProductsModel productsModel = new ProductsModel();
            try
            {
                productsService.Update(productsModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}