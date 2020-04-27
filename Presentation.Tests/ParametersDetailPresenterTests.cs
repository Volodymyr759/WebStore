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
    public class ParametersDetailPresenterTests
    {
        private ParametersDetailPresenter parametersDetailPresenter;

        public ParametersDetailPresenterTests()
        {
            parametersDetailPresenter = new ParametersDetailPresenter();
        }

        [TestMethod()]
        public void GetParametersDetailUC_ShouldReturnParametersDetailUC()
        {
            ParametersDetailUC parametersDetailUC = null;
            try
            {
                parametersDetailUC = (ParametersDetailUC)parametersDetailPresenter.GetParametersDetailUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(parametersDetailUC);
        }

        [TestMethod()]
        public void SetupParametersDetailForAdd_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                parametersDetailPresenter.SetupParametersDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupParametersDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                parametersDetailPresenter.SetupParametersDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(operationSucceeded);
        }
    }
}