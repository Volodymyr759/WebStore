using Domain.Models.Products;
using System.Collections.Generic;

namespace Services.ProductsService
{
    public interface IProductsService
    {
        void Add(IProductsModel productsModel);
        void DeleteById(int id);
        List<ProductsDtoModel> GetProductsToList();
        IProductsModel GetById(int id);
        void Update(IProductsModel productsModel);
    }
}
