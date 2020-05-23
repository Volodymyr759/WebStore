using System.Windows.Forms;
using Presentation.Views.UserControls;
using Services.UnitsServices;
using System.ComponentModel;
using Services;
using Common;
using System.Linq;

namespace Presentation
{
    /// <summary>
    /// Презентер форми списку одиниць виміру
    /// </summary>
    public class UnitsPresenter : IUnitsPresenter
    {
        private IUnitsUC unitsUC;

        private IUnitsDetailPresenter unitsDetailPresenter;

        private IStoreFacade facade;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitsUC">Форма списку одиниць виміру</param>
        /// <param name="facade">Екземпляр фасаду</param>
        /// <param name="unitsDetailPresenter">Презентер форми створення/редагування одиниці виміру</param>
        /// <param name="deleteConfirmView">Екземпляр форми підтвердження видалення</param>
        /// <param name="errorMessageView">Екземпляр форми повідомлення про помилку</param>
        public UnitsPresenter(IUnitsUC unitsUC,
                              IStoreFacade facade,
                              IUnitsDetailPresenter unitsDetailPresenter,
                              IDeleteConfirmView deleteConfirmView,
                              IErrorMessageView errorMessageView)
        {
            this.unitsUC = unitsUC;
            this.facade = facade;
            this.unitsDetailPresenter = unitsDetailPresenter;
            this.deleteConfirmView = deleteConfirmView;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        /// <summary>
        /// Отримання форми списку одиниць виміру головною формою
        /// </summary>
        /// <returns>Форма списку одиниць виміру</returns>
        public IUnitsUC GetUnitsUC()
        {
            unitsUC.SetupControls(BuildDataSource());
            return unitsUC;
        }

        private void SubscribeToEvents()
        {
            unitsUC.AddNewUnitEventRaised += (sender, e) => unitsDetailPresenter.SetupUnitsDetailForAdd();

            unitsUC.EditUnitEventRaised += (sender, e) =>
            {
                UnitsDtoModel unitDto = (UnitsDtoModel)bindingSource.Current;
                unitsDetailPresenter.SetupUnitsDetailForEdit(unitDto.Id);
            };

            unitsUC.DeleteUnitEventRaised += (sender, e) =>
            {
                UnitsDtoModel unitDto = (UnitsDtoModel)bindingSource.Current;
                deleteConfirmView.ShowDeleteConfirmMessageView("Видалення одиниці виміру",
                    $"Підтвердіть видалення одиниці виміру: { unitDto.Name }.", unitDto.Id, "UnitsUC");
            };

            unitsUC.SortUnitsByBindingPropertyNameEventRaised += (sender, sortParameters) =>
              OnSortUnitsByBindingPropertyNameEventRaised(sender, sortParameters);
        }

        private BindingSource BuildDataSource()
        {
            var bindingList = new BindingList<UnitsDtoModel>();
            foreach (UnitsDtoModel unit in facade.GetUnitsDto()) bindingList.Add(unit);
            bindingSource = new BindingSource { DataSource = bindingList };
            return bindingSource;
        }

        private void OnSortUnitsByBindingPropertyNameEventRaised(object sender, DataEventArgs sortParameters)
        {
            var unitsDtos = facade.GetUnitsDto();
            switch (sortParameters.ModelDictionary["PropertyName"])
            {
                case "Name":
                    unitsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? unitsDtos.OrderBy(u => u.Name) :
                        unitsDtos.OrderByDescending(u => u.Name);
                    break;
                case "Notes":
                    unitsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? unitsDtos.OrderBy(u => u.Notes) :
                        unitsDtos.OrderByDescending(u => u.Notes);
                    break;
            }
            bindingSource.DataSource = unitsDtos;
            unitsUC.SetupControls(bindingSource);
        }
    }
}
