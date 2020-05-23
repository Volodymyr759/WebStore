using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.CategoriesServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення деталей категорії постачальника
    /// </summary>
    public class CategoriesDetailPresenter : ICategoriesDetailPresenter
    {
        private ICategoriesDetailUC categoriesDetailUC;

        private IStoreFacade facade;

        /// <summary>
        /// Подія повідомлення про готовність до відображення представлення деталей категорій постачальника
        /// </summary>
        public event EventHandler ReadyToShowCategoriesDetailEventRaised;

        /// <summary>
        /// Подія відміни в представленні деталей категорії постачальника
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження в представленні деталей категорії постачальника
        /// </summary>
        public event EventHandler SaveCategoryClickEventRaised;

        /// <summary>
        /// Конструктор представлення деталей категорії постачальника
        /// </summary>
        /// <param name="categoriesDetailUC">Екземпляр представлення деталей категорії постачальника</param>
        /// <param name="facade">Екземпляр фасаду</param>
        public CategoriesDetailPresenter(ICategoriesDetailUC categoriesDetailUC, IStoreFacade facade)
        {
            this.categoriesDetailUC = categoriesDetailUC;
            this.facade = facade;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            categoriesDetailUC.SaveCategoriesDetailEventRaised += (sender, modelDictionary) =>
            {
                CategoriesDtoModel category = new CategoriesDtoModel()
                {
                    Id = modelDictionary.ModelDictionary["Id"] == "" ? 0 : int.Parse(modelDictionary.ModelDictionary["Id"]),
                    Name = modelDictionary.ModelDictionary["Name"],
                    SupplierId = int.Parse(modelDictionary.ModelDictionary["SupplierId"]),
                    SupplierName = modelDictionary.ModelDictionary["SupplierName"],
                    Link = modelDictionary.ModelDictionary["Link"],
                    Rate = decimal.Parse(modelDictionary.ModelDictionary["Rate"]),
                    Notes = modelDictionary.ModelDictionary["Notes"]
                };
                if (category.Id > 0) facade.UpdateCategory(category); else facade.AddCategory(category);

                EventHelper.RaiseEvent(this, SaveCategoryClickEventRaised, new EventArgs());
            };

            categoriesDetailUC.CancelCategoriesDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Повертає представлення деталей категорії постачальника
        /// </summary>
        /// <returns>Екземпляр представлення категорії постачальника</returns>
        public ICategoriesDetailUC GetCategoriesDetailUC() => categoriesDetailUC;

        /// <summary>
        /// Налаштування представлення категорії постачальника для створення нової категорії
        /// </summary>
        public void SetupCategoriesDetailForAdd()
        {
            categoriesDetailUC.ResetControls(PrepareBindings());
            EventHelper.RaiseEvent(this, ReadyToShowCategoriesDetailEventRaised, new EventArgs());
        }

        /// <summary>
        /// Налаштування представлення категорії постачальника для редагування обраної категорії
        /// </summary>
        /// <param name="id"></param>
        public void SetupCategoriesDetailForEdit(int id)
        {
            Dictionary<string, string> modelDictionary = BuildModelDictionary(facade.GetCategoryById(id));
            categoriesDetailUC.SetupControls(modelDictionary, PrepareBindings());
            EventHelper.RaiseEvent(this, ReadyToShowCategoriesDetailEventRaised, new EventArgs());
        }

        private Dictionary<string, string> BuildModelDictionary(CategoriesDtoModel model)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", model.Id.ToString() },
                { "Name", model.Name },
                { "SupplierId", model.SupplierId.ToString() },
                { "SupplierName", model.SupplierName },
                { "Link", model.Link },
                { "Rate", model.Rate.ToString() },
                { "Notes", model.Notes }
            };
            return modelDictionary;
        }

        private BindingSource PrepareBindings() => new BindingSource { DataSource = facade.GetSuppliersDto() };
    }
}
