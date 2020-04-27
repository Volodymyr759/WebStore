using Domain.Models.Images;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ImagesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class ImagesServiceTests
    {
        bool operationSucceeded;
        ImagesService imagesService;

        public ImagesServiceTests()
        {
            imagesService = new ImagesService();
        }

        [TestMethod()]
        public void Add_ShouldReturn_Success()
        {
            operationSucceeded = false;
            ImagesModel imagesModel = new ImagesModel();
            try
            {
                imagesService.Add(imagesModel);
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
                imagesService.DeleteById(1);
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
            ImagesModel imagesModel = null;
            try
            {
                imagesModel = (ImagesModel)imagesService.GetById(1);
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(imagesModel);
        }

        [TestMethod()]
        public void GetImagesToList_ShouldReturn_NotEmpty()
        {
            var imagesModels = new List<ImagesDtoModel>();
            try
            {
                imagesModels = imagesService.GetImagesToList();
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(imagesModels.Count > 0);
        }

        [TestMethod()]
        public void Update_ShouldReturn_Success()
        {
            operationSucceeded = false;
            ImagesModel imagesModel = new ImagesModel();
            try
            {
                imagesService.Update(imagesModel);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}