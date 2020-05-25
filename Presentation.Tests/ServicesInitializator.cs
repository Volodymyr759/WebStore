using Infrastructure.DataAccess.Repositories;
using Services;
using Services.Agents;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ImagesServices;
using Services.ParametersServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;

namespace Presentation.Tests
{
    public static class ServicesInitializator
    {
        const string connString = @"Data Source=D:\webstore.sdf";

        public static GroupsService groupsService = new GroupsService(new GroupsRepository(connString));

        public static UnitsService unitsService = new UnitsService(new UnitsRepository(connString));

        public static SuppliersService suppliersService = new SuppliersService(new SuppliersRepository(connString));

        public static CategoriesService categoriesService = new CategoriesService(new CategoriesRepository(connString),
                 suppliersService);
        public static ProductsService productsService = new ProductsService(new ProductsRepository(connString),
                 categoriesService,
                 groupsService,
                 suppliersService,
                 unitsService);
        public static ImagesService imagesService = new ImagesService(new ImagesRepository(connString), 
                productsService);

        public static ParametersService parametersService = new ParametersService(new ParametersRepository(connString),
                productsService, unitsService);

        public static StoreFacade facade = new StoreFacade(categoriesService,
            groupsService, imagesService, parametersService, productsService, suppliersService, unitsService, 
            new ImagesAgent(), new ParametersAgent(), new SaverToCsvAgent(), new SaverToXmlAgent());
    }

}
