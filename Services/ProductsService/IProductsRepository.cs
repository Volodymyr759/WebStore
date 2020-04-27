using Domain.Models.Products;
using System.Collections.Generic;

namespace Services.ProductsService
{
    public interface IProductsRepository
    {
        void Add(IProductsModel productsModel);
        void Update(IProductsModel productsModel);
        void DeleteById(int id);
        IEnumerable<ProductsDtoModel> GetAll();
        ProductsModel GetById(int id);
    }
}
