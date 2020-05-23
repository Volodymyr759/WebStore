using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass()]
    public class ProductsServiceTests
    {
        bool operationSucceeded;
        ProductsService productsService;
        string errorMessage;
        const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        public ProductsServiceTests()
        {
            SuppliersService suppliersService = new SuppliersService(new SuppliersRepository(connString));
            productsService = new ProductsService(new ProductsRepository(connString),
                                    new CategoriesService(new CategoriesRepository(connString), suppliersService),
                                    new GroupsService(new GroupsRepository(connString)),
                                    suppliersService,
                                    new UnitsService(new UnitsRepository(connString)));
        }

        [TestMethod()]
        public void AddProduct_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            ProductsDtoModel productDto = new ProductsDtoModel()
            {
                SupplierId = 1,
                CategoryId = 1,
                GroupId = 1,
                NameWebStore = "product1",
                NameSupplier = "Product1",
                CodeWebStore = "111",
                CodeSupplier = "112",
                UnitId = 1,
                PriceWebStore = 1.5m,
                PriceSupplier = 1,
                Available = "+",
                LinkWebStore = "link1",
                LinkSupplier = "link2",
                Notes = "some notes"
            };
            try
            {
                productsService.AddProduct(productDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteProductById_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            try
            {
                productsService.DeleteProductById(11111);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetProductById_ShouldReturn_NotNull()
        {
            ProductsDtoModel productsModel = null;
            errorMessage = "";
            try
            {
                productsModel = productsService.GetProductById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsModel);
        }

        [TestMethod()]
        public void GetProducts_ShouldReturn_ListProductsDtoModel()
        {
            errorMessage = "";
            IEnumerable<ProductsDtoModel> productsDtos = productsService.GetProducts();
            try
            {
                productsDtos = (List<ProductsDtoModel>)productsService.GetProducts();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsDtos, errorMessage);
        }

        [TestMethod()]
        public void UpdateProduct_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            ProductsDtoModel productDto = new ProductsDtoModel()
            {
                Id = 1,
                SupplierId = 1,
                CategoryId = 1,
                GroupId = 1,
                NameWebStore = "Updated product1",
                NameSupplier = "Product1",
                CodeWebStore = "111",
                CodeSupplier = "112",
                UnitId = 1,
                PriceWebStore = 1.5m,
                PriceSupplier = 1,
                Available = "+",
                LinkWebStore = "link1",
                LinkSupplier = "link2",
                Notes = "some notes"

            };
            try
            {
                productsService.UpdateProduct(productDto);
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