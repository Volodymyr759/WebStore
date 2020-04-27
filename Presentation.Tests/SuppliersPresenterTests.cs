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
    public class SuppliersPresenterTests
    {
        private SuppliersPresenter suppliersPresenter;

        [TestMethod()]
        public void GetSuppliersUCTest_ShouldReturnSuppliersUC()
        {
            suppliersPresenter = new SuppliersPresenter();
            SuppliersUC suppliersUC = null;

            try
            {
                suppliersUC = (SuppliersUC)suppliersPresenter.GetSuppliersUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(suppliersUC);
        }
    }
}