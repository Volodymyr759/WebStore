using System;
using Presentation.Views.UserControls;
using Services.GroupsServices;
using Common;
using System.Collections.Generic;
using Services;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення деталей груп власного каталогу
    /// </summary>
    public class GroupsDetailPresenter : IGroupsDetailPresenter
    {
        private IGroupsDetailUC groupsDetailUC;

        private IStoreFacade facade;

        /// <summary>
        /// Подія готовності до відображення представлення деталей групи власного каталогу
        /// </summary>
        public event EventHandler ReadyToShowGroupsDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей групи власного каталогу
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису у представленні деталей групи власного каталогу
        /// </summary>
        public event EventHandler SaveGroupClickEventRaised;

        /// <summary>
        /// Конструктор презентера представлення деталей групи власного каталогу
        /// </summary>
        /// <param name="groupsDetailUC">Екземпляр деталей групи власного каталогу</param>
        /// <param name="facade">Екземпляр фасаду</param>
        public GroupsDetailPresenter(IGroupsDetailUC groupsDetailUC, IStoreFacade facade)
        {
            this.groupsDetailUC = groupsDetailUC;
            this.facade = facade;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            groupsDetailUC.SaveGroupsDetailEventRaised += (sender, modelDictionary) =>
            {
                GroupsDtoModel groupDto = new GroupsDtoModel
                {
                    Id = modelDictionary.ModelDictionary["Id"] == "" ? 0 : int.Parse(modelDictionary.ModelDictionary["Id"]),
                    Name = modelDictionary.ModelDictionary["Name"],
                    Number = modelDictionary.ModelDictionary["Number"],
                    Identifier = modelDictionary.ModelDictionary["Identifier"],
                    AncestorNumber = modelDictionary.ModelDictionary["AncestorNumber"],
                    AncestorIdentifier = modelDictionary.ModelDictionary["AncestorIdentifier"],
                    ProductType = modelDictionary.ModelDictionary["ProductType"],
                    Link = modelDictionary.ModelDictionary["Link"],
                    Notes = modelDictionary.ModelDictionary["Notes"]
                };
                if (groupDto.Id > 0) facade.UpdateGroup(groupDto); else facade.AddGroup(groupDto);
                EventHelper.RaiseEvent(this, SaveGroupClickEventRaised, new EventArgs());
            };

            groupsDetailUC.CancelGroupsDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Повертає екземпляр представлення деталей обраної групи власного каталогу
        /// </summary>
        /// <returns>Екземпляр представлення деталей групи власного каталогу</returns>
        public IGroupsDetailUC GetGroupsDetailUC() => groupsDetailUC;

        /// <summary>
        /// Налаштовує екземпляр представлення деталей обраної групи власного каталогу для створення нової групи
        /// </summary>
        public void SetupGroupsDetailForAdd()
        {
            groupsDetailUC.ResetControls();
            EventHelper.RaiseEvent(this, ReadyToShowGroupsDetailEventRaised, new EventArgs());
        }

        /// <summary>
        /// Налаштовує екземпляр представлення деталей групи власного каталогу для редагування обраної групи
        /// </summary>
        /// <param name="id">Ідентифікатор обраної групи</param>
        public void SetupGroupsDetailForEdit(int id)
        {
            Dictionary<string, string> modelDictionary = BuildModelDictionary(facade.GetGroupById(id));
            groupsDetailUC.SetupControls(modelDictionary);
            EventHelper.RaiseEvent(this, ReadyToShowGroupsDetailEventRaised, new EventArgs()); ;
        }

        private Dictionary<string, string> BuildModelDictionary(GroupsDtoModel model)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", model.Id.ToString() },
                { "Name", model.Name },
                { "Number", model.Number },
                { "Identifier", model.Identifier },
                { "AncestorNumber", model.AncestorNumber },
                { "AncestorIdentifier", model.AncestorIdentifier },
                { "ProductType", model.ProductType },
                { "Link", model.Link },
                { "Notes", model.Notes }
            };
            return modelDictionary;
        }
    }
}
