using Domain.Models.Images;
using System.Collections.Generic;

namespace Services.ImagesServices
{
    /// <summary>
    /// Інтерфейс репозиторію зображень
    /// </summary>
    public interface IImagesRepository
    {
        /// <summary>
        /// Додає зображення
        /// </summary>
        /// <param name="imagesModel">Екземпляр зображення</param>
        void Add(IImagesModel imagesModel);

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imagesModel">Екземпляр зображення</param>
        void Update(IImagesModel imagesModel);

        /// <summary>
        /// Видаляє зображення
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        void DeleteById(int id);

        /// <summary>
        /// Повертає список усіх зображень
        /// </summary>
        /// <returns>Список зображень</returns>
        IEnumerable<IImagesModel> GetAll();

        /// <summary>
        /// Повертає зображення по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        IImagesModel GetById(int id);
    }
}
