using DataAccess.RepositoriesSqlCE;
using Presentation.Presenters.UserControls;
using Presentation.Views.UserControls;
using Services.CategoriesService;
using Services.GroupsService;
using Services.ImagesService;
using Services.ParametersService;
using Services.ProductsService;
using Services.SuppliersService;
using Services.UnitsService;
using System;
using System.Configuration;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCEConnection"].ConnectionString;

            IUnityContainer UnityC;
            UnityC = new UnityContainer()
                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IUnitsUC, UnitsUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IUnitsDetailUC, UnitsDetailUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IUnitsPresenter, UnitsPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IUnitsDetailPresenter, UnitsDetailPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IUnitsService, UnitsService>(new ContainerControlledLifetimeManager())
                .RegisterType<IUnitsRepository, UnitsRepository>(new InjectionConstructor(connectionString))

                .RegisterType<ISuppliersUC, SuppliersUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISuppliersDetailUC, SuppliersDetailUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ISuppliersPresenter, SuppliersPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISuppliersDetailPresenter, SuppliersDetailPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ISuppliersService, SuppliersService>(new ContainerControlledLifetimeManager())
                .RegisterType<ISuppliersRepository, SuppliersRepository>(new InjectionConstructor(connectionString))

                .RegisterType<IProductsUC, ProductsUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IProductsDetailUC, ProductsDetailUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IProductsPresenter, ProductsPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IProductsDetailPresenter, ProductsDetailPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IProductsService, ProductsService>(new ContainerControlledLifetimeManager())
                .RegisterType<IProductsRepository, ProductsRepository>(new InjectionConstructor(connectionString))

                .RegisterType<IParametersUC, ParametersUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IParametersDetailUC, ParametersDetailUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IParametersPresenter, ParametersPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IParametersDetailPresenter, ParametersDetailPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IParametersService, ParametersService>(new ContainerControlledLifetimeManager())
                .RegisterType<IParametersRepository, ParametersRepository>(new InjectionConstructor(connectionString))

                .RegisterType<IImagesUC, ImagesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IImagesDetailUC, ImagesDetailUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IImagesPresenter, ImagesPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IImagesDetailPresenter, ImagesDetailPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IImagesService, ImagesService>(new ContainerControlledLifetimeManager())
                .RegisterType<IImagesRepository, ImagesRepository>(new InjectionConstructor(connectionString))

                .RegisterType<IGroupsUC, GroupsUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IGroupsDetailUC, GroupsDetailUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IGroupsPresenter, GroupsPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IGroupsDetailPresenter, GroupsDetailPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IGroupsService, GroupsService>(new ContainerControlledLifetimeManager())
                .RegisterType<IGroupsRepository, GroupsRepository>(new InjectionConstructor(connectionString))

                .RegisterType<ICategoriesUC, CategoriesUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ICategoriesDetailUC, CategoriesDetailUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ICategoriesPresenter, CategoriesPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ICategoriesDetailPresenter, CategoriesDetailPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ICategoriesService, CategoriesService>(new ContainerControlledLifetimeManager())
                .RegisterType<ICategoriesRepository, CategoriesRepository>(new InjectionConstructor(connectionString))

                .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())
                .RegisterType<IDeleteConfirmView, DeleteConfirmView>(new ContainerControlledLifetimeManager());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMainPresenter mainPresenter = UnityC.Resolve<MainPresenter>();
            IMainView mainView = mainPresenter.GetMainView();
            Application.Run((MainView)mainView);
        }
    }
}
