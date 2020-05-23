using Services.GroupsServices;
using Services.ParametersServices;
using Services.ProductsServices;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Services.Agents
{
    /// <summary>
    /// Інтерфейс експорту товарів, категорій і характеристик в Xml - файл 
    /// </summary>
    public interface ISaverToXmlAgent
    {
        /// <summary>
        /// Повертає Xml - документ для збереження в Xml - файлі
        /// </summary>
        /// <param name="productsDtos">Список товарів</param>
        /// <param name="groupsDtos">Список груп</param>
        /// <param name="parametersDtos">Список характеристик товарів</param>
        /// <returns>Xml - документ для збереження в Xml - файл</returns>
        XDocument ExportToFile(IEnumerable<ProductsDtoModel> productsDtos,
            IEnumerable<GroupsDtoModel> groupsDtos,
            IEnumerable<ParametersDtoModel> parametersDtos);
    }
}
