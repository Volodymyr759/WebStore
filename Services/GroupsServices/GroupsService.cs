using System;
using System.Collections.Generic;
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
            GroupsModel group = new GroupsModel
            {
                Id = groupDto.Id,
                Name = groupDto.Name,
                Number = groupDto.Number,
                Identifier = groupDto.Identifier,
                AncestorNumber = groupDto.AncestorNumber,
                AncestorIdentifier = groupDto.AncestorIdentifier,
                ProductType = groupDto.ProductType,
                Link = groupDto.Link,
                Notes = groupDto.Notes
            };
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
        public void DeleteGroupById(int id)
        {
            groupsRepository.DeleteById(id);
        }

        /// <summary>
        /// Повертає екземпляр групи за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        /// <returns>Екземпляр групи</returns>
        public GroupsDtoModel GetGroupById(int id)
        {
            var group = groupsRepository.GetById(id);
            return new GroupsDtoModel
            {
                Id = group.Id,
                Name = group.Name,
                Number = group.Number,
                Identifier = group.Identifier,
                AncestorNumber = group.AncestorNumber,
                AncestorIdentifier = group.AncestorIdentifier,
                ProductType = group.ProductType,
                Link = group.Link,
                Notes = group.Notes
            };
        }

        /// <summary>
        /// Повертає список груп
        /// </summary>
        /// <returns>Список груп</returns>
        public IEnumerable<GroupsDtoModel> GetGroups()
        {
            List<GroupsDtoModel> groupsDtos = new List<GroupsDtoModel>();
            foreach (GroupsModel group in groupsRepository.GetAll())
            {
                groupsDtos.Add(new GroupsDtoModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    Number = group.Number,
                    Identifier = group.Identifier,
                    AncestorNumber = group.AncestorNumber,
                    AncestorIdentifier = group.AncestorIdentifier,
                    ProductType = group.ProductType,
                    Link = group.Link,
                    Notes = group.Notes
                });
            }
            return groupsDtos;
        }

        /// <summary>
        /// Оновлює групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        public void UpdateGroup(GroupsDtoModel groupDto)
        {
            GroupsModel group = new GroupsModel
            {
                Id = groupDto.Id,
                Name = groupDto.Name,
                Number = groupDto.Number,
                Identifier = groupDto.Identifier,
                AncestorNumber = groupDto.AncestorNumber,
                AncestorIdentifier = groupDto.AncestorIdentifier,
                ProductType = groupDto.ProductType,
                Link = groupDto.Link,
                Notes = groupDto.Notes
            };
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
