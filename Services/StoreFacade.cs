using Services.Agents;
using Services.GroupsServices;
using Services.ImagesServices;
using Services.ParametersServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Services.CategoriesServices;

namespace Services
{
    /// <summary>
    /// Фасад сервісного рівня
    /// </summary>
    public class StoreFacade : IStoreFacade
    {
        ICategoriesService categoriesService;
        IGroupsService groupsService;
        IImagesService imagesService;
        IParametersService parametersService;
        IProductsService productsService;
        ISuppliersService suppliersService;
        IUnitsService unitsService;

        IImagesAgent imagesAgent;
        IParametersAgent parametersAgent;
        ISaverToCsvAgent saverToCsvAgent;
        ISaverToXmlAgent saverToXmlAgent;

        /// <summary>
        /// Конструктор фасаду сервісного рівня
        /// </summary>
        /// <param name="categoriesService">Екземпляр сервісу категорій</param>
        /// <param name="groupsService">Екземпляр сервісу груп</param>
        /// <param name="imagesService">Екземпляр сервісу зображень</param>
        /// <param name="parametersService">Екземпляр сервісу характеристик</param>
        /// <param name="productsService">Екземпляр сервісу товарів</param>
        /// <param name="suppliersService">Екземпляр сервісу постачальників</param>
        /// <param name="unitsService">Екземпляр сервісу одиниць виміру</param>
        /// <param name="imagesAgent">Екземпляр завантажувача зображень</param>
        /// <param name="parametersAgent">Екземпляр завантажувача характеристик</param>
        /// <param name="saverToCsvAgent">Екземпляр класу збереження в Csv</param>
        /// <param name="saverToXmlAgent">Екземпляр класу збереження в Xml</param>
        public StoreFacade(ICategoriesService categoriesService,
            IGroupsService groupsService,
            IImagesService imagesService,
            IParametersService parametersService,
            IProductsService productsService,
            ISuppliersService suppliersService,
            IUnitsService unitsService,

            IImagesAgent imagesAgent, IParametersAgent parametersAgent,
            ISaverToCsvAgent saverToCsvAgent, ISaverToXmlAgent saverToXmlAgent)
        {
            this.categoriesService = categoriesService;
            this.groupsService = groupsService;
            this.imagesService = imagesService;
            this.parametersService = parametersService;
            this.productsService = productsService;
            this.suppliersService = suppliersService;
            this.unitsService = unitsService;

            this.imagesAgent = imagesAgent;
            this.parametersAgent = parametersAgent;
            this.saverToCsvAgent = saverToCsvAgent;
            this.saverToXmlAgent = saverToXmlAgent;
        }

        /// <summary>
        /// Повертає список категорій Dto
        /// </summary>
        /// <returns>Список категорій</returns>
        public IEnumerable<CategoriesDtoModel> GetCategoriesDto() => categoriesService.GetCategories();

        /// <summary>
        /// Додає категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        public void AddCategory(CategoriesDtoModel categoryDto) => categoriesService.AddCategory(categoryDto);

        /// <summary>
        /// Видаляє категорію
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        public void DeleteCategoryById(int id) => categoriesService.DeleteCategoryById(id);

        /// <summary>
        /// Повертає екземпляр категорії за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        public CategoriesDtoModel GetCategoryById(int id) => categoriesService.GetCategoryById(id);

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        public void UpdateCategory(CategoriesDtoModel categoryDto) => categoriesService.UpdateCategory(categoryDto);

        /// <summary>
        /// Повертає список груп
        /// </summary>
        /// <returns>Список груп</returns>
        public IEnumerable<GroupsDtoModel> GetGroupsDto() => groupsService.GetGroups();

        /// <summary>
        /// Додає групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        public void AddGroup(GroupsDtoModel groupDto) => groupsService.AddGroup(groupDto);

        /// <summary>
        /// Видаляє групу
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        public void DeleteGroupById(int id) => groupsService.DeleteGroupById(id);

        /// <summary>
        /// Повертає екземпляр групи за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        /// <returns>Екземпляр групи</returns>
        public GroupsDtoModel GetGroupById(int id) => groupsService.GetGroupById(id);

        /// <summary>
        /// Оновлює групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        public void UpdateGroup(GroupsDtoModel groupDto) => groupsService.UpdateGroup(groupDto);

        /// <summary>
        /// Повертає список зображень
        /// </summary>
        /// <returns>Список зображень</returns>
        public IEnumerable<ImagesDtoModel> GetImagesDto() => imagesService.GetImages();

        /// <summary>
        /// Додає зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        public void AddImage(ImagesDtoModel imageDto) => imagesService.AddImage(imageDto);

        /// <summary>
        /// Видаляє зображення
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        public void DeleteImageById(int id) => imagesService.DeleteImageById(id);

