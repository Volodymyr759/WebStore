using System;
using System.Collections.Generic;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.SuppliersServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення деталей постачальника
    /// </summary>
    public class SuppliersDetailPresenter : ISuppliersDetailPresenter
    {
        private ISuppliersDetailUC suppliersDetailUC;
        private IStoreFacade facade;

        /// <summary>
        /// Подія готовності для відображення у головній формі
        /// </summary>
        public event EventHandler ReadyToShowSuppliersDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження постачальника
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраного постачальника
        /// </summary>
        public event EventHandler SaveSupplierClickEventRaised;

        /// <summary>
        /// Конструктор презентера представлення деталей постачальника
        /// </summary>
        /// <param name="suppliersDetailUC">Екземпляр представлення деталей постачальника</param>
        /// <param name="facade">Екземпляр фасаду</param>
        public SuppliersDetailPresenter(ISuppliersDetailUC suppliersDetailUC, IStoreFacade facade)
        {
            this.suppliersDetailUC = suppliersDetailUC;
            this.facade = facade;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            suppliersDetailUC.SaveSuppliersDetailEventRaised += (sender, modelDictionary) =>
            {
                SuppliersDtoModel supplierDto = new SuppliersDtoModel()
                {
                    Id = modelDictionary.ModelDictionary["Id"] == "" ? 0 : int.Parse(modelDictionary.ModelDictionary["Id"]),
                    Name = modelDictionary.ModelDictionary["Name"],
                    Link = modelDictionary.ModelDictionary["Link"],
                    Currency = modelDictionary.ModelDictionary["Currency"],
                    Notes = modelDictionary.ModelDictionary["Notes"]
                };
                if (supplierDto.Id > 0) facade.UpdateSupplier(supplierDto); else facade.AddSupplier(supplierDto);

                EventHelper.RaiseEvent(this, SaveSupplierClickEventRaised, new EventArgs());
            };

            suppliersDetailUC.CancelSuppliersDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування постачальника
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування постачальника</returns>
        public ISuppliersDetailUC GetSuppliersDetailUC() => suppliersDetailUC;

        /// <summary>
        /// Налаштування форми вводу даних для створення нового постачальника
        /// </summary>
        public void SetupSuppliersDetailForAdd()
        {
            suppliersDetailUC.ResetControls();
            EventHelper.RaiseEvent(this, ReadyToShowSuppliersDetailEventRaised, new EventArgs());
        }

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючого постачальника
        /// </summary>
        /// <param name="id">id існуючого постачальника</param>
        public void SetupSuppliersDetailForEdit(int id)
        {
            SuppliersDtoModel supplierDto = facade.GetSupplierById(id);
            Dictionary<string, string> modelDictionary = BuildModelDictionary(supplierDto);
            suppliersDetailUC.SetupControls(modelDictionary);
            EventHelper.RaiseEvent(this, ReadyToShowSuppliersDetailEventRaised, new EventArgs());
        }

        private Dictionary<string, string> BuildModelDictionary(SuppliersDtoModel supplierDto)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", supplierDto.Id.ToString() },
                { "Name", supplierDto.Name },
                { "Link", supplierDto.Link },
                { "Currency", supplierDto.Currency },
                { "Notes", supplierDto.Notes }
            };

            return modelDictionary;
        }
    }
}
