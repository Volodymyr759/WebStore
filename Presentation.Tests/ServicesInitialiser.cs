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
    public static class ServicesInitialiser
    {
        const string connString = @"Data Source=D:\webstore.sdf";

        public static GroupsService groupsService = new GroupsService(new GroupsRepository(connString));

        public static UnitsService unitsService = new UnitsService(new UnitsRepository(connString));

        public static SuppliersService suppliersService = new SuppliersService(new SuppliersRepository(connString));

        public static CommonRepository commonRepository = new CommonRepository(connString);

        public static CategoriesService categoriesService = new CategoriesService(new CategoriesRepository(connString),
                 commonRepository);

        public static ProductsService productsService = new ProductsService(new ProductsRepository(connString), commonRepository);

        public static ImagesService imagesService = new ImagesService(new ImagesRepository(connString), commonRepository);

        public static ParametersService parametersService = new ParametersService(new ParametersRepository(connString), commonRepository);

        public static StoreFacade facade = new StoreFacade(categoriesService,
            groupsService, imagesService, parametersService, productsService, suppliersService, unitsService, 
            new ImagesAgent(), new ParametersAgent(), new SaverToCsvAgent(), new SaverToXmlAgent());
    }

}
