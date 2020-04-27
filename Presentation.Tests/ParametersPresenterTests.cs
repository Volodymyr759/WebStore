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
    public class ParametersPresenterTests
    {
        private ParametersPresenter parametersPresenter;

        [TestMethod()]
        public void GetParametersUCTest_ShouldReturnParametersUC()
        {
            parametersPresenter = new ParametersPresenter();
            ParametersUC parametersUC = null;
            try
            {
                parametersUC = (ParametersUC)parametersPresenter.GetParametersUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(parametersUC);
        }
    }
}