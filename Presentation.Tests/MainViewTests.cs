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
    public class MainViewTests
    {
        bool operationSucceeded;
        MainView mainView;
        MainPresenter mainPresenter;

        public MainViewTests()
        {
            mainView = new MainView();
            UnitsService unitsService = new UnitsService(new UnitsRepository());
            UnitsDetailUC unitsDetailUC = new UnitsDetailUC();
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            UnitsDetailPresenter unitsDetailPresenter = new UnitsDetailPresenter(unitsDetailUC, unitsService, errorMessageView);
            UnitsPresenter unitsPresenter = new UnitsPresenter(new UnitsUC(), unitsService, unitsDetailPresenter, deleteConfirmView, errorMessageView);
            mainPresenter = new MainPresenter(mainView, unitsPresenter, unitsDetailPresenter);
            mainPresenter.TestEventRaised += (sender, e) => SetOperationSuccessToTrue();
        }

        private void SetOperationSuccessToTrue()
        {
            operationSucceeded = true;
        }

        [TestMethod()]
        public void MainViewTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NewfileToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.NewfileToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void OpenToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.OpenToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void ExportcsvToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.ExportcsvToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void ExportxmlToolStripMenuItem1_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.ExportxmlToolStripMenuItem1_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void ExitToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.ExitToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void ProductsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.ProductsToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void CategoriesToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.CategoriesToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void GroupspromuaToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.GroupspromuaToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SuppliersToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.SuppliersToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void ParametersToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.ParametersToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void ImagesToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.ImagesToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void UnitsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.UnitsToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SettingsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.SettingsToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void SearchToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.SearchToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void HelpinfoToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.HelpinfoToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }

        [TestMethod()]
        public void AboutToolStripMenuItem_Click_ShouldReturn_Success()
        {
            operationSucceeded = false;
            try
            {
                mainView.AboutToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception)
            {
            }
            Assert.IsTrue(operationSucceeded);
        }
    }
}