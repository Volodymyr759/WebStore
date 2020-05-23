using System;
using System.Collections.Generic;
using Domain.Models.Units;
using Services.Validators;

namespace Services.UnitsServices
{
    /// <summary>
    /// Клас сервісу одиниць виміру
    /// </summary>
    public class UnitsService : IUnitsService
    {
        IUnitsRepository unitsRepository;
        UnitsValidator unitsValidator = new UnitsValidator();

        /// <summary>
        /// Конструктор сервісу одиниць виміру
        /// </summary>
        /// <param name="unitsRepository">Екземпляр репозиторію одиниць виміру</param>
        public UnitsService(IUnitsRepository unitsRepository)
        {
            this.unitsRepository = unitsRepository;
        }

        /// <summary>
        /// Додає одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        public void AddUnit(UnitsDtoModel unitDto)
        {
            UnitsModel unit = new UnitsModel
            {
                Name = unitDto.Name,
                Notes = unitDto.Notes
            };
            var results = unitsValidator.Validate(unit);
            if (results.IsValid)
            {
                unitsRepository.Add(unit);
            }
            else
            {
                throw new Exception("Помилка валідації одиниці виміру: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }

        /// <summary>
        /// Видаляє одиницю виміру
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        public void DeleteUnitById(int id)
        {
            unitsRepository.DeleteById(id);
        }

        /// <summary>
        /// Повертає екземпляр одиниці виміру за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр категорії</returns>
        public UnitsDtoModel GetUnitById(int id)
        {
            var unit = unitsRepository.GetById(id);
            return new UnitsDtoModel { Id = unit.Id, Name = unit.Name, Notes = unit.Notes };
        }

        /// <summary>
        /// Повертає список одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        public IEnumerable<UnitsDtoModel> GetUnits()
        {
            List<UnitsDtoModel> unitsDtos = new List<UnitsDtoModel>();
            foreach (UnitsModel unit in unitsRepository.GetAll())
            {
                unitsDtos.Add(new UnitsDtoModel { Id = unit.Id, Name = unit.Name, Notes = unit.Notes });
            }

            return unitsDtos;
        }

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        public void UpdateUnit(UnitsDtoModel unitDto)
        {
            UnitsModel unit = new UnitsModel { Id = unitDto.Id, Name = unitDto.Name, Notes = unitDto.Notes };
            var results = unitsValidator.Validate(unit);
            if (results.IsValid)
            {
                unitsRepository.Update(unit);
            }
            else
            {
                throw new Exception("Помилка валідації одиниці виміру: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }
    }
}
