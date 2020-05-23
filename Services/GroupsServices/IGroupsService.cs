using System.Collections.Generic;

namespace Services.GroupsServices
{
    /// <summary>
    /// Інтерфейс сервісу груп
    /// </summary>
    public interface IGroupsService
    {
        /// <summary>
        /// Додає групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        void AddGroup(GroupsDtoModel groupDto);

        /// <summary>
        /// Видаляє групу
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        void DeleteGroupById(int id);

        /// <summary>
        /// Повертає список груп
        /// </summary>
        /// <returns>Список груп</returns>
        IEnumerable<GroupsDtoModel> GetGroups();

        /// <summary>
        /// Повертає екземпляр групи за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        /// <returns>Екземпляр групи</returns>
        GroupsDtoModel GetGroupById(int id);

        /// <summary>
        /// Оновлює групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        void UpdateGroup(GroupsDtoModel groupDto);
    }
}
