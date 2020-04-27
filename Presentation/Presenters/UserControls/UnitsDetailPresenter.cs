using Common;
using Domain.Models.Units;
using Presentation;
using Presentation.Validators;
using Presentation.Views.UserControls;
using Services.UnitsService;
using System;
using System.Collections.Generic;

namespace Presentation
{
    /// <summary>
    /// Презентер для форми вводу даних створення/редагування одиниці виміру
    /// </summary>
    public class UnitsDetailPresenter : BasePresenter, IUnitsDetailPresenter
    {
        private IUnitsDetailUC unitsDetaileUC;

        private IUnitsService unitsService;

        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Подія готовності форми вводу даних для відображення у головній формі
        /// </summary>
        public event EventHandler ReadyToShowUnitsDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження одиниці виміру
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Конструктор презентера форми вводу даних одиниці виміру
        /// </summary>
        /// <param name="unitsDetaileUC">Форма вводу даних одиниці виміру</param>
        /// <param name="unitsService">Сервіс-рівень одиниці виміру</param>
        /// <param name="errorMessageView">Форма для відображення помилки</param>
        public UnitsDetailPresenter(IUnitsDetailUC unitsDetaileUC, IUnitsService unitsService, IErrorMessageView errorMessageView) : base(errorMessageView)
        {
            this.unitsDetaileUC = unitsDetaileUC;
            this.unitsService = unitsService;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            unitsDetaileUC.SaveUnitsDetailEventRaised += (sender, modelDictionary) =>
            {
                UnitsModel unitsModel = new UnitsModel
                {
                    Id = int.Parse(modelDictionary.ModelDictionary["Id"]),
                    Name = modelDictionary.ModelDictionary["Name"],
                    Notes = modelDictionary.ModelDictionary["Notes"]
                };
                var unitsValidator = new UnitsValidator();
                if (unitsValidator.Validate(unitsModel).IsValid)
                {
                    if (unitsModel.Id > 0) unitsService.Update(unitsModel); else unitsService.Add(unitsModel);
                }
            };
            unitsDetaileUC.CancelUnitsDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Отримання форми вводу даних одиниці виміру головною формою
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування одиниці виміру</returns>
        public IUnitsDetailUC GetUnitsDetailUC()
        {
            return unitsDetaileUC;
        }

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
            UnitsModel unitsModel = (UnitsModel)unitsService.GetById(id);
            Dictionary<string, string> modelDictionary = BuildModelDictionary(unitsModel);
            unitsDetaileUC.SetupControls(modelDictionary);
            EventHelper.RaiseEvent(this, ReadyToShowUnitsDetailEventRaised, new EventArgs());
        }

        private Dictionary<string, string> BuildModelDictionary(UnitsModel unitsModel)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", unitsModel.Id.ToString() },
                { "Name", unitsModel.Name },
                { "Notes", unitsModel.Notes }
            };

            return modelDictionary;
        }
    }
}
