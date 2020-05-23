using Services.CategoriesServices;
using Services.ProductsServices;
using System;
using System.Collections.Generic;

namespace Services.Agents
{
    /// <summary>
    /// Інтерфейс Xml-постачальника товарів
    /// </summary>
    public class ProductsXmlAgent : IProductsAgent
    {
        List<ProductsDtoModel> listOfResultsProductsDtos;

        /// <summary>
        /// Завантажує нові товари
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список нових товарів</returns>
        public IEnumerable<ProductsDtoModel> GetNewProducts(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає список застарілих товарів
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список відсутніх у постачальника товарів</returns>
        public IEnumerable<ProductsDtoModel> GetOldProducts(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає список товарів з оновленими значеннями наявності
        /// </summary>
        /// <param name="productsDtos">Список наявних товарів</param>
        /// <returns>Список товарів з оновленими значеннями наявності</returns>
        public IEnumerable<ProductsDtoModel> CheckAvailability(IEnumerable<ProductsDtoModel> productsDtos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає список товарів з оновленими цінами
        /// </summary>
        /// <param name="productsDtos">Список наявних товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список товарів з оновленими цінами</returns>
        public IEnumerable<ProductsDtoModel> CheckPrices(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos)
        {
            throw new NotImplementedException();
        }
    }
}
