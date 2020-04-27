using Domain.Models.Categories;
using System.Collections.Generic;

namespace Services.CategoriesService
{
    public interface ICategoriesService
    {
        void Add(ICategoriesModel categoriesModel);
        void DeleteById(int id);
        List<CategoriesDtoModel> GetCategoriesToList();
        ICategoriesModel GetById(int id);
        void Update(ICategoriesModel categoriesModel);
    }
}
