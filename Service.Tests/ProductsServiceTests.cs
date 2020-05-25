using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using System;
using System.Collections.Generic;
using Moq;
using Domain.Models.Products;

namespace Service.Tests
{
    [TestClass]
    public class ProductsServiceTests
    {
        string errorMessage;
        bool operationSucceeded;
        ProductsService productsService;
        Mock<IProductsRepository> fakeProductsRepository = new Mock<IProductsRepository>();
        //const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        //public ProductsServiceTests()
        //{
        //    SuppliersService suppliersService = new SuppliersService(new SuppliersRepository(connString));
        //    productsService = new ProductsService(new ProductsRepository(connString),
        //                            new CategoriesService(new CategoriesRepository(connString), suppliersService),
        //                            new GroupsService(new GroupsRepository(connString)),
        //                            suppliersService,
        //                            new UnitsService(new UnitsRepository(connString)));
        //}
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
                    new Mock<ICategoriesService>().Object, new Mock<IGroupsService>().Object,
                    new Mock<ISuppliersService>().Object, new Mock<IUnitsService>().Object);

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
                productsService = new ProductsService(fakeProductsRepository.Object,
                    new Mock<ICategoriesService>().Object, new Mock<IGroupsService>().Object,
                    new Mock<ISuppliersService>().Object, new Mock<IUnitsService>().Object);

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
                Mock<ICategoriesService> fakeCategoriesService = new Mock<ICategoriesService>();
                fakeCategoriesService.Setup(a => a.GetCategoryById(1)).Returns(new CategoriesDtoModel { Id = 1, Name = "Category" });
                Mock<IGroupsService> fakeGroupsService = new Mock<IGroupsService>();
                fakeGroupsService.Setup(a => a.GetGroupById(1)).Returns(new GroupsDtoModel { Id = 1, Name = "Group" });
                Mock<ISuppliersService> fakeSuppliersService = new Mock<ISuppliersService>();
                fakeSuppliersService.Setup(a => a.GetSupplierById(1)).Returns(new SuppliersDtoModel { Id = 1, Name = "Supplier" });
                Mock<IUnitsService> fakeUnitsService = new Mock<IUnitsService>();
                fakeUnitsService.Setup(a => a.GetUnitById(1)).Returns(new UnitsDtoModel { Id = 1, Name = "p." });

                productsService = new ProductsService(fakeProductsRepository.Object,
                    fakeCategoriesService.Object, fakeGroupsService.Object,
                    fakeSuppliersService.Object, fakeUnitsService.Object);

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
                productsService = new ProductsService(fakeProductsRepository.Object,
                    new Mock<ICategoriesService>().Object, new Mock<IGroupsService>().Object,
                    new Mock<ISuppliersService>().Object, new Mock<IUnitsService>().Object);

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
                productsService = new ProductsService(fakeProductsRepository.Object,
                    new Mock<ICategoriesService>().Object, new Mock<IGroupsService>().Object,
                    new Mock<ISuppliersService>().Object, new Mock<IUnitsService>().Object);

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