using Domain.Models.Suppliers;
using System.Collections.Generic;

namespace Services.SuppliersServices
{
    /// <summary>
    /// Інтерфейс репозиторію постачальників
    /// </summary>
    public interface ISuppliersRepository
    {
        /// <summary>
        /// Додає постачальника
        /// </summary>
        /// <param name="suppliersModel">Екземпляр постачальника</param>
        void Add(ISuppliersModel suppliersModel);

        /// <summary>
        /// Оновлює постачальника
        /// </summary>
        /// <param name="suppliersModel">Екземпляр постачальника</param>
        void Update(ISuppliersModel suppliersModel);

        /// <summary>
        /// Видаляє постачальника
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        void DeleteById(int id);

        /// <summary>
        /// Повертає список усіх постачальників
        /// </summary>
        /// <returns>Список постачальників</returns>
        IEnumerable<ISuppliersModel> GetAll();

        /// <summary>
        /// Повертає постачальника по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        /// <returns>Екземпляр постачальника</returns>
        ISuppliersModel GetById(int id);
    }
}
