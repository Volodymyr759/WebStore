using Domain.Models.Units;
using System.Collections.Generic;

namespace Services.UnitsServices
{
    /// <summary>
    /// Інтерфейс репозиторію одиниць виміру
    /// </summary>
    public interface IUnitsRepository
    {
        /// <summary>
        /// Додає одиницю виміру
        /// </summary>
        /// <param name="unitsModel">Екземпляр одиниці виміру</param>
        void Add(IUnitsModel unitsModel);

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitsModel">Екземпляр одиниці виміру</param>
        void Update(IUnitsModel unitsModel);

        /// <summary>
        /// Видаляє одиницю виміру
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        void DeleteById(int id);

        /// <summary>
        /// Повертає список усіх одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        IEnumerable<IUnitsModel> GetAll();

        /// <summary>
        /// Повертає одиницю виміру по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр одиниці виміру</returns>
        IUnitsModel GetById(int id);
    }
}
