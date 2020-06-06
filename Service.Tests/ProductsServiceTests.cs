using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ProductsServices;
using System;
using System.Collections.Generic;
using Moq;
using Domain.Models.Products;
using Services;

namespace Service.Tests
{
    [TestClass]
    public class ProductsServiceTests
    {
        string errorMessage;
        bool operationSucceeded;
        ProductsService productsService;
        Mock<IProductsRepository> fakeProductsRepository = new Mock<IProductsRepository>();

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void AddProduct_ShouldReturn_Success()
        {
            try
            {
                ProductsModel product = new ProductsModel()
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
                fakeProductsRepository.Setup(a => a.Add(product));
                productsService = new ProductsService(fakeProductsRepository.Object,
                    new Mock<ICommonRepository>().Object);

                ProductsDtoModel productDto = new ProductsDtoModel()
                {
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    GroupId = product.GroupId,
                    NameWebStore = product.NameWebStore,
                    NameSupplier = product.NameSupplier,
                    CodeWebStore = product.CodeWebStore,
                    CodeSupplier = product.CodeSupplier,
                    UnitId = product.UnitId,
                    PriceWebStore = product.PriceWebStore,
                    PriceSupplier = product.PriceSupplier,
                    Available = product.Available,
                    LinkWebStore = product.LinkWebStore,
                    LinkSupplier = product.LinkSupplier,
                    Notes = product.Notes
                };

                productsService.AddProduct(productDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteProductById_ShouldReturn_Success()
        {
            try
            {
                fakeProductsRepository.Setup(a => a.DeleteById(1));
                productsService = new ProductsService(fakeProductsRepository.Object, new Mock<ICommonRepository>().Object);

                productsService.DeleteProductById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetProductById_ShouldReturn_NotNull()
        {
            ProductsDtoModel productsModel = null;
            try
            {
                fakeProductsRepository.Setup(a => a.GetById(1)).Returns(new ProductsModel
                {
                    Id = 1,
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
                });
                Mock<ICommonRepository> fakeCommonRepository = new Mock<ICommonRepository>();
                fakeCommonRepository.Setup(a => a.GetCategoriesIdNames()).Returns(new Dictionary<int, string> { { 1, "Category" } });
                fakeCommonRepository.Setup(a => a.GetGroupsIdNames()).Returns(new Dictionary<int, string> { { 1, "Group" } });
                fakeCommonRepository.Setup(a => a.GetSuppliersIdNames()).Returns(new Dictionary<int, string> { { 1, "Supplier" } });
                fakeCommonRepository.Setup(a => a.GetUnitsIdNames()).Returns(new Dictionary<int, string> { { 1, "p." } });

                productsService = new ProductsService(fakeProductsRepository.Object, fakeCommonRepository.Object);

                productsModel = productsService.GetProductById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsModel);
        }

        [TestMethod]
        public void GetProducts_ShouldReturn_NotNull()
        {
            List<ProductsDtoModel> productsDtos = new List<ProductsDtoModel>();
            try
            {
                fakeProductsRepository.Setup(a => a.GetAll());
                productsService = new ProductsService(fakeProductsRepository.Object, new Mock<ICommonRepository>().Object);

                productsDtos = (List<ProductsDtoModel>)productsService.GetProducts();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(productsDtos, errorMessage);
        }

        [TestMethod]
        public void UpdateProduct_ShouldReturn_Success()
        {
            try
            {
                ProductsModel product = new ProductsModel()
                {
                    SupplierId = 1,
                    CategoryId = 1,
                    GroupId = 1,
                    NameWebStore = "New name",
                    NameSupplier = "Product1",
                    CodeWebStore = "new code",
                    CodeSupplier = "112",
                    UnitId = 1,
                    PriceWebStore = 1.5m,
                    PriceSupplier = 1,
                    Available = "+",
                    LinkWebStore = "new link",
                    LinkSupplier = "link2",
                    Notes = "new notes"
                };
                fakeProductsRepository.Setup(a => a.Update(product));
                productsService = new ProductsService(fakeProductsRepository.Object, new Mock<ICommonRepository>().Object);

                ProductsDtoModel productDto = new ProductsDtoModel()
                {
                    SupplierId = product.SupplierId,
                    CategoryId = product.CategoryId,
                    GroupId = product.GroupId,
                    NameWebStore = product.NameWebStore,
                    NameSupplier = product.NameSupplier,
                    CodeWebStore = product.CodeWebStore,
                    CodeSupplier = product.CodeSupplier,
                    UnitId = product.UnitId,
                    PriceWebStore = product.PriceWebStore,
                    PriceSupplier = product.PriceSupplier,
                    Available = product.Available,
                    LinkWebStore = product.LinkWebStore,
                    LinkSupplier = product.LinkSupplier,
                    Notes = product.Notes
                };

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