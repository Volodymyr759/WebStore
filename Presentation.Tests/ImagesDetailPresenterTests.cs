using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Tests
{
    [TestClass()]
    public class ImagesDetailPresenterTests
    {
        private ImagesDetailPresenter imagesDetailPresenter;

        public ImagesDetailPresenterTests()
        {
            imagesDetailPresenter = new ImagesDetailPresenter();
        }

        [TestMethod()]
        public void GetImagesDetailUC_ShouldReturnImagesDetailUC()
        {
            ImagesDetailUC imagesDetailUC = null;
            try
            {
                imagesDetailUC = (ImagesDetailUC)imagesDetailPresenter.GetImagesDetailUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(imagesDetailUC);
        }

        [TestMethod()]
        public void SetupImagesDetailForAdd_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                imagesDetailPresenter.SetupImagesDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupImagesDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                imagesDetailPresenter.SetupImagesDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }
    }
}