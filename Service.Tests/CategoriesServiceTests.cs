using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesServices;
using Moq;
using System;
using System.Collections.Generic;
using Domain.Models.Categories;
using Services.SuppliersServices;
using Domain.Models.Suppliers;

namespace Service.Tests
{
    [TestClass]
    public class CategoriesServiceTests
    {
        string errorMessage;
        bool operationSucceeded;
        CategoriesService categoriesService;
        Mock<ICategoriesRepository> fakeCategoriesRepository = new Mock<ICategoriesRepository>();

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void AddCategory_ShouldReturn_Success()
        {
            try
            {
                CategoriesModel category = new CategoriesModel
                {
                    Name = "New category",
                    SupplierId = 2,
                    Link = "link",
                    Rate = 1.5m,
                    Notes = "notes"
                };
                fakeCategoriesRepository.Setup(a => a.Add(category));
                categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                    new Mock<ISuppliersService>().Object);

                CategoriesDtoModel categoriesDto = new CategoriesDtoModel
                {
                    Name = category.Name,
                    SupplierId = category.SupplierId,
                    SupplierName = "Supplier",
                    Link = category.Link,
                    Rate = 1.5m,
                    Notes = category.Notes
                };

                categoriesService.AddCategory(categoriesDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteCategoryById_ShouldReturn_Success()
        {
            try
            {
                fakeCategoriesRepository.Setup(a => a.DeleteById(1));
                categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                    new Mock<ISuppliersService>().Object);

                categoriesService.DeleteCategoryById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetCategoryById_ShouldReturn_NotNull()
        {
            CategoriesDtoModel categoriesDto = null;
            try
            {
                fakeCategoriesRepository.Setup(a => a.GetById(1)).Returns(new CategoriesModel { SupplierId = 2 });
                Mock<ISuppliersService> fakeSuppliersService = new Mock<ISuppliersService>();
                fakeSuppliersService.Setup(a => a.GetSupplierById(2)).Returns(new SuppliersDtoModel { Id = 2, Name = "Supplier" });

                categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                    fakeSuppliersService.Object);

                categoriesDto = categoriesService.GetCategoryById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(categoriesDto, errorMessage);
        }

        [TestMethod]
        public void GetCategories_ShouldReturn_NotNull()
        {
            List<CategoriesDtoModel> categoriesDtos = new List<CategoriesDtoModel>();
            try
            {
                fakeCategoriesRepository.Setup(a => a.GetAll()).Returns(new List<CategoriesModel> { new CategoriesModel() });
                categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                    new Mock<ISuppliersService>().Object);
                categoriesDtos = (List<CategoriesDtoModel>)categoriesService.GetCategories();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(categoriesDtos, errorMessage);
        }

        [TestMethod]
        public void UpdateCategory_ShouldReturn_Success()
        {
            try
            {
                CategoriesModel category = new CategoriesModel
                {
                    Name = "name to update",
                    SupplierId = 2,
                    Link = "link to update",
                    Rate = 1.5m,
                    Notes = "notes to update"
                };
                fakeCategoriesRepository.Setup(a => a.Update(category));
                categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                    new Mock<ISuppliersService>().Object);

                CategoriesDtoModel categoriesDto = new CategoriesDtoModel
                {
                    Name = category.Name,
                    SupplierId = 2,
                    SupplierName = "Supplier",
                    Link = category.Link,
                    Rate = 2m,
                    Notes = category.Notes
                };

                categoriesService.UpdateCategory(categoriesDto);
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