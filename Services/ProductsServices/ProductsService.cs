using System;
using System.Collections.Generic;
using Domain.Models.Products;
using Services.Validators;

namespace Services.ProductsServices
{
    /// <summary>
    /// Клас сервісу товарів
    /// </summary>
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICommonRepository commonRepository;

        ProductsValidator productsValidator = new ProductsValidator();

        /// <summary>
        /// Конструктор сервісу товарів
        /// </summary>
        /// <param name="productsRepository">Екземпляр репозиторію товарів</param>
        /// <param name="commonRepository">Екземпляр репозиторію загальних довідників</param>
        public ProductsService(IProductsRepository productsRepository,
                                ICommonRepository commonRepository)
        {
            this.productsRepository = productsRepository;
            this.commonRepository = commonRepository;
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
                SupplierName = commonRepository.GetSuppliersIdNames()[product.SupplierId],
                CategoryName = commonRepository.GetCategoriesIdNames()[product.CategoryId],
                GroupName = commonRepository.GetGroupsIdNames()[(int)product.GroupId] ?? "",
                UnitName = commonRepository.GetUnitsIdNames()[product.UnitId],
                NameWebStore = product.NameWebStore,
                NameSupplier = product.NameSupplier,
                CodeWebStore = product.CodeWebStore,
                CodeSupplier = product.CodeSupplier,
                PriceWebStore = product.PriceWebStore,
                PriceSupplier = product.PriceSupplier,
                Currency = commonRepository.GetSuppliersIdCurrencies()[product.SupplierId],
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
            Dictionary<int, string> suppliersIdNames = commonRepository.GetSuppliersIdNames();
            Dictionary<int, string> suppliersIdCurrencies = commonRepository.GetSuppliersIdCurrencies();
            Dictionary<int, string> categoriesIdNames = commonRepository.GetCategoriesIdNames();
            Dictionary<int, string> groupsIdNames = commonRepository.GetGroupsIdNames();
            Dictionary<int, string> unitsIdNames = commonRepository.GetUnitsIdNames();

            foreach (ProductsModel product in productsRepository.GetAll())
            {
                productsDtos.Add(new ProductsDtoModel
                {
                    Id = product.Id,
                    SupplierId = product.SupplierId,
                    SupplierName = suppliersIdNames[product.SupplierId],
                    CategoryId = product.CategoryId,
                    CategoryName = categoriesIdNames[product.CategoryId],
                    GroupId = product.GroupId ?? 0,
                    GroupName = product.GroupId == 0 ? "" : groupsIdNames[(int)product.GroupId],
                    UnitId = product.UnitId,
                    UnitName = unitsIdNames[product.UnitId],
                    NameWebStore = product.NameWebStore,
                    NameSupplier = product.NameSupplier,
                    CodeWebStore = product.CodeWebStore,
                    CodeSupplier = product.CodeSupplier,
                    PriceWebStore = product.PriceWebStore,
                    PriceSupplier = product.PriceSupplier,
                    Currency = suppliersIdCurrencies[product.SupplierId],
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
