using System;
using System.Collections.Generic;
using Domain.Models.Products;
using Services.ProductsService;

namespace DataAccess.RepositoriesSqlCE
{
    public class ProductsRepository : IProductsRepository
    {
        public void Add(IProductsModel productsModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsDtoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductsModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IProductsModel productsModel)
        {
            throw new NotImplementedException();
        }
    }
}
