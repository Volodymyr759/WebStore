using System;
using System.Collections.Generic;
using Domain.Models.Units;

namespace Services.UnitsService
{
    public class UnitsService : IUnitsService
    {
        IUnitsRepository unitsRepository;

        public UnitsService(IUnitsRepository unitsRepository)
        {
            this.unitsRepository = unitsRepository;
        }

        public void Add(IUnitsModel unitsModel)
        {
            unitsRepository.Add(unitsModel);
        }

        public void DeleteById(int id)
        {
            unitsRepository.DeleteById(id);
        }

        public IUnitsModel GetById(int id)
        {
            return unitsRepository.GetById(id);
        }

        public IEnumerable<IUnitsModel> GetUnitsToList()
        {
            return unitsRepository.GetAll();
        }

        public void Update(IUnitsModel unitsModel)
        {
            unitsRepository.Update(unitsModel);
        }
    }
}
