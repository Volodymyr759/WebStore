using Domain.Models.Groups;
using System.Collections.Generic;

namespace Services.GroupsService
{
    public interface IGroupsService
    {
        void Add(IGroupsModel groupsModel);
        void DeleteById(int id);
        List<IGroupsModel> GetGroupsToList();
        IGroupsModel GetById(int id);
        void Update(IGroupsModel groupsModel);
    }
}
