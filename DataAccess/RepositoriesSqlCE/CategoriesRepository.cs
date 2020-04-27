using System;
using System.Collections.Generic;
using Domain.Models.Categories;
using Services.CategoriesService;

namespace DataAccess.RepositoriesSqlCE
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public void Add(ICategoriesModel categoriesModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriesDtoModel> GetAll()
        {
            //select * from Categories as c join Suppliers as s on c.SupplierId = s.Id order by c.Name
            throw new NotImplementedException();
        }

        public CategoriesModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ICategoriesModel categoriesModel)
        {
            throw new NotImplementedException();
        }
    }
}
