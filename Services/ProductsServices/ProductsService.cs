using System;
using System.Collections.Generic;
using AutoMapper;
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductsDtoModel, ProductsModel>()).CreateMapper();
            ProductsModel product = mapper.Map<ProductsModel >(productDto);

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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductsModel, ProductsDtoModel>()).CreateMapper();
            ProductsDtoModel productDto = mapper.Map<ProductsDtoModel>(product);
            productDto.SupplierName = commonRepository.GetSuppliersIdNames()[product.SupplierId];
            productDto.CategoryName = commonRepository.GetCategoriesIdNames()[product.CategoryId];
            productDto.GroupName = commonRepository.GetGroupsIdNames()[(int)product.GroupId] ?? "";
            productDto.UnitName = commonRepository.GetUnitsIdNames()[product.UnitId];

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

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductsModel, ProductsDtoModel>()).CreateMapper();

            foreach (ProductsModel product in productsRepository.GetAll())
            {
                ProductsDtoModel productsDto = mapper.Map<ProductsDtoModel>(product);
                productsDto.SupplierName = suppliersIdNames[product.SupplierId];
                productsDto.CategoryName = categoriesIdNames[product.CategoryId];
                productsDto.GroupName = product.GroupId == 0 ? "" : groupsIdNames[(int)product.GroupId];
                productsDto.UnitName = unitsIdNames[product.UnitId];
                productsDtos.Add(productsDto);
            }

            return productsDtos;
        }

        /// <summary>
        /// Оновлює товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        public void UpdateProduct(ProductsDtoModel productDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductsDtoModel, ProductsModel>()).CreateMapper();
            ProductsModel product = mapper.Map<ProductsModel>(productDto);

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
