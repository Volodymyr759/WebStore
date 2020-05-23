using Common;
using Presentation.Views.UserControls;
using Services;
using Services.UnitsServices;
using System;
using System.Collections.Generic;

namespace Presentation
{
    /// <summary>
    /// Презентер для форми вводу даних створення/редагування одиниці виміру
    /// </summary>
    public class UnitsDetailPresenter : IUnitsDetailPresenter
    {
        private IUnitsDetailUC unitsDetaileUC;

        private IStoreFacade facade;

        /// <summary>
        /// Подія готовності форми вводу даних для відображення у головній формі
        /// </summary>
        public event EventHandler ReadyToShowUnitsDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження одиниці виміру
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраної одиниці виміру
        /// </summary>
        public event EventHandler SaveUnitClickEventRaised;

        /// <summary>
        /// Конструктор презентера форми вводу даних одиниці виміру
        /// </summary>
        /// <param name="unitsDetaileUC">Форма вводу даних одиниці виміру</param>
        /// <param name="facade">Екземпляр фасаду</param>
        public UnitsDetailPresenter(IUnitsDetailUC unitsDetaileUC, IStoreFacade facade)
        {
            this.unitsDetaileUC = unitsDetaileUC;
            this.facade = facade;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            unitsDetaileUC.SaveUnitsDetailEventRaised += (sender, modelDictionary) =>
            {
                UnitsDtoModel unitDto = new UnitsDtoModel
                {
                    Id = modelDictionary.ModelDictionary["Id"] == "" ? 0 : int.Parse(modelDictionary.ModelDictionary["Id"]),
                    Name = modelDictionary.ModelDictionary["Name"],
                    Notes = modelDictionary.ModelDictionary["Notes"]
                };
                if (unitDto.Id > 0) facade.UpdateUnit(unitDto); else facade.AddUnit(unitDto);

                EventHelper.RaiseEvent(this, SaveUnitClickEventRaised, new EventArgs());
            };

            unitsDetaileUC.CancelUnitsDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Отримання форми вводу даних одиниці виміру головною формою
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування одиниці виміру</returns>
        public IUnitsDetailUC GetUnitsDetailUC() => unitsDetaileUC;

        /// <summary>
        /// Ініціалізація елементів форми вводу даних для створення нової одиниці виміру
        /// </summary>
        public void SetupUnitsDetailForAdd()
        {
            unitsDetaileUC.ResetControls();
            EventHelper.RaiseEvent(this, ReadyToShowUnitsDetailEventRaised, new EventArgs());
        }

        /// <summary>
        /// Ініціалізація елементів форми вводу даних для редагування існуючої одиниці виміру
        /// </summary>
        /// <param name="id">id існуючої одиниці виміру</param>
        public void SetupUnitsDetailForEdit(int id)
        {
            Dictionary<string, string> modelDictionary = BuildModelDictionary(facade.GetUnitById(id));
            unitsDetaileUC.SetupControls(modelDictionary);
            EventHelper.RaiseEvent(this, ReadyToShowUnitsDetailEventRaised, new EventArgs());
        }

        private Dictionary<string, string> BuildModelDictionary(UnitsDtoModel unitDto)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", unitDto.Id.ToString() },
                { "Name", unitDto.Name },
                { "Notes", unitDto.Notes }
            };

            return modelDictionary;
        }
    }
}
