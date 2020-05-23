using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.ParametersServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення деталей характеристики товару
    /// </summary>
    public class ParametersDetailPresenter : IParametersDetailPresenter
    {
        private IParametersDetailUC parametersDetailUC;

        private IStoreFacade facade;

        BindingSource bindingSourceProductsIdNameModel;

        BindingSource bindingSourceUnitsIdNameModel;

        /// <summary>
        /// Подія готовності для відображення у головній формі
        /// </summary>
        public event EventHandler ReadyToShowParametersDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження характеристики товару
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраної характеристики товару
        /// </summary>
        public event EventHandler SaveParameterClickEventRaised;

        /// <summary>
        /// Конструктор презентера представлення деталей характеристики товару
        /// </summary>
        /// <param name="parametersDetailUC">Екземпляр представлення деталей характеристики товару</param>
        /// <param name="facade">Екземпляр фасаду</param>
        public ParametersDetailPresenter(IParametersDetailUC parametersDetailUC, IStoreFacade facade)
        {
            this.parametersDetailUC = parametersDetailUC;
            this.facade = facade;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            parametersDetailUC.SaveParametersDetailEventRaised += (sender, modelDictionary) =>
             {
                 ParametersDtoModel parameterDto = new ParametersDtoModel
                 {
                     Id = modelDictionary.ModelDictionary["Id"] == "" ? 0 : int.Parse(modelDictionary.ModelDictionary["Id"]),
                     ProductId = int.Parse(modelDictionary.ModelDictionary["ProductId"]),
                     ProductName = modelDictionary.ModelDictionary["ProductName"],
                     Name = modelDictionary.ModelDictionary["Name"],
                     UnitId = int.Parse(modelDictionary.ModelDictionary["UnitId"]),
                     UnitName = modelDictionary.ModelDictionary["UnitName"],
                     Value = modelDictionary.ModelDictionary["Value"],
                 };
                 if (parameterDto.Id > 0) facade.UpdateParameter(parameterDto); else facade.AddParameter(parameterDto);

                 EventHelper.RaiseEvent(this, SaveParameterClickEventRaised, new EventArgs());
             };

            parametersDetailUC.CancelParametersDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування характеристики
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування характеристики</returns>
        public IParametersDetailUC GetParametersDetailUC() => parametersDetailUC;

        /// <summary>
        /// Налаштування форми вводу даних для створення нової характеристики
        /// </summary>
        public void SetupParametersDetailForAdd()
        {
            PrepareBindings();
            parametersDetailUC.ResetControls(bindingSourceProductsIdNameModel, bindingSourceUnitsIdNameModel);
            EventHelper.RaiseEvent(this, ReadyToShowParametersDetailEventRaised, new EventArgs());
        }

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючої характеристики
        /// </summary>
        /// <param name="id">id існуючої характеристики</param>
        public void SetupParametersDetailForEdit(int id)
        {
            PrepareBindings();
            Dictionary<string, string> modelDictionary = BuildModelDictionary(facade.GetParameterById(id));
            parametersDetailUC.SetupControls(modelDictionary, bindingSourceProductsIdNameModel, bindingSourceUnitsIdNameModel);
            EventHelper.RaiseEvent(this, ReadyToShowParametersDetailEventRaised, new EventArgs());
        }

        private Dictionary<string, string> BuildModelDictionary(ParametersDtoModel parametersDtoModel)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", parametersDtoModel.Id.ToString() },
                { "Name", parametersDtoModel.Name },
                { "ProductName", parametersDtoModel.ProductName },
                { "UnitName", parametersDtoModel.UnitName },
                { "Value", parametersDtoModel.Value }
            };
            return modelDictionary;
        }

        private void PrepareBindings()
        {
            bindingSourceProductsIdNameModel = new BindingSource { DataSource = facade.GetProductsDto() };
            bindingSourceUnitsIdNameModel = new BindingSource { DataSource = facade.GetUnitsDto() };
        }
    }
}
