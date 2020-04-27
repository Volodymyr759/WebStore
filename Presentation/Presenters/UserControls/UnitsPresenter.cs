using Domain.Models.Units;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Presentation.Views.UserControls;
using Services.UnitsService;
using System.ComponentModel;

namespace Presentation
{
    /// <summary>
    /// Презентер форми списку одиниць виміру
    /// </summary>
    public class UnitsPresenter : BasePresenter, IUnitsPresenter
    {
        private IUnitsUC unitsUC;

        private IUnitsDetailPresenter unitsDetailPresenter;

        private IUnitsService unitsService;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="unitsUC">Форма списку одиниць виміру</param>
        /// <param name="unitsService">сервіс-рівень для одиниць виміру</param>
        /// <param name="unitsDetailPresenter">презентер форми створення/редагування одиниці виміру</param>
        /// <param name="deleteConfirmView">форма підтвердження видалення</param>
        /// <param name="errorMessageView">форма повідомлення про помилку</param>
        public UnitsPresenter(IUnitsUC unitsUC,
                              IUnitsService unitsService,
                              IUnitsDetailPresenter unitsDetailPresenter,
                              IDeleteConfirmView deleteConfirmView,
                              IErrorMessageView errorMessageView) : base(errorMessageView)
        {
            this.unitsUC = unitsUC;
            this.unitsService = unitsService;
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
                UnitsModel UnitsModel = (UnitsModel)bindingSource.Current;
                unitsDetailPresenter.SetupUnitsDetailForEdit(UnitsModel.Id);
            };

            unitsUC.DeleteUnitEventRaised += (sender, e) =>
            {
                UnitsModel UnitsModel = (UnitsModel)bindingSource.Current;
                deleteConfirmView.ShowDeleteConfirmMessageView("Видалення одиниці виміру",
                    $"Підтвердіть видалення одиниці виміру: { UnitsModel.Name }.", UnitsModel.Id);
            };

            deleteConfirmView.DeleteConfirmViewOKEventRaised += (sender, e) =>
            {
                try
                {  
                    unitsService.DeleteById(deleteConfirmView.GetIdToDelete());
                }
                catch (Exception Ex)
                {
                    ShowErrorMessage("Помилка видалення одиниці виміру", Ex.StackTrace);
                }
            };
        }

        private BindingSource BuildDataSource()
        {
            IEnumerable<IUnitsModel> unitsModels = unitsService.GetUnitsToList();
            var bindingList = new BindingList<UnitsModel>();
            foreach (UnitsModel unit in unitsModels) bindingList.Add(unit);

            return new BindingSource { DataSource = bindingList };
        }
    }
}
