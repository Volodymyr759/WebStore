using Domain.Models.Categories;
using System.Collections.Generic;

namespace Services.CategoriesServices
{
    /// <summary>
    /// Інтерфейс репозиторію категорій
    /// </summary>
    public interface ICategoriesRepository
    {
        /// <summary>
        /// Додає категорію
        /// </summary>
        /// <param name="categoriesModel">Екземпляр категорії</param>
        void Add(ICategoriesModel categoriesModel);

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoriesModel">Екземпляр категорії</param>
        void Update(ICategoriesModel categoriesModel);

        /// <summary>
        /// Видаляє категорію
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        void DeleteById(int id);

        /// <summary>
        /// Повертає список усіх категорій
        /// </summary>
        /// <returns>Список категорій</returns>
        IEnumerable<ICategoriesModel> GetAll();

        /// <summary>
        /// Повертає категорію по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        ICategoriesModel GetById(int id);
    }
}
