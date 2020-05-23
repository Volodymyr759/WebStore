using Services.SuppliersServices;
using System.Collections.Generic;

namespace Services.CategoriesServices
{
    /// <summary>
    /// Інтерфейс сервісу категорій
    /// </summary>
    public interface ICategoriesService
    {
        /// <summary>
        /// Додає категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        void AddCategory(CategoriesDtoModel categoryDto);

        /// <summary>
        /// Видаляє категорію
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        void DeleteCategoryById(int id);

        /// <summary>
        /// Повертає список категорій Dto
        /// </summary>
        /// <returns>Список категорій</returns>
        IEnumerable<CategoriesDtoModel> GetCategories();

        /// <summary>
        /// Повертає екземпляр категорії за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        CategoriesDtoModel GetCategoryById(int id);

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        void UpdateCategory(CategoriesDtoModel categoryDto);
    }
}
