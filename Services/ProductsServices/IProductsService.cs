using System.Collections.Generic;

namespace Services.ProductsServices
{
    /// <summary>
    /// Інтерфейс сервісу товарів
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Додає товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        void AddProduct(ProductsDtoModel productDto);

        /// <summary>
        /// Видаляє товар
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        void DeleteProductById(int id);

        /// <summary>
        /// Повертає список товарів
        /// </summary>
        /// <returns>Список товарів</returns>
        IEnumerable<ProductsDtoModel> GetProducts();

        /// <summary>
        /// Повертає екземпляр товару за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        /// <returns>Екземпляр товару</returns>
        ProductsDtoModel GetProductById(int id);

        /// <summary>
        /// Оновлює товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        void UpdateProduct(ProductsDtoModel productDto);

    }
}
