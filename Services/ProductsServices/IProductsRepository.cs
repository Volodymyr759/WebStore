using Domain.Models.Products;
using System.Collections.Generic;

namespace Services.ProductsServices
{
    /// <summary>
    /// Інтерфейс репозиторію товарів
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Додає товар
        /// </summary>
        /// <param name="productsModel">Екземпляр товару</param>
        void Add(IProductsModel productsModel);

        /// <summary>
        /// Оновлює товар
        /// </summary>
        /// <param name="productsModel">Екземпляр товару</param>
        void Update(IProductsModel productsModel);

        /// <summary>
        /// Видаляє товар
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        void DeleteById(int id);

        /// <summary>
        /// Повертає список усіх товарів
        /// </summary>
        /// <returns>Список товарів</returns>
        IEnumerable<IProductsModel> GetAll();

        /// <summary>
        /// Повертає товар по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        /// <returns>Екземпляр товару</returns>
        IProductsModel GetById(int id);
    }
}
