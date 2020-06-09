using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Models.Groups;
using Services.Validators;

namespace Services.GroupsServices
{
    /// <summary>
    /// Клас сервісу груп
    /// </summary>
    public class GroupsService : IGroupsService
    {
        IGroupsRepository groupsRepository;
        GroupsValidator groupsValidator = new GroupsValidator();

        /// <summary>
        /// Конструктор сервісу груп
        /// </summary>
        /// <param name="groupsRepository">Екземпляр репозиторію груп</param>
        public GroupsService(IGroupsRepository groupsRepository)
        {
            this.groupsRepository = groupsRepository;
        }

        /// <summary>
        /// Додає групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        public void AddGroup(GroupsDtoModel groupDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupsDtoModel, GroupsModel>()).CreateMapper();
            GroupsModel group = mapper.Map<GroupsModel>(groupDto);

            var results = groupsValidator.Validate(group);
            if (results.IsValid)
            {
                groupsRepository.Add(group);
            }
            else
            {
                throw new System.Exception("Помилка валідації групи товарів:" + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }

        /// <summary>
        /// Видаляє групу
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        public void DeleteGroupById(int id) => groupsRepository.DeleteById(id);

        /// <summary>
        /// Повертає екземпляр групи за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        /// <returns>Екземпляр групи</returns>
        public GroupsDtoModel GetGroupById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupsModel, GroupsDtoModel>()).CreateMapper();
            
            return mapper.Map<GroupsDtoModel>(groupsRepository.GetById(id));
        }

        /// <summary>
        /// Повертає список груп
        /// </summary>
        /// <returns>Список груп</returns>
        public IEnumerable<GroupsDtoModel> GetGroups()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupsModel, GroupsDtoModel>()).CreateMapper();
            return mapper.Map<IEnumerable<GroupsDtoModel>>(groupsRepository.GetAll());
        }

        /// <summary>
        /// Оновлює групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        public void UpdateGroup(GroupsDtoModel groupDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupsDtoModel, GroupsModel>()).CreateMapper();
            GroupsModel group = mapper.Map<GroupsModel>(groupDto);

            var results = groupsValidator.Validate(group);
            if (results.IsValid)
            {
                groupsRepository.Update(group);
            }
            else
            {
                throw new System.Exception("Помилка валідації групи товарів: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }
    }
}
