using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.CategoriesServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення категорій постачальників
    /// </summary>
    public class CategoriesPresenter : ICategoriesPresenter
    {
        private ICategoriesUC categoriesUC;

        private ICategoriesDetailPresenter categoriesDetailPresenter;

        private IStoreFacade facade;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Подія зміни посилання на сторінку обраної категорії постачальника
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Конструктор представлення категорій постачальників
        /// </summary>
        /// <param name="categoriesUC">Екземпляр представлення категорій постачальників</param>
        /// <param name="categoriesDetailPresenter">Екземпляр презентера представлення деталей для обраної категорії постачальника</param>
        /// <param name="facade">Екземпляр фасаду</param>
        /// <param name="deleteConfirmView">Екземпляр універсальної форми підтвердження видалення сутності</param>
        /// <param name="errorMessageView">Екземпляр універсальної форми повідомлення про помилку</param>
        public CategoriesPresenter(ICategoriesUC categoriesUC, 
            ICategoriesDetailPresenter categoriesDetailPresenter,
            IStoreFacade facade, 
            IDeleteConfirmView deleteConfirmView, 
            IErrorMessageView errorMessageView)
        {
            this.categoriesUC = categoriesUC;
            this.categoriesDetailPresenter = categoriesDetailPresenter;
            this.facade = facade;
            this.deleteConfirmView = deleteConfirmView;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        /// <summary>
        /// Повертає налаштований екземпляр представлення списку категорій постачальників
        /// </summary>
        /// <returns>Екземпляр представлення категорій постачальників</returns>
        public ICategoriesUC GetCategoriesUC()
        {
            categoriesUC.SetupControls(BuildDataSource());
            return categoriesUC;
        }

        private void SubscribeToEvents()
        {
            categoriesUC.AddNewCategoryEventRaised += (sender, e) => categoriesDetailPresenter.SetupCategoriesDetailForAdd();

            categoriesUC.EditCategoryEventRaised += (sender, e) =>
            {
                CategoriesDtoModel categoriesDto = (CategoriesDtoModel)bindingSource.Current;
                categoriesDetailPresenter.SetupCategoriesDetailForEdit(categoriesDto.Id);
            };

            categoriesUC.DeleteCategoryEventRaised += (sender, e) =>
            {
                CategoriesDtoModel categoriesDto = (CategoriesDtoModel)bindingSource.Current;
                deleteConfirmView.ShowDeleteConfirmMessageView("Видалення категорії",
                    $"Підтвердіть видалення категорії товару: { categoriesDto.Name }.", categoriesDto.Id, "CategoriesUC");
            };

            categoriesUC.LinkToSearchChangedInUCEventRaised += (sender, modelDictionary) =>
                EventHelper.RaiseEvent(this, LinkToSearchChangedEventRaised, modelDictionary);

            categoriesUC.SortCategoriesByBindingPropertyNameEventRaised += (sender, sortParameters) =>
              OnSortCategoriesByBindingPropertyNameEventRaised(sender, sortParameters);
        }

        private void OnSortCategoriesByBindingPropertyNameEventRaised(object sender, DataEventArgs sortParameters)
        {
            var categoriesDtos = facade.GetCategoriesDto();
            switch (sortParameters.ModelDictionary["PropertyName"])
            {
                case "Name":
                    categoriesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? categoriesDtos.OrderBy(c => c.Name) :
                        categoriesDtos.OrderByDescending(c => c.Name);
                    break;
                case "SupplierName":
                    categoriesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? categoriesDtos.OrderBy(c => c.SupplierName) :
                        categoriesDtos.OrderByDescending(c => c.SupplierName);
                    break;
                case "Link":
                    categoriesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? categoriesDtos.OrderBy(c => c.Link) :
                        categoriesDtos.OrderByDescending(c => c.Link);
                    break;
                case "Rate":
                    categoriesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? categoriesDtos.OrderBy(c => c.Rate) :
                        categoriesDtos.OrderByDescending(c => c.Rate);
                    break;
                case "Notes":
                    categoriesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? categoriesDtos.OrderBy(c => c.Notes) :
                        categoriesDtos.OrderByDescending(c => c.Notes);
                    break;
            }
            bindingSource.DataSource = categoriesDtos;
            categoriesUC.SetupControls(bindingSource);
        }

        private BindingSource BuildDataSource()
        {
            var bindingList = new BindingList<CategoriesDtoModel>();
            foreach (CategoriesDtoModel category in facade.GetCategoriesDto()) bindingList.Add(category);
            bindingSource = new BindingSource { DataSource = bindingList };
            return bindingSource;
        }
    }
}
