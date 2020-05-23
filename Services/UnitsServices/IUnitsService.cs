using System.Collections.Generic;

namespace Services.UnitsServices
{
    /// <summary>
    /// Інтерфейс сервісу одиниць виміру
    /// </summary>
    public interface IUnitsService
    {
        /// <summary>
        /// Додає одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        void AddUnit(UnitsDtoModel unitDto);

        /// <summary>
        /// Видаляє одиницю виміру
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        void DeleteUnitById(int id);

        /// <summary>
        /// Повертає список одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        IEnumerable<UnitsDtoModel> GetUnits();

        /// <summary>
        /// Повертає екземпляр одиниці виміру за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр категорії</returns>
        UnitsDtoModel GetUnitById(int id);

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        void UpdateUnit(UnitsDtoModel unitDto);
    }
}
