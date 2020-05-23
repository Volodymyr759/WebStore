using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HtmlAgilityPack;
using Services.CategoriesServices;
using Services.ProductsServices;

namespace Services.Agents
{
    /// <summary>
    /// Клас для парсингу товарів Одеса-Люстри
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
            try
            {
                listOfResultsProductsDtos = new List<ProductsDtoModel>();
                foreach (CategoriesDtoModel category in categoriesDtos)
                {
                    foreach (string link in GetProductLinksByCategory(category))
                    {
                        if (productsDtos.Where(p => p.LinkSupplier == link).FirstOrDefault() == null)
                        {
                            ProductsDtoModel productDto = new ProductsDtoModel
                            {
                                NameWebStore = "Новий товар",
                                NameSupplier = "",
                                SupplierId = category.SupplierId,
                                SupplierName = category.SupplierName,
                                CategoryId = category.Id,
                                CategoryName = category.Name,
                                GroupName = "",
                                UnitName = "",
                                CodeWebStore = "",
                                CodeSupplier = "",
                                PriceWebStore = 0,
                                PriceSupplier = 0,
                                Currency = "UAH",
                                Available = "-",
                                LinkWebStore = "",
                                LinkSupplier = link,
                                Notes = "",
                            };
                            productDto = ParseProductByLink(productDto);
                            if (productDto.PriceSupplier > 0) productDto.PriceWebStore = productDto.PriceSupplier * category.Rate;
                            listOfResultsProductsDtos.Add(productDto);
                        }
                    }
                }
                return listOfResultsProductsDtos;
            }
            catch
            {
                throw new Exception("Помилка отримання нових товарів.");
            }
        }

        /// <summary>
        /// Повертає список застарілих товарів
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список відсутніх у постачальника товарів</returns>
        public IEnumerable<ProductsDtoModel> GetOldProducts(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos)
        {
            try
            {
                List<ProductsDtoModel> listOfResultsProductsDtos = productsDtos.ToList();
                foreach (CategoriesDtoModel category in categoriesDtos)
                {
                    foreach (string link in GetProductLinksByCategory(category))
                    {
                        ProductsDtoModel productDto = listOfResultsProductsDtos.Where(l => l.LinkSupplier == link).FirstOrDefault();
                        if (productDto != null) listOfResultsProductsDtos.Remove(productDto);
                    }
                }
                return listOfResultsProductsDtos;
            }
            catch
            {
                throw new Exception("Помилка отримання застарілих товарів.");
            }
        }

        /// <summary>
        /// Повертає список товарів з оновленими значеннями наявності
        /// </summary>
        /// <param name="productsDtos">Список наявних товарів</param>
        /// <returns>Список товарів з оновленими значеннями наявності</returns>
        public IEnumerable<ProductsDtoModel> CheckAvailability(IEnumerable<ProductsDtoModel> productsDtos)
        {
            try
            {
                foreach (ProductsDtoModel productsDto in productsDtos)
                {
                    HtmlDocument document = new HtmlWeb().Load(productsDto.LinkSupplier);
                    string availability = GetAvailability(document.DocumentNode.SelectSingleNode("//div[3]/div[1]/div[2]/div[2]"));
                    productsDto.Available = availability;
                }
                return productsDtos;
            }
            catch
            {
                throw new Exception("Помилка перевірки наявності товарів.");
            }
        }

        /// <summary>
        /// Повертає список товарів з оновленими цінами
        /// </summary>
        /// <param name="productsDtos">Список наявних товарів</param>
        /// <param name="categoriesDtos">Список категорій</param>
        /// <returns>Список товарів з оновленими цінами</returns>
        public IEnumerable<ProductsDtoModel> CheckPrices(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<CategoriesDtoModel> categoriesDtos)
        {
            try
            {
                foreach (ProductsDtoModel productsDto in productsDtos)
                {
                    HtmlDocument document = new HtmlWeb().Load(productsDto.LinkSupplier);
                    decimal actualPrice = GetPrice(document.DocumentNode.SelectSingleNode("//div[3]/div[1]/div[2]/div[1]"));
                    if (productsDto.PriceSupplier != actualPrice)
                    {
                        productsDto.PriceSupplier = actualPrice;
                        productsDto.PriceWebStore = actualPrice * categoriesDtos.Where(c => c.Id == productsDto.CategoryId).FirstOrDefault().Rate;
                    }
                }
                return productsDtos;
            }
            catch
            {
                throw new Exception("Помилка перевірки цін товарів.");
            }
        }

        private List<string> GetProductLinksByCategory(CategoriesDtoModel category)
        {
            List<string> links = new List<string>();
            HtmlDocument document = new HtmlWeb().Load(category.Link);
            links.AddRange(document.DocumentNode
                                .SelectNodes(".//div[@class='tovar']/a[1]")
                                .Select(a => a.Attributes["href"].Value).Distinct());
            return links;
        }

        private ProductsDtoModel ParseProductByLink(ProductsDtoModel item)
        {
            HtmlDocument document = new HtmlWeb().Load(item.LinkSupplier);
            // Name
            HtmlNode workNode = document.DocumentNode.SelectSingleNode("//div[3]/div[1]/h2");
            if (workNode != null) item.NameSupplier = workNode.InnerText.Trim();
            // Price 
            item.PriceSupplier = GetPrice(document.DocumentNode.SelectSingleNode("//div[3]/div[1]/div[2]/div[1]"));
            // Description 
            HtmlNode[] groupNodes = document.DocumentNode.SelectNodes(".//div[@class='text-block']/p").ToArray();
            string desc_text = "";
            if (groupNodes.Count() > 0) foreach (HtmlNode node in groupNodes) desc_text += node.InnerText.Replace("  ", " ")
                        .Replace("\n", "").Replace(";", "").Replace("&nbsp", "").Trim();
            item.Notes = (desc_text.Length >= 500) ? desc_text.Substring(0, 499) : desc_text;
            // Available 
            item.Available = GetAvailability(document.DocumentNode.SelectSingleNode("//div[3]/div[1]/div[2]/div[2]"));
            item.UnitName = "шт.";

            return item;
        }

        private decimal GetPrice(HtmlNode workNode)
        {
            decimal price = 0;
            if (workNode != null)
            {
                string _price = workNode.InnerText.Replace("Розничная цена:", "").Replace("грн.Ваша цена:", "").Trim();
                decimal.TryParse(_price, NumberStyles.None, CultureInfo.CurrentCulture, out price);
            }
            return price;
        }

        private string GetAvailability(HtmlNode workNode)
        {
            string availability = "-";
            if (workNode != null) availability = (workNode.InnerText.Contains("Есть")) ? "+" : "-";

            return availability;
        }
    }
}