        /// <summary>
        /// Повертає екземпляр зображення за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        public ImagesDtoModel GetImageById(int id) => imagesService.GetImageById(id);

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        public void UpdateImage(ImagesDtoModel imageDto) => imagesService.UpdateImage(imageDto);

        /// <summary>
        /// Повертає список характеристик
        /// </summary>
        /// <returns>Список характеристик</returns>
        public IEnumerable<ParametersDtoModel> GetParametersDto() => parametersService.GetParameters();

        /// <summary>
        /// Додає характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        public void AddParameter(ParametersDtoModel parameterDto) => parametersService.AddParameter(parameterDto);

        /// <summary>
        /// Видаляє характеристику
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        public void DeleteParameterById(int id) => parametersService.DeleteParameterById(id);

        /// <summary>
        /// Повертає екземпляр характеристики за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        /// <returns>Екземпляр характеристики</returns>
        public ParametersDtoModel GetParameterById(int id) => parametersService.GetParameterById(id);

        /// <summary>
        /// Оновлює характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        public void UpdateParameter(ParametersDtoModel parameterDto) => parametersService.UpdateParameter(parameterDto);

        /// <summary>
        /// Повертає список товарів
        /// </summary>
        /// <returns>Список товарів</returns>
        public IEnumerable<ProductsDtoModel> GetProductsDto() => productsService.GetProducts();

        /// <summary>
        /// Додає товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        public void AddProduct(ProductsDtoModel productDto) => productsService.AddProduct(productDto);

        /// <summary>
        /// Видаляє товар
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        public void DeleteProductById(int id) => productsService.DeleteProductById(id);

        /// <summary>
        /// Повертає екземпляр товару за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        /// <returns>Екземпляр товару</returns>
        public ProductsDtoModel GetProductById(int id) => productsService.GetProductById(id);

        /// <summary>
        /// Оновлює товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        public void UpdateProduct(ProductsDtoModel productDto) => productsService.UpdateProduct(productDto);

        /// <summary>
        /// Повертає список постачальників
        /// </summary>
        /// <returns>Список постачальників</returns>
        public IEnumerable<SuppliersDtoModel> GetSuppliersDto() => suppliersService.GetSuppliers();

        /// <summary>
        /// Додає постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        public void AddSupplier(SuppliersDtoModel supplierDto) => suppliersService.AddSupplier(supplierDto);

        /// <summary>
        /// Видаляє постачальника
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        public void DeleteSupplierById(int id) => suppliersService.DeleteSupplierById(id);

        /// <summary>
        /// Повертає екземпляр постачальника за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        /// <returns>Екземпляр постачальника</returns>
        public SuppliersDtoModel GetSupplierById(int id) => suppliersService.GetSupplierById(id);

        /// <summary>
        /// Оновлює постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        public void UpdateSupplier(SuppliersDtoModel supplierDto) => suppliersService.UpdateSupplier(supplierDto);

        /// <summary>
        /// Повертає список одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        public IEnumerable<UnitsDtoModel> GetUnitsDto() => unitsService.GetUnits();

        /// <summary>
        /// Додає одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        public void AddUnit(UnitsDtoModel unitDto) => unitsService.AddUnit(unitDto);

        /// <summary>
        /// Видаляє одиницю виміру
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        public void DeleteUnitById(int id) => unitsService.DeleteUnitById(id);

        /// <summary>
        /// Повертає екземпляр одиниці виміру за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр категорії</returns>
        public UnitsDtoModel GetUnitById(int id) => unitsService.GetUnitById(id);

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        public void UpdateUnit(UnitsDtoModel unitDto) => unitsService.UpdateUnit(unitDto);

        /// <summary>
        /// Повертає текст для збереження в Csv - файлі
        /// </summary>
        public StringBuilder ExportProductsToCsvFile() => saverToCsvAgent.ExportToFile(GetProductsDto(), GetGroupsDto());

        /// <summary>
        /// Повертає список застарілих (неіснуючих на сайті постачальника) товарів
        /// </summary>
        public StringBuilder ExportOldPRoductsToCsvFile() => saverToCsvAgent.ExportOldProducts(GetOldProducts());

        /// <summary>
        /// Повертає Xml - документ для збереження в Xml - файлі
        /// </summary>
        public XDocument ExportProductsToXmlFile() => saverToXmlAgent.ExportToFile(GetProductsDto(), GetGroupsDto(), GetParametersDto());

        /// <summary>
        /// Завантажує нові товари
        /// </summary>
        public void GetNewProducts()
        {
            List<CategoriesDtoModel> categoriesDtos = PrepareCategoriesForSite("diasha");
            List<ProductsDtoModel> productsDto = new List<ProductsDtoModel>();
            IEnumerable<UnitsDtoModel> unitsDtos = unitsService.GetUnits();
            if (categoriesDtos.Count > 0)
            {
                productsDto.AddRange(FactoryAgents.GetProductsHtmlAgent()
                    .GetNewProducts(GetProductsDto(), categoriesDtos));
                // обчислити unitId, так як з пошуку приходить тільки назва
                foreach (ProductsDtoModel product in productsDto)
                    product.UnitId = unitsDtos.Where(u => u.Name == product.UnitName).FirstOrDefault().Id;

                SaveChangesToDb(productsDto, "Add");
            }
        }

