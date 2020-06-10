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
    [TestClass]
    public class MainViewTests
    {
        private string errorMessage;
        private bool operationSucceeded;
        private MainView mainView;
        private MainPresenter mainPresenter;

        public MainViewTests()
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            DeleteConfirmView deleteConfirmView = new DeleteConfirmView();
            mainView = new MainView(errorMessageView);

            SettingsPresenter settingsPresenter = new SettingsPresenter(new SettingsUC(errorMessageView), errorMessageView);
            StoreFacade facade = ServicesInitialiser.facade;

            UnitsService unitsService = ServicesInitialiser.unitsService;
            UnitsDetailUC unitsDetailUC = new UnitsDetailUC(errorMessageView);
            UnitsDetailPresenter unitsDetailPresenter = new UnitsDetailPresenter(unitsDetailUC, facade);
            UnitsPresenter unitsPresenter = new UnitsPresenter(new UnitsUC(errorMessageView), facade, unitsDetailPresenter, deleteConfirmView, errorMessageView);

            SuppliersService supplierService = ServicesInitialiser.suppliersService;
            SuppliersDetailUC suppliersDetailUC = new SuppliersDetailUC(errorMessageView);
            SuppliersDetailPresenter suppliersDetailPresenter = new SuppliersDetailPresenter(suppliersDetailUC, facade);
            SuppliersPresenter suppliersPresenter = new SuppliersPresenter(new SuppliersUC(errorMessageView), suppliersDetailPresenter, facade, deleteConfirmView, errorMessageView);

            ProductsService productsService = ServicesInitialiser.productsService;
            ProductsDetailUC productsDetailUC = new ProductsDetailUC(errorMessageView);
            ProductsDetailPresenter productsDetailPresenter = new ProductsDetailPresenter(productsDetailUC, facade);
            ProductsPresenter productsPresenter = new ProductsPresenter(new ProductsUC(errorMessageView), productsDetailPresenter,
                facade, deleteConfirmView, errorMessageView);

            ParametersService parametersService = ServicesInitialiser.parametersService;
            ParametersDetailUC parametersDetailUC = new ParametersDetailUC(errorMessageView);
            ParametersDetailPresenter parametersDetailPresenter = new ParametersDetailPresenter(parametersDetailUC, facade);
            ParametersPresenter parametersPresenter = new ParametersPresenter(new ParametersUC(errorMessageView), 
                parametersDetailPresenter, facade, deleteConfirmView, errorMessageView);

            ImagesService imagesService = ServicesInitialiser.imagesService;
            ImagesDetailUC imagesDetailUC = new ImagesDetailUC(errorMessageView);
            ImagesDetailPresenter imagesDetailPresenter = new ImagesDetailPresenter(imagesDetailUC, facade);
            ImagesPresenter imagesPresenter = new ImagesPresenter(new ImagesUC(errorMessageView), imagesDetailPresenter, ServicesInitialiser.facade, deleteConfirmView, errorMessageView);

            GroupsService groupsService = ServicesInitialiser.groupsService;
            GroupsDetailUC groupsDetailUC = new GroupsDetailUC(errorMessageView);
            GroupsDetailPresenter groupsDetailPresenter = new GroupsDetailPresenter(groupsDetailUC, ServicesInitialiser.facade);
            GroupsPresenter groupsPresenter = new GroupsPresenter(new GroupsUC(errorMessageView), groupsDetailPresenter, ServicesInitialiser.facade, deleteConfirmView, errorMessageView);

            CategoriesService categoriesService = ServicesInitialiser.categoriesService;
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
        }

        [TestInitialize]
        public void TestInit()
        {
            errorMessage = "";
            operationSucceeded = false;
        }

        [TestMethod]
        public void NewfileToolStripMenuItem_Click_ShouldReturn_Success()
        {
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

        [TestMethod]
        public void OpenToolStripMenuItem_Click_ShouldReturn_Success()
        {
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

        [TestMethod]
        public void ExportcsvToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.ExportcsvToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void ExportxmlToolStripMenuItem1_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.ExportxmlToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void ProductsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.ProductsToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void CategoriesToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.CategoriesToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void GroupspromuaToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.GroupsToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SuppliersToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.SuppliersToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void ParametersToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.ParametersToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void ImagesToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.ImagesToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void UnitsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.UnitsToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void SettingsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.SettingsToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void FindNewProductsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.FindNewProductsToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void FindOldProductsToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.FindOldProductsToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void CheckAvailabilityToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.CheckAvailabilityToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void CheckPricesToolStripMenuItem_Click_ShouldReturn_Success()
        {
            try
            {
                mainView.CheckPricesToolStripMenuItem_Click(this, new EventArgs());
                operationSucceeded = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " | " + ex.StackTrace;
            }
            Assert.IsTrue(operationSucceeded, errorMessage);
        }

        [TestMethod]
        public void HelpinfoToolStripMenuItem_Click_ShouldReturn_Success()
        {
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

        [TestMethod]
        public void AboutToolStripMenuItem_Click_ShouldReturn_Success()
        {
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