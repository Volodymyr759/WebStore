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
    public class CategoriesPresenterTests
    {
        private CategoriesPresenter categoriesPresenter;

        [TestMethod()]
        public void GetCategoriesUCTest_ShouldReturnCategoriesUC()
        {
            categoriesPresenter = new CategoriesPresenter();
            CategoriesUC categoriesUC = null;
            try
            {
                categoriesUC = (CategoriesUC)categoriesPresenter.GetCategoriesUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(categoriesUC);
        }
    }
}