using System.Collections.Generic;
using Services.ProductsServices;
using Services.ParametersServices;
using System;

namespace Services.Agents
{
    /// <summary>
    /// Клас постачальника характеристик
    /// </summary>
    public class ParametersAgent : IParametersAgent
    {
        /// <summary>
        /// Завантажує характеристики з джерела постачальника
        /// </summary>
        /// <param name="productsWithoutParameters">Список товарів</param>
        /// <returns>Список характеристик товарів</returns>
        public IEnumerable<ParametersDtoModel> GetExternalParameters(IEnumerable<ProductsDtoModel> productsWithoutParameters)
        {
            throw new NotImplementedException();
        }
    }
}
