using System.Collections.Generic;

namespace Services.Agents
{
    /// <summary>
    /// Фабричний клас створення агентів-постачальників
    /// </summary>
    public class FactoryAgents
    {
        /// <summary>
        /// Повертає екземпляр Api-постачальника
        /// </summary>
        /// <returns>Екземпляр Api-постачальника</returns>
        public static ProductsApiAgent GetProductsApiAgent() => new ProductsApiAgent();

        /// <summary>
        /// Повертає екземпляр Html-постачальника
        /// </summary>
        /// <returns>Екземпляр Html-постачальника</returns>
        public static ProductsHtmlAgent GetProductsHtmlAgent() => new ProductsHtmlAgent();

        /// <summary>
        /// Повертає екземпляр Xml-постачальника
        /// </summary>
        /// <returns>Екземпляр Xml-постачальника</returns>
        public static ProductsXmlAgent GetProductsXmlAgent() => new ProductsXmlAgent();

        /// <summary>
        /// Повертає список постачальників
        /// </summary>
        /// <returns>Список постачальників</returns>
        public static List<IProductsAgent> GetListProductsAgents() => new List<IProductsAgent> { new ProductsApiAgent(), new ProductsHtmlAgent(), new ProductsXmlAgent() };
    }
}
