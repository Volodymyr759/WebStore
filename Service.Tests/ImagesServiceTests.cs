using Domain.Models.Images;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ImagesServices;
using System;
using System.Collections.Generic;
using Moq;
using Services;

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
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<ICommonRepository>().Object);
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
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<ICommonRepository>().Object);

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
                Mock<ICommonRepository> fakeCommonRepository = new Mock<ICommonRepository>();
                fakeCommonRepository.Setup(a => a.GetProductsIdNames()).Returns(new Dictionary<int, string> { { 1, "Product name" } });

                imagesService = new ImagesService(fakeImagesRepository.Object, fakeCommonRepository.Object);
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
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<ICommonRepository>().Object);
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
                imagesService = new ImagesService(fakeImagesRepository.Object, new Mock<ICommonRepository>().Object);

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