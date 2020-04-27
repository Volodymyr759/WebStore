using Domain.Models.Categories;
using System.Collections.Generic;

namespace Services.CategoriesService
{
    public interface ICategoriesRepository
    {
        void Add(ICategoriesModel categoriesModel);
        void Update(ICategoriesModel categoriesModel);
        void DeleteById(int id);
        IEnumerable<CategoriesDtoModel> GetAll();
        CategoriesModel GetById(int id);
    }
}
