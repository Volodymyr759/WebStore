using System;
using System.Collections.Generic;
using Domain.Models.Groups;
using Services.GroupsService;

namespace DataAccess.RepositoriesSqlCE
{
    public class GroupsRepository : IGroupsRepository
    {
        public void Add(IGroupsModel groupsModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGroupsModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public GroupsModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IGroupsModel groupsModel)
        {
            throw new NotImplementedException();
        }
    }
}
