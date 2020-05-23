using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HtmlAgilityPack;
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
        /// Конструктор постачальника зображень
        /// </summary>
        public ImagesAgent()
        {
        }

        /// <summary>
        /// Завантажує зображення з джерела постачальника
        /// </summary>
        /// <param name="productsWithoutImages">Список товарів</param>
        /// <param name="localFolderForImagesPath">Локальний каталог для завантаження зображень</param>
        /// <param name="isNeedtoLoadimages">Параметр, визначаючий чи потрібно завантажевати файли</param>
        /// <returns>Список зображень</returns>
        public IEnumerable<ImagesDtoModel> GetExternalImages(IEnumerable<ProductsDtoModel> productsWithoutImages, string localFolderForImagesPath, bool isNeedtoLoadimages)
        {
            try
            {
                List<ImagesDtoModel> imagesDtos = new List<ImagesDtoModel>();
                foreach (ProductsDtoModel productsDto in productsWithoutImages)
                {
                    HtmlDocument document = new HtmlWeb().Load(productsDto.LinkSupplier);
                    // ImageList - на сторінці товару 1 фото
                    HtmlNode workNode = document.DocumentNode.SelectSingleNode("//div[@id='tovar_img']/img");
                    if (workNode != null)
                        if (workNode != null)
                        {
                            ImagesDtoModel imagesDto = new ImagesDtoModel
                            {
                                ProductId = productsDto.Id,
                                ProductName = productsDto.NameSupplier,
                                LinkSupplier = workNode.Attributes["src"].Value.ToString(),
                            };
                            string s = imagesDto.LinkSupplier;
                            imagesDto.FileName = s.Substring(s.LastIndexOf("/") + 1);
                            imagesDto.LocalPath = Path.Combine(localFolderForImagesPath, imagesDto.FileName);
                            if (isNeedtoLoadimages)
                            {
                                using (WebClient client = new WebClient())
                                {
                                    client.DownloadFileAsync(new Uri(s),
                                        Path.Combine(localFolderForImagesPath, imagesDto.FileName));
                                }
                            }
                            imagesDtos.Add(imagesDto);
                        }
                }
                return imagesDtos;
            }
            catch
            {
                throw new Exception("Помилка отримання зображень товарів.");
            }
        }
    }
}
