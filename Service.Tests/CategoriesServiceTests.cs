using Domain.Models.Categories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class CategoriesServiceTests
    {
        bool operationSucceeded;
        CategoriesService categoriesService;

        public CategoriesServiceTests()
        {
            categoriesService = new CategoriesService();
        }

        [TestMethod()]
        public void Add_ShouldReturn_Success()
        {
            operationSucceeded = false;
            CategoriesModel categoriesModel = new CategoriesModel();
            try
            {
                categoriesService.Add(categoriesModel);
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
                categoriesService.DeleteById(1);
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
            CategoriesModel categoriesModel = null;
            try
            {
                categoriesModel = (CategoriesModel)categoriesService.GetById(1);
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(categoriesModel);
        }

        [TestMethod()]
        public void GetCategoriesToList_ShouldReturn_NotEmpty()
        {
            var categoriesModels = new List<CategoriesDtoModel>();
            try
            {
                categoriesModels = categoriesService.GetCategoriesToList();
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(categoriesModels.Count > 0);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            CategoriesModel categoriesModel = new CategoriesModel();
            try
            {
                categoriesService.Update(categoriesModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}