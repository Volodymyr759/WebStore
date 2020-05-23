using Services.ProductsServices;
using System.Collections.Generic;

namespace Services.ImagesServices
{
    /// <summary>
    /// Інтерфейс сервісу зображень
    /// </summary>
    public interface IImagesService
    {
        /// <summary>
        /// Додає зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        void AddImage(ImagesDtoModel imageDto);

        /// <summary>
        /// Видаляє зображення
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        void DeleteImageById(int id);

        /// <summary>
        /// Повертає список зображень
        /// </summary>
        /// <returns>Список зображень</returns>
        IEnumerable<ImagesDtoModel> GetImages();

        /// <summary>
        /// Повертає екземпляр зображення за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        ImagesDtoModel GetImageById(int id);

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        void UpdateImage(ImagesDtoModel imageDto);
    }
}
