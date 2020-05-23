using Services.GroupsServices;
using Services.ParametersServices;
using Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Services.Agents
{
    /// <summary>
    /// Клас експорту товарів, категорій і характеристик в Xml - файл
    /// </summary>
    public class SaverToXmlAgent : ISaverToXmlAgent
    {
        /// <summary>
        /// Повертає Xml - документ для збереження в Xml - файлі
        /// </summary>
        /// <param name="productsDtos">Список товарів</param>
        /// <param name="groupsDtos">Список груп</param>
        /// <param name="parametersDtos">Список характеристик товарів</param>
        /// <returns>Xml - документ для збереження в Xml - файл</returns>
        public XDocument ExportToFile(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<GroupsDtoModel> groupsDtos,
            IEnumerable<ParametersDtoModel> parametersDtos)
        {
            throw new NotImplementedException();
        }
    }
}
