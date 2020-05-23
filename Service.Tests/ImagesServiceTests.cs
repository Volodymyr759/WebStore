using Infrastructure.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ImagesServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using System;
using System.Collections.Generic;

namespace Service.Tests
{
    [TestClass()]
    public class ImagesServiceTests
    {
        bool operationSucceeded;
        ImagesService imagesService;
        string errorMessage;
        const string connString = @"Data Source=C:\Users\Володимир\source\repos\WebStore\Presentation\bin\Debug\webstore.sdf";

        public ImagesServiceTests()
        {
            SuppliersService suppliersService = new SuppliersService(new SuppliersRepository(connString));
            imagesService = new ImagesService(new ImagesRepository(connString),
                new ProductsService(new ProductsRepository(connString),
                                    new CategoriesService(new CategoriesRepository(connString), suppliersService),
                                    new GroupsService(new GroupsRepository(connString)),
                                    suppliersService,
                                    new UnitsService(new UnitsRepository(connString))));
        }

        [TestMethod()]
        public void AddImage_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            ImagesDtoModel imageDto = new ImagesDtoModel()
            {
                FileName = "somefile.png",
                ProductId = 1,
                ProductName = "Product name",
                LinkWebStore = "some weblink",
                LinkSupplier = "some suppliers link",
                LocalPath = "some local path"
            };
            try
            {
                imagesService.AddImage(imageDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void DeleteImageById_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                imagesService.DeleteImageById(11111);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void GetImageById_ShouldReturn_NotNull()
        {
            ImagesDtoModel imagesDto = null;
            errorMessage = "";
            try
            {
                imagesDto = imagesService.GetImageById(1);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(imagesDto, errorMessage);
        }

        [TestMethod()]
        public void GetImages_ShouldReturn_ListImagesDtoModel()
        {
            errorMessage = "";
            List<ImagesDtoModel> imagesDtos = new List<ImagesDtoModel>();
            try
            {
                imagesDtos = (List<ImagesDtoModel>)imagesService.GetImages();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(imagesDtos.Count>0, errorMessage);
        }

        [TestMethod()]
        public void UpdateImage_ShouldReturn_Success()
        {
            operationSucceeded = false;
            errorMessage = "";
            ImagesDtoModel imageDto = new ImagesDtoModel()
            {
                Id = 1,
                
                FileName = "updated somefile.png",
                ProductId = 1,
                ProductName = "Product name",
                LinkWebStore = "some weblink",
                LinkSupplier = "some suppliers link",
                LocalPath = "some local path"
            };
            try
            {
                imagesService.UpdateImage(imageDto);
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