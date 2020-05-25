using Domain.Models.Images;
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
using Moq;
using Domain.Models.Products;

namespace Service.Tests
{
    [TestClass]
    public class ImagesServiceTests
    {
        string errorMessage;
        bool operationSucceeded;
        ImagesService imagesService;
        Mock<IImagesRepository> fakeImagesRepository = new Mock<IImagesRepository>();

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void AddImage_ShouldReturn_Success()
        {
            try
            {
                ImagesModel image = new ImagesModel()
                {
                    FileName = "somefile.png",
                    ProductId = 1,
                    LinkWebStore = "some weblink",
                    LinkSupplier = "some suppliers link",
                    LocalPath = "some local path"
                };
                fakeImagesRepository.Setup(a => a.Add(image));
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<IProductsService>().Object);
                ImagesDtoModel imageDto = new ImagesDtoModel
                {
                    FileName = image.FileName,
                    ProductId = image.ProductId,
                    ProductName = "Product name",
                    LinkWebStore = image.LinkWebStore,
                    LinkSupplier = image.LinkSupplier,
                    LocalPath = image.LocalPath
                };
                imagesService.AddImage(imageDto);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void DeleteImageById_ShouldReturn_Success()
        {
            try
            {
                fakeImagesRepository.Setup(a => a.DeleteById(1));
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<IProductsService>().Object);

                imagesService.DeleteImageById(1);
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GetImageById_ShouldReturn_NotNull()
        {
            ImagesDtoModel imagesDto = null;
            try
            {
                fakeImagesRepository.Setup(a => a.GetById(2)).Returns(new ImagesModel { ProductId = 1 });
                Mock<IProductsService> fakeProductsService = new Mock<IProductsService>();
                fakeProductsService.Setup(a => a.GetProductById(1)).Returns(new ProductsDtoModel { Id = 1, NameWebStore = "Product name" });

                imagesService = new ImagesService(fakeImagesRepository.Object, fakeProductsService.Object);
                imagesDto = imagesService.GetImageById(2);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(imagesDto, errorMessage);
        }

        [TestMethod]
        public void GetImages_ShouldReturn_NotNull()
        {
            List<ImagesDtoModel> imagesDtos = new List<ImagesDtoModel>();
            try
            {
                fakeImagesRepository.Setup(a => a.GetAll()).Returns(new List<ImagesModel>());
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<IProductsService>().Object);
                imagesDtos = (List<ImagesDtoModel>)imagesService.GetImages();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(imagesDtos, errorMessage);
        }

        [TestMethod]
        public void UpdateImage_ShouldReturn_Success()
        {
            try
            {
                ImagesModel image = new ImagesModel
                {
                    FileName = "somefile.png",
                    ProductId = 1,
                    LinkWebStore = "some weblink",
                    LinkSupplier = "some suppliers link",
                    LocalPath = "some local path"
                };
                fakeImagesRepository.Setup(a => a.Update(image));
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<IProductsService>().Object);

                ImagesDtoModel imageDto = new ImagesDtoModel
                {
                    FileName = image.FileName,
                    ProductId = image.ProductId,
                    ProductName = "Product name",
                    LinkWebStore = image.LinkWebStore,
                    LinkSupplier = image.LinkSupplier,
                    LocalPath = image.LocalPath
                };

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