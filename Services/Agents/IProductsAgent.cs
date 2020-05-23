using Services.CategoriesServices;
using Services.ProductsServices;
using System.Collections.Generic;

namespace Services.Agents
{
    /// <summary>
    /// Інтерфейс постачальника товарів
    /// </summary>
    public interface IProductsAgent
    {
        /// <summary>
        /// Завантажує нові товари
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список нових товарів</returns>
        IEnumerable<ProductsDtoModel> GetNewProducts(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos);

        /// <summary>
        /// Повертає список застарілих товарів
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список відсутніх у постачальника товарів</returns>
        IEnumerable<ProductsDtoModel> GetOldProducts(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos);

        /// <summary>
        /// Повертає список товарів з оновленими значеннями наявності
        /// </summary>
        /// <param name="productsDtos">Список наявних товарів</param>
        /// <returns>Список товарів з оновленими значеннями наявності</returns>
        IEnumerable<ProductsDtoModel> CheckAvailability(IEnumerable<ProductsDtoModel> productsDtos);

        /// <summary>
        /// Повертає список товарів з оновленими цінами
        /// </summary>
        /// <param name="productsDtos">Список наявних товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список товарів з оновленими цінами</returns>
        IEnumerable<ProductsDtoModel> CheckPrices(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos);
    }
}
