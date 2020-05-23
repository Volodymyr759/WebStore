using Services.GroupsServices;
using Services.ProductsServices;
using System.Collections.Generic;
using System.Text;

namespace Services.Agents
{
    /// <summary>
    /// Інтерфейс експорту товарів і категорій в Csv - файл 
    /// </summary>
    public interface ISaverToCsvAgent
    {
        /// <summary>
        /// Повертає текст для збереження в Csv - файлі
        /// </summary>
        /// <param name="productsDtos">Список товарів</param>
        /// <param name="groupsDtos">Список категорій</param>
        /// <returns>StringBuilder - текст для збереження в Csv - файлі</returns>
        StringBuilder ExportToFile(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<GroupsDtoModel> groupsDtos);

        /// <summary>
        /// Повертає список застарілих (неіснуючих на сайті постачальника) товарів
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <returns>StringBuilder - текст для збереження в Csv - файлі</returns>
        StringBuilder ExportOldProducts(IEnumerable<ProductsDtoModel> productsDtos);
    }
}
