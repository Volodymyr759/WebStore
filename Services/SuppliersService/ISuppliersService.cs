using Domain.Models.Suppliers;
using System.Collections.Generic;

namespace Services.SuppliersService
{
    public interface ISuppliersService
    {
        void Add(ISuppliersModel suppliersModel);
        void DeleteById(int id);
        List<ISuppliersModel> GetSuppliersToList();
        ISuppliersModel GetById(int id);
        void Update(ISuppliersModel suppliersModel);
    }
}