        /// <summary>
        /// Повертає список застарілих товарів
        /// </summary>
        /// <returns>Список відсутніх у постачальника товарів</returns>
        public IEnumerable<ProductsDtoModel> GetOldProducts()
        {
            List<ProductsDtoModel> productsDto = new List<ProductsDtoModel>();
            productsDto.AddRange(FactoryAgents.GetProductsHtmlAgent()
                    .GetOldProducts(GetProductsDto(), PrepareCategoriesForSite("diasha")));
            return productsDto;
        }

        /// <summary>
        /// Оновлення значень наявності товарів у постачальників
        /// </summary>
        public void CheckAvailabilityProducts()
        {
            List<CategoriesDtoModel> categoriesDtos = PrepareCategoriesForSite("diasha");
            IEnumerable<ProductsDtoModel> productsDto = new List<ProductsDtoModel>();
            if (categoriesDtos.Count > 0)
            {
                productsDto = FactoryAgents.GetProductsHtmlAgent().CheckAvailability(PrepareProductsListForSite(categoriesDtos));
                SaveChangesToDb(productsDto, "Update");
            }
        }

        /// <summary>
        /// Оновлення цін товарів у постачальників
        /// </summary>
        public void CheckPricesProducts()
        {
            List<CategoriesDtoModel> categoriesDtos = PrepareCategoriesForSite("diasha");
            IEnumerable<ProductsDtoModel> productsDto = new List<ProductsDtoModel>();
            if (categoriesDtos.Count > 0)
            {
                productsDto = FactoryAgents.GetProductsHtmlAgent().CheckPrices(PrepareProductsListForSite(categoriesDtos), categoriesDtos);
                SaveChangesToDb(productsDto, "Update");
            }
        }

        /// <summary>
        /// Завантажує зображення з джерела постачальника
        /// </summary>
        /// <param name="localFolderForImagesPath">Локальний каталог для завантаження зображень</param>
        /// <returns>Список зображень</returns>
        public void GetExternalImages(string localFolderForImagesPath)
        {
            List<ProductsDtoModel> productsWithoutSavedImages =
                GetProductsDto().Where(p => p.LinkSupplier.Contains("diasha")).ToList();
            foreach (ImagesDtoModel imagesDto in GetImagesDto().Distinct())
            {
                ProductsDtoModel productDto = productsWithoutSavedImages
                    .Where(p => p.Id == imagesDto.ProductId).FirstOrDefault();
                if (productDto != null) productsWithoutSavedImages.Remove(productDto);
            }
            foreach (var i in imagesAgent.GetExternalImages(productsWithoutSavedImages, localFolderForImagesPath, true))
                imagesService.AddImage(i);
        }

        /// <summary>
        /// Завантажує характеристики з джерела постачальника
        /// </summary>
        public void GetExternalParameters()
        {
            List<ProductsDtoModel> productsWithoutSavedParameters =
                GetProductsDto().Where(p => p.LinkSupplier.Contains("diasha")).ToList();
            foreach (ParametersDtoModel parametersDto in GetParametersDto().Distinct())
            {
                ProductsDtoModel productDto = productsWithoutSavedParameters
                    .Where(p => p.Id == parametersDto.ProductId).FirstOrDefault();
                if (productDto != null) productsWithoutSavedParameters.Remove(productDto);
            }
            // Add specific unit to parameter
            IEnumerable<UnitsDtoModel> unitsDtos = unitsService.GetUnits();
            foreach (var p in parametersAgent.GetExternalParameters(productsWithoutSavedParameters))
            {
                p.UnitId = unitsDtos.Where(u => u.Name == p.UnitName).FirstOrDefault().Id;
                parametersService.AddParameter(p);
            };
        }

        #region Helpers

        private List<CategoriesDtoModel> PrepareCategoriesForSite(string site) => GetCategoriesDto().Where(c => c.Link.Contains(site)).ToList();

        private List<ProductsDtoModel> PrepareProductsListForSite(List<CategoriesDtoModel> categoriesDtos)
        {
            List<ProductsDtoModel> productsDtos = new List<ProductsDtoModel>();
            foreach (var category in categoriesDtos)
                productsDtos.AddRange(GetProductsDto().Where(p => p.CategoryId == category.Id));
            return productsDtos;
        }

        private void SaveChangesToDb(IEnumerable<ProductsDtoModel> productsDtos, string mode)
        {
            if (mode == "Add") foreach (var product in productsDtos) productsService.AddProduct(product);
                else foreach (var product in productsDtos) productsService.UpdateProduct(product);
        }

        #endregion
    }
}
