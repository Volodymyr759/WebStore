using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class ImagesDetailPresenterTests
    {
        private ImagesDetailPresenter imagesDetailPresenter;
        private string errorMessage;
        private bool operationSucceeded;

        public ImagesDetailPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            ImagesDetailUC imagesDetailUC = new ImagesDetailUC(errorMessageView);
            imagesDetailPresenter = new ImagesDetailPresenter(imagesDetailUC, ServicesInitialiser.facade);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void GetImagesDetailUC_ShouldReturnImagesDetailUC()
        {
            ImagesDetailUC imagesDetailUC = null;
            try
            {
                imagesDetailUC = (ImagesDetailUC)imagesDetailPresenter.GetImagesDetailUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(imagesDetailUC, errorMessage);
        }

        [TestMethod]
        public void SetupImagesDetailForAdd_ShouldReturn_Success()
        {
            try
            {
                imagesDetailPresenter.SetupImagesDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SetupImagesDetailForEdit_ShouldReturn_Success()
        {
            try
            {
                imagesDetailPresenter.SetupImagesDetailForEdit(1);
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