using System.Collections.Generic;

namespace Services.ParametersServices
{
    /// <summary>
    /// Інтерфейс сервісу характеристик
    /// </summary>
    public interface IParametersService
    {
        /// <summary>
        /// Додає характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        void AddParameter(ParametersDtoModel parameterDto);

        /// <summary>
        /// Видаляє характеристику
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        void DeleteParameterById(int id);

        /// <summary>
        /// Повертає список характеристик
        /// </summary>
        /// <returns>Список характеристик</returns>
        IEnumerable<ParametersDtoModel> GetParameters();

        /// <summary>
        /// Повертає екземпляр характеристики за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        /// <returns>Екземпляр характеристики</returns>
        ParametersDtoModel GetParameterById(int id);

        /// <summary>
        /// Оновлює характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        void UpdateParameter(ParametersDtoModel parameterDto);
    }
}
