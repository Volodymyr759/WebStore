using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.ParametersServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення списку характеристик товару
    /// </summary>
    public class ParametersPresenter : IParametersPresenter
    {
        private IParametersUC parametersUC;

        private IParametersDetailPresenter parametersDetailPresenter;

        private IStoreFacade facade;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Конструктор презентера представлення списку характеристик товару
        /// </summary>
        /// <param name="parametersUC">Екземпляр представлення списку характеристик товару</param>
        /// <param name="parametersDetailPresenter">Екземпляр презентера представлення деталей характеристики товару</param>
        /// <param name="facade">Екземпляр фасаду</param>
        /// <param name="deleteConfirmView">Екземпляр універсальної форми підтвердження видалення запису</param>
        /// <param name="errorMessageView">Екземпляр універсальної форми повідомлення про помилку</param>
        public ParametersPresenter(
            IParametersUC parametersUC, 
            IParametersDetailPresenter parametersDetailPresenter, 
            IStoreFacade facade,
            IDeleteConfirmView deleteConfirmView, 
            IErrorMessageView errorMessageView)
        {
            this.parametersUC = parametersUC;
            this.parametersDetailPresenter = parametersDetailPresenter;
            this.facade = facade;
            this.deleteConfirmView = deleteConfirmView;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            parametersUC.AddNewParameterEventRaised += (sender, e) => parametersDetailPresenter.SetupParametersDetailForAdd();

            parametersUC.EditParameterEventRaised += (sender, e) =>
            {
                ParametersDtoModel parametersDtoModel = (ParametersDtoModel)bindingSource.Current;
                parametersDetailPresenter.SetupParametersDetailForEdit(parametersDtoModel.Id);
            };

            parametersUC.DeleteParameterEventRaised += (sender, e) =>
            {
                ParametersDtoModel parametersDtoModel = (ParametersDtoModel)bindingSource.Current;
                deleteConfirmView.ShowDeleteConfirmMessageView("Видалення характеристики",
                    $"Підтвердіть видалення характеристики: { parametersDtoModel.Name }.", parametersDtoModel.Id, "ParametersUC");
            };

            parametersUC.SortParametersByBindingPropertyNameEventRaised += (sender, sortParameters) =>
               OnSortParametersByBindingPropertyNameEventRaised(sender, sortParameters);
        }

        private void OnSortParametersByBindingPropertyNameEventRaised(object sender, DataEventArgs sortParameters)
        {
            var paramsDtos = facade.GetParametersDto();
            switch (sortParameters.ModelDictionary["PropertyName"])
            {
                case "Name":
                    paramsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? paramsDtos.OrderBy(p => p.Name) :
                        paramsDtos.OrderByDescending(p => p.Name);
                    break;
                case "ProductName":
                    paramsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? paramsDtos.OrderBy(p => p.ProductName) :
                        paramsDtos.OrderByDescending(p => p.ProductName);
                    break;
                case "UnitName":
                    paramsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? paramsDtos.OrderBy(p => p.UnitName) :
                        paramsDtos.OrderByDescending(p => p.UnitName);
                    break;
                case "Value":
                    paramsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? paramsDtos.OrderBy(p => p.Value) :
                        paramsDtos.OrderByDescending(p => p.Value);
                    break;
            }
            bindingSource.DataSource = paramsDtos;
            parametersUC.SetupControls(bindingSource);
        }

        /// <summary>
        /// Повертає екземпляр представлення списку характеристик товару
        /// </summary>
        /// <returns>Екземпляр представлення категорій постачальників</returns>
        public IParametersUC GetParametersUC()
        {
            parametersUC.SetupControls(BuildDataSource(facade.GetParametersDto()));
            return parametersUC;
        }

        /// <summary>
        /// Завантаження характеристик товарів з джерел постачальників
        /// </summary>
        /// <returns>Екземпляр представлення категорій постачальників</returns>
        public IParametersUC LoadParameters()
        {
            facade.GetExternalParameters();
            parametersUC.SetupControls(BuildDataSource(facade.GetParametersDto()));
            return GetParametersUC();
        }

        private BindingSource BuildDataSource(IEnumerable<ParametersDtoModel> parametersDtos)
        {
            var bindingList = new BindingList<ParametersDtoModel>();
            foreach (ParametersDtoModel parameter in parametersDtos) bindingList.Add(parameter);
            bindingSource = new BindingSource { DataSource = bindingList };
            return bindingSource;
        }
    }
}
