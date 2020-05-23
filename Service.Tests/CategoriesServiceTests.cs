using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesServices;
using Services.SuppliersServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass()]
    public class CategoriesServiceTests
    {
        bool operationSucceeded;
        CategoriesService categoriesService;
        string errorMessage;
        const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        public CategoriesServiceTests()
        {
            categoriesService = new CategoriesService(new CategoriesRepository(connString), 
                new SuppliersService(new SuppliersRepository(connString)));
        }

        [TestMethod()]
        public void AddCategory_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            CategoriesDtoModel categoriesDto = new CategoriesDtoModel()
            {
                Name = "New category",
                SupplierId = 2,
                SupplierName = "Supplier",
                Link = "some categories link",
                Rate = 1.5m,
                Notes = "some notes for new category"
            };
            try
            {
                categoriesService.AddCategory(categoriesDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteCategoryById_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            try
            {
                categoriesService.DeleteCategoryById(11111);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetCategoryById_ShouldReturn_NotNull()
        {
            CategoriesDtoModel categoriesDto = null;
            errorMessage = "";
            try
            {
                categoriesDto = categoriesService.GetCategoryById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(categoriesDto, errorMessage);
        }

        [TestMethod()]
        public void GetCategories_ShouldReturn_ListCategoriesDtoModel()
        {
            errorMessage = "";
            List<CategoriesDtoModel> categoriesDtos = new List<CategoriesDtoModel>();
            try
            {
                categoriesDtos = (List<CategoriesDtoModel>)categoriesService.GetCategories();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(categoriesDtos.Count>0, errorMessage);
        }

        [TestMethod()]
        public void UpdateCategory_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            CategoriesDtoModel categoriesDto = new CategoriesDtoModel()
            {
                Id = 1,
                Name = "Updated category",
                SupplierId = 2,
                Link = "some categories link",
                Rate = 1.5m,
                Notes = "some notes for new category"
            };
            try
            {
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