using System;
using System.Collections.Generic;
using AutoMapper;
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UnitsDtoModel, UnitsModel>()).CreateMapper();
            UnitsModel unit = mapper.Map<UnitsModel>(unitDto);

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
        public void DeleteUnitById(int id) => unitsRepository.DeleteById(id);

        /// <summary>
        /// Повертає екземпляр одиниці виміру за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр категорії</returns>
        public UnitsDtoModel GetUnitById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UnitsModel, UnitsDtoModel>()).CreateMapper();

            return mapper.Map<UnitsDtoModel>(unitsRepository.GetById(id));
        }

        /// <summary>
        /// Повертає список одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        public IEnumerable<UnitsDtoModel> GetUnits()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UnitsModel, UnitsDtoModel>()).CreateMapper();

            return mapper.Map<IEnumerable<UnitsDtoModel>>(unitsRepository.GetAll());
        }

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        public void UpdateUnit(UnitsDtoModel unitDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UnitsDtoModel, UnitsModel>()).CreateMapper();
            UnitsModel unit = mapper.Map<UnitsModel>(unitDto);

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
