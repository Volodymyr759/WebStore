using Domain.Models.Groups;
using System.Collections.Generic;

namespace Services.GroupsService
{
    public interface IGroupsRepository
    {
        void Add(IGroupsModel groupsModel);
        void Update(IGroupsModel groupsModel);
        void DeleteById(int id);
        IEnumerable<IGroupsModel> GetAll();
        GroupsModel GetById(int id);
    }
}
