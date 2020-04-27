using Domain.Models.Units;
using System.Collections.Generic;

namespace Services.UnitsService
{
    public interface IUnitsRepository
    {
        void Add(IUnitsModel unitsModel);
        void Update(IUnitsModel unitsModel);
        void DeleteById(int id);
        IEnumerable<IUnitsModel> GetAll();
        UnitsModel GetById(int id);
    }
}
