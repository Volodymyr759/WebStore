using Common;
using Presentation.Presenters.UserControls;
using Services;
using Services.ShedulerServices;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Presentation
{
    /// <summary>
    /// Інтерфейс головного презентера
    /// </summary>
    public class MainPresenter : IMainPresenter
    {
        /// <summary>
        /// Тестова подія, лише для розробки. В продакшені - не застосовується
        /// </summary>
        public event EventHandler TestEventRaised;

        IMainView mainView;
        ISettingsPresenter settingsPresenter;
        IUnitsPresenter unitsPresenter;
        IUnitsDetailPresenter unitsDetailPresenter;
        ISuppliersPresenter suppliersPresenter;
        ISuppliersDetailPresenter suppliersDetailPresenter;
        IProductsPresenter productsPresenter;
        IProductsDetailPresenter productsDetailPresenter;
        IParametersPresenter parametersPresenter;
        IParametersDetailPresenter parametersDetailPresenter;
        IImagesPresenter imagesPresenter;
        IImagesDetailPresenter imagesDetailPresenter;
        IGroupsPresenter groupsPresenter;
        IGroupsDetailPresenter groupsDetailPresenter;
        ICategoriesPresenter categoriesPresenter;
        ICategoriesDetailPresenter categoriesDetailPresenter;

        IStoreFacade facade;
        IDeleteConfirmView deleteConfirmView;

        Panel mainPanel;
        Panel rightPanel;

        ToolStripTextBox searchToolStripTextBox;

        /// <summary>
        /// Порожній конструктор головного презентера
        /// </summary>
        public MainPresenter()
        {
        }

        /// <summary>
        /// Конструктор головного презентера, інжектуючий використовувані компоненти системи
        /// </summary>
        /// <param name="mainView">Головна форма</param>
        /// <param name="settingsPresenter">Презентер представлення налаштувань</param>
        /// <param name="unitsPresenter">Презентер представлення одиниць виміру</param>
        /// <param name="unitsDetailPresenter">Презентер представлення для операцій з одиницями виміру</param>
        /// <param name="suppliersPresenter">Презентер представлення постачальників</param>
        /// <param name="suppliersDetailPresenter">Презентер представлення для операцій з постачальниками</param>
        /// <param name="productsPresenter">Презентер представлення товарів</param>
        /// <param name="productsDetailPresenter">Презентер представлення для операцій з товарами</param>
        /// <param name="parametersPresenter">Презентер представлення характеристик товарів</param>
        /// <param name="parametersDetailPresenter">Презентер представлення для операцій з характеристиками товарів</param>
        /// <param name="imagesPresenter">Презентер представлення зображень товарів</param>
        /// <param name="imagesDetailPresenter">Презентер представлення для операцій з зображеннями товарів</param>
        /// <param name="groupsPresenter">Презентер представлення груп у власному каталозі/сайті</param>
        /// <param name="groupsDetailPresenter">Презентер представлення для операцій з групами власного каталогу/сайту</param>
        /// <param name="categoriesPresenter">Презентер представлення категорій товарів постачальників</param>
        /// <param name="categoriesDetailPresenter">Презентер представлення категорій товарів на сайтах постачальників</param>
        /// <param name="facade">Фасад сервіс-рівня</param>
        /// <param name="deleteConfirmView">Універсальне представлення підтвердження видалення сутності</param>
        public MainPresenter(IMainView mainView,
            ISettingsPresenter settingsPresenter,
            IUnitsPresenter unitsPresenter, IUnitsDetailPresenter unitsDetailPresenter,
            ISuppliersPresenter suppliersPresenter, ISuppliersDetailPresenter suppliersDetailPresenter,
            IProductsPresenter productsPresenter, IProductsDetailPresenter productsDetailPresenter,
            IParametersPresenter parametersPresenter, IParametersDetailPresenter parametersDetailPresenter,
            IImagesPresenter imagesPresenter, IImagesDetailPresenter imagesDetailPresenter,
            IGroupsPresenter groupsPresenter, IGroupsDetailPresenter groupsDetailPresenter,
            ICategoriesPresenter categoriesPresenter, ICategoriesDetailPresenter categoriesDetailPresenter,
            IStoreFacade facade,
            IDeleteConfirmView deleteConfirmView)
        {
            this.mainView = mainView;
            this.settingsPresenter = settingsPresenter;
            this.unitsPresenter = unitsPresenter; this.unitsDetailPresenter = unitsDetailPresenter;
            this.suppliersPresenter = suppliersPresenter; this.suppliersDetailPresenter = suppliersDetailPresenter;
            this.productsPresenter = productsPresenter; this.productsDetailPresenter = productsDetailPresenter;
            this.parametersPresenter = parametersPresenter; this.parametersDetailPresenter = parametersDetailPresenter;
            this.imagesPresenter = imagesPresenter; this.imagesDetailPresenter = imagesDetailPresenter;
            this.groupsPresenter = groupsPresenter; this.groupsDetailPresenter = groupsDetailPresenter;
            this.categoriesPresenter = categoriesPresenter; this.categoriesDetailPresenter = categoriesDetailPresenter;
            this.facade = facade;
            this.deleteConfirmView = deleteConfirmView;

            mainPanel = mainView.GetMainPanel();
            rightPanel = mainView.GetRightPanel();

            SubscribeToEventsSetup();
        }

        /// <summary>
        /// Отримує головну форму
        /// </summary>
        /// <returns></returns>
        public IMainView GetMainView() => mainView;

        private void SubscribeToEventsSetup()
        {
            mainView.MainViewLoadedEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)settingsPresenter.GetSettingsUC());
            mainView.UnitsMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)unitsPresenter.GetUnitsUC());
            mainView.SuppliersMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)suppliersPresenter.GetSuppliersUC());
            mainView.ProductsMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)productsPresenter.GetProductsUC());
            mainView.ParametersMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)parametersPresenter.GetParametersUC());
            mainView.ImagesMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)imagesPresenter.GetImagesUC());
            mainView.GroupsMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)groupsPresenter.GetGroupsUC());
            mainView.CategoriesMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)categoriesPresenter.GetCategoriesUC());
            mainView.ExportСsvMenuClickEventRaised += OnExportСsvMenuClickEventRaised;
            mainView.ExportXmlMenuClickEventRaised += OnExportXmlMenuClickEventRaised;

            mainView.SettingsMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)settingsPresenter.GetSettingsUC());
            mainView.FindNewProductsMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)productsPresenter.GetNewProducts());
            mainView.FindOldProductsMenuClickEventRaised += (sender, e) => OnFindOldProductsMenuClickEventRaised(sender, e);
            mainView.CheckAvailabilityMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)productsPresenter.CheckAvailability());
            mainView.CheckPricesMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)productsPresenter.CheckPrices());
            mainView.GetImagesMenuClickEventRaised += (sender, e) =>
            {
                SetupMainView(mainPanel, (UserControl)imagesPresenter.LoadImages(
                    new string[] { ConfigurationManager.AppSettings["textBoxFolderImages1"] } ));
            };
            mainView.GetParametersMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)parametersPresenter.LoadParameters());

            unitsDetailPresenter.ReadyToShowUnitsDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)unitsDetailPresenter.GetUnitsDetailUC());
            unitsDetailPresenter.CancelClickEventRaised += OnCancelClickEventRaised;
            unitsDetailPresenter.SaveUnitClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)unitsPresenter.GetUnitsUC());

            suppliersPresenter.LinkToSearchChangedEventRaised += (sender, modelDictionary) => OnLinkToSearchChangedEventRaised(sender, modelDictionary);
            suppliersDetailPresenter.ReadyToShowSuppliersDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)suppliersDetailPresenter.GetSuppliersDetailUC());
            suppliersDetailPresenter.CancelClickEventRaised += OnCancelClickEventRaised;
            suppliersDetailPresenter.SaveSupplierClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)suppliersPresenter.GetSuppliersUC());

            productsPresenter.LinkToSearchChangedEventRaised += (sender, modelDictionary) => OnLinkToSearchChangedEventRaised(sender, modelDictionary);
            productsDetailPresenter.ReadyToShowProductsDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)productsDetailPresenter.GetProductsDetailUC());
            productsDetailPresenter.CancelClickEventRaised += OnCancelClickEventRaised;
            productsDetailPresenter.SaveProductClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)productsPresenter.GetProductsUC());

            parametersDetailPresenter.ReadyToShowParametersDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)parametersDetailPresenter.GetParametersDetailUC());
            parametersDetailPresenter.CancelClickEventRaised += OnCancelClickEventRaised;
            parametersDetailPresenter.SaveParameterClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)parametersPresenter.GetParametersUC());

            imagesPresenter.LinkToSearchChangedEventRaised += (sender, modelDictionary) => OnLinkToSearchChangedEventRaised(sender, modelDictionary);
            imagesDetailPresenter.ReadyToShowImagesDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)imagesDetailPresenter.GetImagesDetailUC());
            imagesDetailPresenter.CancelClickEventRaised += OnCancelClickEventRaised;
            imagesDetailPresenter.SaveImageClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)imagesPresenter.GetImagesUC());

            groupsPresenter.LinkToSearchChangedEventRaised += (sender, modelDictionary) => OnLinkToSearchChangedEventRaised(sender, modelDictionary);
            groupsDetailPresenter.ReadyToShowGroupsDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)groupsDetailPresenter.GetGroupsDetailUC());
            groupsDetailPresenter.CancelClickEventRaised += OnCancelClickEventRaised;
            groupsDetailPresenter.SaveGroupClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)groupsPresenter.GetGroupsUC());

            categoriesPresenter.LinkToSearchChangedEventRaised += (sender, modelDictionary) => OnLinkToSearchChangedEventRaised(sender, modelDictionary);
            categoriesDetailPresenter.ReadyToShowCategoriesDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)categoriesDetailPresenter.GetCategoriesDetailUC());
            categoriesDetailPresenter.CancelClickEventRaised += OnCancelClickEventRaised;
            categoriesDetailPresenter.SaveCategoryClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)categoriesPresenter.GetCategoriesUC());

            deleteConfirmView.DeleteConfirmViewOKEventRaised += (sender, e) => OnDeleteConfirmViewOKEventRaised(sender, e);
        }

        private void SetupMainView(Panel targetPanel, UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            if (targetPanel.Name == "panelMain")
            {
                mainPanel = mainView.GetMainPanel();
                mainPanel.Controls.Clear();
                rightPanel.Visible = false;
            }
            else
            {
                rightPanel = mainView.GetRightPanel();
                rightPanel.Controls.Clear();
                rightPanel.Visible = true;
            }
            targetPanel.Controls.Add(userControl);

            if (settingsPresenter.IsNeedRunShedule()) RunSheduler();

            EventHelper.RaiseEvent(this, TestEventRaised, new EventArgs());
        }

        private void RunSheduler()
        {
            Scheduler.IntervalInMinutes(settingsPresenter.GetSheduleStartTime().Hour,
                settingsPresenter.GetSheduleStartTime().Minute,
                settingsPresenter.GetSheduleInterval(), () =>
            {
                try
                {
                    if (settingsPresenter.IsNeedToCheckAvailability()) facade.CheckAvailabilityProducts();
                    if (settingsPresenter.IsNeedToCheckPrices()) facade.CheckPricesProducts();
                    if (settingsPresenter.IsNeedToLoadNewProducts()) facade.GetNewProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private void OnCancelClickEventRaised(object sender, EventArgs e)
        {
            rightPanel.Controls.Clear();
            rightPanel.Visible = false;
        }

        private void OnDeleteConfirmViewOKEventRaised(object sender, EventArgs e)
        {
            switch (((DeleteConfirmView)sender).GetUserControlName())
            {
                case "CategoriesUC":
                    facade.DeleteCategoryById(deleteConfirmView.GetIdToDelete());
                    SetupMainView(mainPanel, (UserControl)categoriesPresenter.GetCategoriesUC());
                    break;
                case "GroupsUC":
                    facade.DeleteGroupById(deleteConfirmView.GetIdToDelete());
                    SetupMainView(mainPanel, (UserControl)groupsPresenter.GetGroupsUC());
                    break;
                case "ImagesUC":
                    facade.DeleteImageById(deleteConfirmView.GetIdToDelete());
                    SetupMainView(mainPanel, (UserControl)imagesPresenter.GetImagesUC());
                    break;
                case "ParametersUC":
                    facade.DeleteParameterById(deleteConfirmView.GetIdToDelete());
                    SetupMainView(mainPanel, (UserControl)parametersPresenter.GetParametersUC());
                    break;
                case "ProductsUC":
                    facade.DeleteProductById(deleteConfirmView.GetIdToDelete());
                    SetupMainView(mainPanel, (UserControl)productsPresenter.GetProductsUC());
                    break;
                case "SuppliersUC":
                    facade.DeleteSupplierById(deleteConfirmView.GetIdToDelete());
                    SetupMainView(mainPanel, (UserControl)suppliersPresenter.GetSuppliersUC());
                    break;
                case "UnitsUC":
                    facade.DeleteUnitById(deleteConfirmView.GetIdToDelete());
                    SetupMainView(mainPanel, (UserControl)unitsPresenter.GetUnitsUC());
                    break;

                default:
                    break;
            }
        }

        private void OnExportСsvMenuClickEventRaised(object sender, EventArgs e)
        {
            SaveFileDialog sfd;
            sfd = new SaveFileDialog() { Filter = "CSV (.csv)|*.csv", ValidateNames = true };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = facade.ExportProductsToCsvFile();
                StreamWriter sw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8);
                sw.WriteLine(sb);
                sw.Close();
                sw.Dispose();
                MessageBox.Show("Експорт завершено.");
            }
        }

        private void OnExportXmlMenuClickEventRaised(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "XML (.xml)|*.xml", ValidateNames = true };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XDocument xdoc = facade.ExportProductsToXmlFile();
                xdoc.Save(sfd.FileName);
                MessageBox.Show("Експорт завершено.");
            }
        }

        private void OnFindOldProductsMenuClickEventRaised(object sender, EventArgs e)
        {
            SaveFileDialog sfd;
            sfd = new SaveFileDialog() { Filter = "CSV (.csv)|*.csv", ValidateNames = true };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = facade.ExportOldPRoductsToCsvFile();
                StreamWriter sw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8);
                sw.WriteLine(sb);
                sw.Close();
                sw.Dispose();
                MessageBox.Show("Експорт завершено.");
            }
        }

        private void OnLinkToSearchChangedEventRaised(object sender, DataEventArgs modelDictionary)
        {
            searchToolStripTextBox = mainView.GetToolStripSearchBox();
            if (modelDictionary.ModelDictionary["Link"].Contains("http")) searchToolStripTextBox.Text = modelDictionary.ModelDictionary["Link"];
        }
    }
}
