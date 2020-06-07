using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesServices;
using Moq;
using System;
using System.Collections.Generic;
using Domain.Models.Categories;
using Services;

namespace Service.Tests
{
    [TestClass]
    public class CategoriesServiceTests
    {
        private string errorMessage;
        private bool operationSucceeded;
        private CategoriesService categoriesService;
        private Mock<ICategoriesRepository> fakeCategoriesRepository;

        [TestInitialize]
        public void TestInit()
        {
            fakeCategoriesRepository = new Mock<ICategoriesRepository>();
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fakeCategoriesRepository = null;
        }

        [TestMethod]
        public void AddCategory_ShouldReturn_Success()
        {
            // Arrange
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
                new Mock<ICommonRepository>().Object);
            CategoriesDtoModel categoriesDto = new CategoriesDtoModel
            {
                Name = category.Name,
                SupplierId = category.SupplierId,
                SupplierName = "Supplier",
                Link = category.Link,
                Rate = 1.5m,
                Notes = category.Notes
            };

            try
            {
                // Act
                categoriesService.AddCategory(categoriesDto);
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
        public void DeleteCategoryById_ShouldReturn_Success()
        {
            // Arrange
            fakeCategoriesRepository.Setup(a => a.DeleteById(1));
            categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                new Mock<ICommonRepository>().Object);

            try
            {
                // Act
                categoriesService.DeleteCategoryById(1);
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
        public void GetCategoryById_ShouldReturn_NotNull()
        {
            // Arrange
            fakeCategoriesRepository.Setup(a => a.GetById(2)).Returns(new CategoriesModel { Id = 2, SupplierId = 4, Name = "Category name", Link = "Categories link", Rate = 1, Notes = "notes" });
            Mock<ICommonRepository> fakeCommonRepository = new Mock<ICommonRepository>();
            fakeCommonRepository.Setup(a => a.GetSuppliersIdNames()).Returns(new Dictionary<int, string> { { 4, "Supplier" } });
            categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                fakeCommonRepository.Object);

            CategoriesDtoModel categoriesDto = null;
            try
            {
                // Act
                categoriesDto = categoriesService.GetCategoryById(2);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsNotNull(categoriesDto, errorMessage);
        }

        [TestMethod]
        public void GetCategories_ShouldReturn_NotNull()
        {
            // Arrange
            fakeCategoriesRepository.Setup(a => a.GetAll()).Returns(new List<CategoriesModel> { new CategoriesModel { Id = 2, SupplierId = 4, Name = "Category name", Link = "Categories link", Rate = 1, Notes = "notes" } });
            Mock<ICommonRepository> fakeCommonRepository = new Mock<ICommonRepository>();
            fakeCommonRepository.Setup(a => a.GetSuppliersIdNames()).Returns(new Dictionary<int, string> { { 4, "Supplier" } });
            categoriesService = new CategoriesService(fakeCategoriesRepository.Object,
                fakeCommonRepository.Object);
            List<CategoriesDtoModel> categoriesDtos = null;

            try
            {
                // Act
                categoriesDtos = (List<CategoriesDtoModel>)categoriesService.GetCategories();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }

            // Assert
            Assert.IsNotNull(categoriesDtos, errorMessage);
        }

        [TestMethod]
        public void UpdateCategory_ShouldReturn_Success()
        {
            // Arrange
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
                new Mock<ICommonRepository>().Object);
            CategoriesDtoModel categoriesDto = new CategoriesDtoModel
            {
                Name = category.Name,
                SupplierId = 2,
                SupplierName = "Supplier",
                Link = category.Link,
                Rate = 2m,
                Notes = category.Notes
            };

            try
            {
                // Act
                categoriesService.UpdateCategory(categoriesDto);
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