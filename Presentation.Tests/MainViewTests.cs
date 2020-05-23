using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ImagesServices;
using Services.ParametersServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using System;

namespace Presentation.Tests
{
    [TestClass()]
    public class MainViewTests
    {
        bool operationSucceeded;
        MainView mainView;
        MainPresenter mainPresenter;
        string errorMessage;

        public MainViewTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            mainView = new MainView(errorMessageView);

            SettingsPresenter settingsPresenter = new SettingsPresenter(new SettingsUC(errorMessageView), errorMessageView);
            StoreFacade facade = ServicesInitializator.facade;

            UnitsService unitsService = ServicesInitializator.unitsService;
            UnitsDetailUC unitsDetailUC = new UnitsDetailUC(errorMessageView);
            UnitsDetailPresenter unitsDetailPresenter = new UnitsDetailPresenter(unitsDetailUC, facade);
            UnitsPresenter unitsPresenter = new UnitsPresenter(new UnitsUC(errorMessageView), facade, unitsDetailPresenter, deleteConfirmView, errorMessageView);

            SuppliersService supplierService = ServicesInitializator.suppliersService;
            SuppliersDetailUC suppliersDetailUC = new SuppliersDetailUC(errorMessageView);
            SuppliersDetailPresenter suppliersDetailPresenter = new SuppliersDetailPresenter(suppliersDetailUC, facade);
            SuppliersPresenter suppliersPresenter = new SuppliersPresenter(new SuppliersUC(errorMessageView), suppliersDetailPresenter, facade, deleteConfirmView, errorMessageView);

            ProductsService productsService = ServicesInitializator.productsService;
            ProductsDetailUC productsDetailUC = new ProductsDetailUC(errorMessageView);
            ProductsDetailPresenter productsDetailPresenter = new ProductsDetailPresenter(productsDetailUC, facade);
            ProductsPresenter productsPresenter = new ProductsPresenter(new ProductsUC(errorMessageView), productsDetailPresenter,
                facade, deleteConfirmView, errorMessageView);

            ParametersService parametersService = ServicesInitializator.parametersService;
            ParametersDetailUC parametersDetailUC = new ParametersDetailUC(errorMessageView);
            ParametersDetailPresenter parametersDetailPresenter = new ParametersDetailPresenter(parametersDetailUC, facade);
            ParametersPresenter parametersPresenter = new ParametersPresenter(new ParametersUC(errorMessageView), 
                parametersDetailPresenter, facade, deleteConfirmView, errorMessageView);

            ImagesService imagesService = ServicesInitializator.imagesService;
            ImagesDetailUC imagesDetailUC = new ImagesDetailUC(errorMessageView);
            ImagesDetailPresenter imagesDetailPresenter = new ImagesDetailPresenter(imagesDetailUC, facade);
            ImagesPresenter imagesPresenter = new ImagesPresenter(new ImagesUC(errorMessageView), imagesDetailPresenter, ServicesInitializator.facade, deleteConfirmView, errorMessageView);

            GroupsService groupsService = ServicesInitializator.groupsService;
            GroupsDetailUC groupsDetailUC = new GroupsDetailUC(errorMessageView);
            GroupsDetailPresenter groupsDetailPresenter = new GroupsDetailPresenter(groupsDetailUC, ServicesInitializator.facade);
            GroupsPresenter groupsPresenter = new GroupsPresenter(new GroupsUC(errorMessageView), groupsDetailPresenter, ServicesInitializator.facade, deleteConfirmView, errorMessageView);

            CategoriesService categoriesService = ServicesInitializator.categoriesService;
            CategoriesDetailUC categoriesDetailUC = new CategoriesDetailUC(errorMessageView);
            CategoriesDetailPresenter categoriesDetailPresenter = new CategoriesDetailPresenter(categoriesDetailUC, facade);
            CategoriesPresenter categoriesPresenter = new CategoriesPresenter(new CategoriesUC(errorMessageView), categoriesDetailPresenter, facade, deleteConfirmView, errorMessageView);


            mainPresenter = new MainPresenter(mainView,
                settingsPresenter,
                unitsPresenter, unitsDetailPresenter,
                suppliersPresenter, suppliersDetailPresenter,
                productsPresenter, productsDetailPresenter,
                parametersPresenter, parametersDetailPresenter,
                imagesPresenter, imagesDetailPresenter,
                groupsPresenter, groupsDetailPresenter,
                categoriesPresenter, categoriesDetailPresenter,
                facade, deleteConfirmView);
            mainPresenter.TestEventRaised += (sender, e) => SetOperationSuccessToTrue();
        }

        private void SetOperationSuccessToTrue()
        {
            operationSucceeded = true;
        }

        [TestMethod()]
        public void NewfileToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.NewfileToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void OpenToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.OpenToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void ExportcsvToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.ExportcsvToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void ExportxmlToolStripMenuItem1_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.ExportxmlToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
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
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.SettingsToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void FindNewProductsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.FindNewProductsToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void FindOldProductsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.FindOldProductsToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void CheckAvailabilityToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.CheckAvailabilityToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void CheckPricesToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.CheckPricesToolStripMenuItem_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void HelpinfoToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.HelpinfoToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod()]
        public void AboutToolStripMenuItem_Click_ShouldReturn_Success()
        {
            errorMessage = "";
            operationSucceeded = false;
            try
            {
                mainView.AboutToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }
    }
}