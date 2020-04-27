using Domain.Models.Suppliers;
using System.Collections.Generic;

namespace Services.SuppliersService
{
    public interface ISuppliersRepository
    {
        void Add(ISuppliersModel suppliersModel);
        void Update(ISuppliersModel suppliersModel);
        void DeleteById(int id);
        IEnumerable<ISuppliersModel> GetAll();
        SuppliersModel GetById(int id);
    }
}
