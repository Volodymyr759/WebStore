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
    public class ImaigesPresenterTests
    {
        private ImagesPresenter imaigesPresenter;

        [TestMethod()]
        public void GetImaigesUCTest_ShouldReturnImageUC()
        {
            imaigesPresenter = new ImagesPresenter();
            ImagesUC imageUC = null;

            try
            {
                imageUC = (ImagesUC)imaigesPresenter.GetImaigesUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(imageUC);
        }
    }
}