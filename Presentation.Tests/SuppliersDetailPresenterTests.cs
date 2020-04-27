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
    public class SuppliersDetailPresenterTests
    {
        private SuppliersDetailPresenter suppliersDetailPresenter;

        public SuppliersDetailPresenterTests()
        {
            suppliersDetailPresenter = new SuppliersDetailPresenter();
        }

        [TestMethod()]
        public void GetSuppliersDetailUC_ShouldReturnSuppliersDetailUC()
        {
            SuppliersDetailUC suppliersDetailUC = null;

            try
            {
                suppliersDetailUC = (SuppliersDetailUC)suppliersDetailPresenter.GetSuppliersDetailUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(suppliersDetailUC);
        }

        [TestMethod()]
        public void SetupSuppliersDetailForAdd_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                suppliersDetailPresenter.SetupSuppliersDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupSuppliersDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                suppliersDetailPresenter.SetupSuppliersDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }
    }
}