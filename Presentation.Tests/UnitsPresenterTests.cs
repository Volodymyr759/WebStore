using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation;
using Presentation.Views.UserControls;
using Services.UnitsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using DataAccess.RepositoriesSqlCE;

namespace Presentation.Tests
{
    [TestClass()]
    public class UnitsPresenterTests
    {
        private UnitsPresenter unitsPresenter;
        private UnitsService unitsService;

        public UnitsPresenterTests()
        {
            unitsService = new UnitsService(new UnitsRepository());
            unitsPresenter = new UnitsPresenter(
                new UnitsUC(),
                unitsService, 
                new UnitsDetailPresenter(new UnitsDetailUC(), unitsService, new ErrorMessageView()), 
                new DeleteConfirmView(), new ErrorMessageView());
        }

        [TestMethod()]
        public void UnitsPresenterTest_ShouldReturnUnitsUC()
        {
            
            UnitsUC unitsUC = null;

            try
            {
                unitsUC = (UnitsUC)unitsPresenter.GetUnitsUC();
            }
            catch (Exception)
            {
            }

            Assert.IsNotNull(unitsUC);
        }
    }
}