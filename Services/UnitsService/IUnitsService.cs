using Domain.Models.Units;
using System.Collections.Generic;

namespace Services.UnitsService
{
    public interface IUnitsService
    {
        void Add(IUnitsModel unitsModel);
        void DeleteById(int id);
        IEnumerable<IUnitsModel> GetUnitsToList();
        IUnitsModel GetById(int id);
        void Update(IUnitsModel unitsModel);
    }
}
