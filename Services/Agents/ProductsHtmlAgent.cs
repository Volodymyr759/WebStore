using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Services.CategoriesServices;
using Services.ProductsServices;

namespace Services.Agents
{
    /// <summary>
    /// Клас для парсингу товарів
    /// </summary>
    public class ProductsHtmlAgent : IProductsAgent
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

        #region Helpers

        private List<string> GetProductLinksByCategory(CategoriesDtoModel category)
        {
            throw new NotImplementedException();
        }

        private ProductsDtoModel ParseProductByLink(ProductsDtoModel item)
        {
            throw new NotImplementedException();
        }

        private decimal GetPrice(HtmlNode workNode)
        {
            throw new NotImplementedException();
        }

        private string GetAvailability(HtmlNode workNode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
