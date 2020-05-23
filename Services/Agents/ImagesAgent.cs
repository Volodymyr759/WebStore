using System;
using System.Collections.Generic;
using Services.ImagesServices;
using Services.ProductsServices;

namespace Services.Agents
{
    /// <summary>
    /// Клас постачальника зображень
    /// </summary>
    public class ImagesAgent : IImagesAgent
    {

        /// <summary>
        /// Завантажує зображення з джерела постачальника
        /// </summary>
        /// <param name="productsWithoutImages">Список товарів</param>
        /// <param name="localFolderForImagesPath">Локальний каталог для завантаження зображень</param>
        /// <param name="isNeedtoLoadimages">Параметр, визначаючий чи потрібно завантажевати файли</param>
        /// <returns>Список зображень</returns>
        public IEnumerable<ImagesDtoModel> GetExternalImages(IEnumerable<ProductsDtoModel> productsWithoutImages, string localFolderForImagesPath, bool isNeedtoLoadimages)
        {
            throw new NotImplementedException();
        }
    }
}
