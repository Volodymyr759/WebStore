using Domain.Models.Groups;
using System.Collections.Generic;

namespace Services.GroupsServices
{
    /// <summary>
    /// Інтерфейс репозиторію груп товарів
    /// </summary>
    public interface IGroupsRepository
    {
        /// <summary>
        /// Додає групу
        /// </summary>
        /// <param name="groupsModel">Екземпляр групи</param>
        void Add(IGroupsModel groupsModel);

        /// <summary>
        /// Оновлює групу
        /// </summary>
        /// <param name="groupsModel">Екземпляр групи</param>
        void Update(IGroupsModel groupsModel);

        /// <summary>
        /// Видаляє групу
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        void DeleteById(int id);

        /// <summary>
        /// Повертає список усіх груп
        /// </summary>
        /// <returns>Список груп</returns>
        IEnumerable<IGroupsModel> GetAll();

        /// <summary>
        /// Повертає групу по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        /// <returns>Екземпляр групи</returns>
        IGroupsModel GetById(int id);
    }
}
