using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Products;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.SuppliersServices;
using Services.UnitsServices;
using Services.Validators;

namespace Services.ProductsServices
{
    /// <summary>
    /// Клас сервісу товарів
    /// </summary>
    public class ProductsService : IProductsService
    {
        IProductsRepository productsRepository;
        ICategoriesService categoriesSevice;
        IGroupsService groupsService;
        ISuppliersService suppliersService;
        IUnitsService unitsService;

        ProductsValidator productsValidator = new ProductsValidator();

        /// <summary>
        /// Конструктор сервісу товарів
        /// </summary>
        /// <param name="productsRepository">Екземпляр репозиторію товарів</param>
        /// <param name="categoriesSevice">Екземпляр сервісу категорій</param>
        /// <param name="groupsService">Екземпляр сервісу груп</param>
        /// <param name="suppliersService">Екземпляр сервіу постачальників</param>
        /// <param name="unitsService">Екземпляр сервісу одиниць виміру</param>
        public ProductsService(IProductsRepository productsRepository,
                                ICategoriesService categoriesSevice,
                                IGroupsService groupsService,
                                ISuppliersService suppliersService,
                                IUnitsService unitsService)
        {
            this.productsRepository = productsRepository;
            this.categoriesSevice = categoriesSevice;
            this.groupsService = groupsService;
            this.suppliersService = suppliersService;
            this.unitsService = unitsService;
        }

        /// <summary>
        /// Додає товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        public void AddProduct(ProductsDtoModel productDto)
        {
            ProductsModel product = new ProductsModel
            {
                Id = productDto.Id,
                SupplierId = productDto.SupplierId,
                CategoryId = productDto.CategoryId,
                GroupId = productDto.GroupId,
                UnitId = productDto.UnitId,
                NameWebStore = productDto.NameWebStore,
                NameSupplier = productDto.NameSupplier,
                CodeWebStore = productDto.CodeWebStore,
                CodeSupplier = productDto.CodeSupplier,
                PriceWebStore = productDto.PriceWebStore,
                PriceSupplier = productDto.PriceSupplier,
                Available = productDto.Available,
                LinkWebStore = productDto.LinkWebStore,
                LinkSupplier = productDto.LinkSupplier,
                Notes = productDto.Notes
            };
            var results = productsValidator.Validate(product);
            if (results.IsValid)
            {
                productsRepository.Add(product);
            }
            else
            {
                throw new Exception("Помилка валідації товару: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }

        /// <summary>
        /// Видаляє товар
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        public void DeleteProductById(int id) => productsRepository.DeleteById(id);

        /// <summary>
        /// Повертає екземпляр товару за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        /// <returns>Екземпляр товару</returns>
        public ProductsDtoModel GetProductById(int id)
        {
            var product = productsRepository.GetById(id);
            ProductsDtoModel productDto = new ProductsDtoModel
            {
                Id = product.Id,
                SupplierName = suppliersService.GetSupplierById(product.SupplierId).Name,
                CategoryName = categoriesSevice.GetCategoryById(product.CategoryId).Name,
                GroupName = groupsService.GetGroupById((int)product.GroupId).Name ?? "",
                UnitName = unitsService.GetUnitById(product.UnitId).Name,
                NameWebStore = product.NameWebStore,
                NameSupplier = product.NameSupplier,
                CodeWebStore = product.CodeWebStore,
                CodeSupplier = product.CodeSupplier,
                PriceWebStore = product.PriceWebStore,
                PriceSupplier = product.PriceSupplier,
                Currency = suppliersService.GetSupplierById(product.SupplierId).Currency,
                Available = product.Available,
                LinkWebStore = product.LinkWebStore,
                LinkSupplier = product.LinkSupplier,
                Notes = product.Notes
            };
            return productDto;
        }

        /// <summary>
        /// Повертає список товарів
        /// </summary>
        /// <returns>Список товарів</returns>
        public IEnumerable<ProductsDtoModel> GetProducts()
        {
            List<ProductsDtoModel> productsDtos = new List<ProductsDtoModel>();
            List<SuppliersDtoModel> suppliers = suppliersService.GetSuppliers().ToList();
            List<CategoriesDtoModel> categories = categoriesSevice.GetCategories().ToList();
            List<GroupsDtoModel> groups = groupsService.GetGroups().ToList();
            List<UnitsDtoModel> units = unitsService.GetUnits().ToList();
            foreach (ProductsModel product in productsRepository.GetAll())
            {
                productsDtos.Add(new ProductsDtoModel
                {
                    Id = product.Id,
                    SupplierId = product.SupplierId,
                    SupplierName = suppliers.Where(s => s.Id == product.SupplierId).FirstOrDefault().Name,
                    CategoryId = product.CategoryId,
                    CategoryName = categories.Where(c => c.Id == product.CategoryId).FirstOrDefault().Name,
                    GroupId = product.GroupId ?? 0,
                    GroupName = product.GroupId == 0 ? "" : groups.Where(g => g.Id == product.GroupId).FirstOrDefault().Name,
                    UnitId = product.UnitId,
                    UnitName = units.Where(u => u.Id == product.UnitId).FirstOrDefault().Name,
                    NameWebStore = product.NameWebStore,
                    NameSupplier = product.NameSupplier,
                    CodeWebStore = product.CodeWebStore,
                    CodeSupplier = product.CodeSupplier,
                    PriceWebStore = product.PriceWebStore,
                    PriceSupplier = product.PriceSupplier,
                    Currency = suppliers.Where(s => s.Id == product.SupplierId).FirstOrDefault().Currency,
                    Available = product.Available,
                    LinkWebStore = product.LinkWebStore,
                    LinkSupplier = product.LinkSupplier,
                    Notes = product.Notes
                });
            }
            return productsDtos;

        }

        /// <summary>
        /// Оновлює товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        public void UpdateProduct(ProductsDtoModel productDto)
        {
            ProductsModel product = new ProductsModel
            {
                Id = productDto.Id,
                SupplierId = productDto.SupplierId,
                CategoryId = productDto.CategoryId,
                GroupId = productDto.GroupId,
                UnitId = productDto.UnitId,
                NameWebStore = productDto.NameWebStore,
                NameSupplier = productDto.NameSupplier,
                CodeWebStore = productDto.CodeWebStore,
                CodeSupplier = productDto.CodeSupplier,
                PriceWebStore = productDto.PriceWebStore,
                PriceSupplier = productDto.PriceSupplier,
                Available = productDto.Available,
                LinkWebStore = productDto.LinkWebStore,
                LinkSupplier = productDto.LinkSupplier,
                Notes = productDto.Notes
            };
            var results = productsValidator.Validate(product);
            if (results.IsValid)
            {
                productsRepository.Update(product);
            }
            else
            {
                throw new Exception("Помилка валідації товару: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }
    }
}
