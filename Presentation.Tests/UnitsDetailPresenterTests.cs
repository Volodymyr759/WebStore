using DataAccess.RepositoriesSqlCE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation;
using Presentation.Views.UserControls;
using Services.UnitsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Tests
{
    [TestClass()]
    public class UnitsDetailPresenterTests
    {
        private UnitsDetailPresenter unitsDetailPresenter;

        public UnitsDetailPresenterTests()
        {
            unitsDetailPresenter = new UnitsDetailPresenter(
                new UnitsDetailUC(), 
                new UnitsService(new UnitsRepository()), 
                new ErrorMessageView());
        }

        [TestMethod()]
        public void GetUnitsDetailUC_ShouldReturnUnitsDetailUC()
        {
            UnitsDetailUC unitsDetailUC = null;
            try
            {
                unitsDetailUC = (UnitsDetailUC)unitsDetailPresenter.GetUnitsDetailUC();
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(unitsDetailUC);
        }

        [TestMethod()]
        public void SetupUnitsDetailForAdd_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                unitsDetailPresenter.SetupUnitsDetailForAdd();
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SetupUnitsDetailForEdit_ShouldReturn_Success()
        {
            bool operationSucceeded = false;
            try
            {
                unitsDetailPresenter.SetupUnitsDetailForEdit(1);
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}