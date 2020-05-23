using Services.ImagesServices;
using Services.ProductsServices;
using System.Collections.Generic;

namespace Services.Agents
{
    /// <summary>
    /// Інтерфейс постачальника зображень
    /// </summary>
    public interface IImagesAgent
    {
        /// <summary>
        /// Завантажує зображення з джерела постачальника
        /// </summary>
        /// <param name="productsWithoutImages">Список товарів</param>
        /// <param name="localFolderForImagesPath">Локальний каталог для завантаження зображень</param>
        /// <param name="isNeedtoLoadimages">Параметр, визначаючий чи потрібно завантажевати файли</param>
        /// <returns>Список зображень</returns>
        IEnumerable<ImagesDtoModel> GetExternalImages(IEnumerable<ProductsDtoModel> productsWithoutImages, string localFolderForImagesPath, bool isNeedtoLoadimages);
    }
}
