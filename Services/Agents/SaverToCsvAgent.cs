using Services.GroupsServices;
using Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Agents
{
    /// <summary>
    /// Клас експорту товарів і категорій в Csv - файл
    /// </summary>
    public class SaverToCsvAgent : ISaverToCsvAgent
    {
        /// <summary>
        /// Повертає текст для збереження в Csv - файлі
        /// </summary>
        /// <param name="productsDtos">Список товарів</param>
        /// <param name="groupsDtos">Список категорій</param>
        /// <returns>StringBuilder - текст для збереження в Csv - файлі</returns>
        public StringBuilder ExportToFile(IEnumerable<ProductsDtoModel> productsDtos,
            IEnumerable<GroupsDtoModel> groupsDtos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає список застарілих (неіснуючих на сайті постачальника) товарів
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <returns>StringBuilder - текст для збереження в Csv - файлі</returns>
        public StringBuilder ExportOldProducts(IEnumerable<ProductsDtoModel> productsDtos)
        {
            throw new NotImplementedException();
        }
    }
}
