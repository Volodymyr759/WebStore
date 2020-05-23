using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.GroupsServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер груп власного каталогу
    /// </summary>
    public class GroupsPresenter : IGroupsPresenter
    {
        private IGroupsUC groupsUC;

        private IGroupsDetailPresenter groupsDetailPresenter;

        private IStoreFacade facade;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Подія зміни посилання на сторінку обраної групи
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Конструктор представлення груп власного каталогу
        /// </summary>
        /// <param name="groupsUC">Екземпляр представлення списку груп власного каталогу</param>
        /// <param name="groupsDetailPresenter">Екземпляр презентера представлення деталей обраної групи</param>
        /// <param name="facade">Екземпляр фасаду</param>
        /// <param name="deleteConfirmView">Екземпляр універсальної форми відображення підтвердження видалення запису</param>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення повідомлення про помилку</param>
        public GroupsPresenter(IGroupsUC groupsUC,
            IGroupsDetailPresenter groupsDetailPresenter,
            IStoreFacade facade,
            IDeleteConfirmView deleteConfirmView,
            IErrorMessageView errorMessageView)
        {
            this.groupsUC = groupsUC;
            this.groupsDetailPresenter = groupsDetailPresenter;
            this.facade = facade;
            this.deleteConfirmView = deleteConfirmView;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        /// <summary>
        /// Повертає екземпляр представлення відображення списку груп власного каталогу
        /// </summary>
        /// <returns>Екземпляр представлення списку груп</returns>
        public IGroupsUC GetGroupsUC()
        {
            groupsUC.SetupControls(BuildDataSource());
            return groupsUC;
        }

        private void SubscribeToEvents()
        {
            groupsUC.AddNewGroupEventRaised += (sender, e) => groupsDetailPresenter.SetupGroupsDetailForAdd();

            groupsUC.EditGroupEventRaised += (sender, e) =>
            {
                GroupsDtoModel groupDto = (GroupsDtoModel)bindingSource.Current;
                groupsDetailPresenter.SetupGroupsDetailForEdit(groupDto.Id);
            };

            groupsUC.DeleteGroupEventRaised += (sender, e) =>
            {
                GroupsDtoModel groupDto = (GroupsDtoModel)bindingSource.Current;
                deleteConfirmView.ShowDeleteConfirmMessageView("Видалення групи товарів",
                    $"Підтвердіть видалення групи товарів: { groupDto.Name }.", groupDto.Id, "GroupsUC");
            };

            groupsUC.LinkToSearchChangedInUCEventRaised += (sender, modelDictionary) =>
                EventHelper.RaiseEvent(this, LinkToSearchChangedEventRaised, modelDictionary);

            groupsUC.SortGroupsByBindingPropertyNameEventRaised += (sender, sortParameters) =>
               OnSortGroupsByBindingPropertyNameEventRaised(sender, sortParameters);
        }

        private void OnSortGroupsByBindingPropertyNameEventRaised(object sender, DataEventArgs sortParameters)
        {
            var groupsDtos = facade.GetGroupsDto();
            switch (sortParameters.ModelDictionary["PropertyName"])
            {
                case "Name":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.Name) :
                        groupsDtos.OrderByDescending(g => g.Name);
                    break;
                case "Number":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.Number) :
                        groupsDtos.OrderByDescending(g => g.Number);
                    break;
                case "Identifier":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.Identifier) :
                        groupsDtos.OrderByDescending(g => g.Identifier);
                    break;
                case "AncestorNumber":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.AncestorNumber) :
                        groupsDtos.OrderByDescending(g => g.AncestorNumber);
                    break;
                case "AncestorIdentifier":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.AncestorIdentifier) :
                        groupsDtos.OrderByDescending(g => g.AncestorIdentifier);
                    break;
                case "ProductType":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.ProductType) :
                        groupsDtos.OrderByDescending(g => g.ProductType);
                    break;
                case "Link":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.Link) :
                        groupsDtos.OrderByDescending(g => g.Link);
                    break;
                case "Notes":
                    groupsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? groupsDtos.OrderBy(g => g.Notes) :
                        groupsDtos.OrderByDescending(g => g.Notes);
                    break;
            }
            bindingSource.DataSource = groupsDtos;
            groupsUC.SetupControls(bindingSource);
        }

        private BindingSource BuildDataSource()
        {
            var bindingList = new BindingList<GroupsDtoModel>();
            foreach (GroupsDtoModel groupDto in facade.GetGroupsDto()) bindingList.Add(groupDto);
            bindingSource = new BindingSource { DataSource = bindingList };
            return bindingSource;
        }
    }
}
