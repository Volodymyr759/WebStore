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
    public class CategoriesDetailPresenterTests
    {
        private CategoriesDetailPresenter categoriesDetailPresenter;

        public CategoriesDetailPresenterTests()
        {
            categoriesDetailPresenter = new CategoriesDetailPresenter();
        }

        [TestMethod()]
        public void GetCategoriesDetailUC_ShouldReturnCategoriesDetailUC()
        {
            categoriesDetailPresenter = new CategoriesDetailPresenter();
            CategoriesDetailUC categoriesDetailUC = null;

            try
            {
                categoriesDetailUC = (CategoriesDetailUC)categoriesDetailPresenter.GetCategoriesDetailUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(categoriesDetailUC);
        }

        [TestMethod()]
        public void SetupCategoriesDetailForAdd_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                categoriesDetailPresenter.SetupCategoriesDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupCategoriesDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                categoriesDetailPresenter.SetupCategoriesDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }
    }
}