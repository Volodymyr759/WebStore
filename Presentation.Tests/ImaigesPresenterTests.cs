using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class ImagesPresenterTests
    {
        private ImagesPresenter imagesPresenter;
        private string errorMessage;

        public ImagesPresenterTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            ImagesDetailUC imagesDetailUC = new ImagesDetailUC(errorMessageView);
            ImagesDetailPresenter imagesDetailPresenter = new ImagesDetailPresenter(imagesDetailUC, 
                ServicesInitializator.facade);
            imagesPresenter = new ImagesPresenter(new ImagesUC(errorMessageView), imagesDetailPresenter, 
                ServicesInitializator.facade, deleteConfirmView, errorMessageView);
        }

        [TestMethod()]
        public void GetImagesUCTest_ShouldReturnImageUC()
        {
            ImagesUC imageUC = null;
            errorMessage = "";
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

        [TestMethod()]
        public void LoadImagesTest_ShouldReturn_ImagesUC()
        {
            ImagesUC imagesUC = null;
            errorMessage = "";
            try
            {
                imagesUC = (ImagesUC)imagesPresenter.LoadImages(@"C:\Users\Володимир\Desktop\Одеса");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsNotNull(imagesUC, errorMessage);
        }

    }
}