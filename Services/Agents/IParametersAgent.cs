using Services.ParametersServices;
using Services.ProductsServices;
using System.Collections.Generic;

namespace Services.Agents
{
    /// <summary>
    /// Інтерфейс постачальника характеристик
    /// </summary>
    public interface IParametersAgent
    {
        /// <summary>
        /// Завантажує характеристики з джерела постачальника
        /// </summary>
        /// <param name="productsWithoutParameters">Список товарів</param>
        /// <returns>Список характеристик товарів</returns>
        IEnumerable<ParametersDtoModel> GetExternalParameters(IEnumerable<ProductsDtoModel> productsWithoutParameters);
    }
}
