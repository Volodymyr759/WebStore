using Domain.Models.Parameters;
using System.Collections.Generic;

namespace Services.ParametersServices
{
    /// <summary>
    /// Інтерфейс репозиторію характеристик товару
    /// </summary>
    public interface IParametersRepository
    {
        /// <summary>
        /// Додає характеристику товару
        /// </summary>
        /// <param name="parametersModel">Екземпляр характеристики товару</param>
        void Add(IParametersModel parametersModel);

        /// <summary>
        /// Оновлює характеристику товару
        /// </summary>
        /// <param name="parametersModel">Екземпляр характеристики товару</param>
        void Update(IParametersModel parametersModel);

        /// <summary>
        /// Видаляє характеристику товару
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики товару</param>
        void DeleteById(int id);

        /// <summary>
        /// Повертає список усіх характеристик товару
        /// </summary>
        /// <returns>Список характеристик товару</returns>
        IEnumerable<IParametersModel> GetAll();

        /// <summary>
        /// Повертає характеристику товару по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики товару</param>
        /// <returns>Екземпляр характеристики товару</returns>
        IParametersModel GetById(int id);
    }
}
