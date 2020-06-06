using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass]
    public class ImagesPresenterTests
    {
        private ImagesPresenter imagesPresenter;
        private string errorMessage;
        private ImagesUC imageUC;

        public ImagesPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            ImagesDetailUC imagesDetailUC = new ImagesDetailUC(errorMessageView);
            ImagesDetailPresenter imagesDetailPresenter = new ImagesDetailPresenter(imagesDetailUC,
                ServicesInitialiser.facade);
            imagesPresenter = new ImagesPresenter(new ImagesUC(errorMessageView), imagesDetailPresenter,
                ServicesInitialiser.facade, deleteConfirmView, errorMessageView);
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            imageUC = null;
        }

        [TestMethod]
        public void GetImagesUCTest_ShouldReturn_ImageUC()
        {
            try
            {
                imageUC = (ImagesUC)imagesPresenter.GetImagesUC();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(imageUC, errorMessage);
        }

        [TestMethod]
        public void LoadImagesTest_ShouldReturn_ImagesUC()
        {
            try
            {
                imageUC = (ImagesUC)imagesPresenter.LoadImages(new string[] { @"D:\" });
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(imageUC, errorMessage);
        }

    }
}