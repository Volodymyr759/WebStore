using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using Services.ProductsServices;
using Presentation.Views.UserControls;
using Services;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення деталей товару постачальника
    /// </summary>
    public class ProductsDetailPresenter : IProductsDetailPresenter
    {
        private IProductsDetailUC productsDetailUC;

        private IStoreFacade facade;

        BindingSource bindingSourceSuppliersIdNameModel;

        BindingSource bindingSourceCategoriesIdNameModel;

        BindingSource bindingSourceGroupsIdNameModel;

        BindingSource bindingSourceUnitsIdNameModel;

        /// <summary>
        /// Подія готовності для відображення у головній формі
        /// </summary>
        public event EventHandler ReadyToShowProductsDetailEventRaised;

        /// <summary>
        /// Подія відміни збереження товару
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраного товару
        /// </summary>
        public event EventHandler SaveProductClickEventRaised;

        /// <summary>
        /// Конструктор презентера представлення деталей товару
        /// </summary>
        /// <param name="productsDetailUC">Екземпляр представлення деталей товару</param>
        /// <param name="facade">Екземпляр фасаду</param>
        public ProductsDetailPresenter(IProductsDetailUC productsDetailUC, IStoreFacade facade)
        {
            this.productsDetailUC = productsDetailUC;
            this.facade = facade;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            productsDetailUC.SaveProductsDetailEventRaised += (sender, modelDictionary) =>
            {
                ProductsDtoModel productDto = new ProductsDtoModel
                {
                    Id = modelDictionary.ModelDictionary["Id"] == "" ? 0 : int.Parse(modelDictionary.ModelDictionary["Id"]),
                    SupplierId = Convert.ToInt32(modelDictionary.ModelDictionary["SupplierId"]),
                    CategoryId = Convert.ToInt32(modelDictionary.ModelDictionary["CategoryId"]),
                    GroupId = modelDictionary.ModelDictionary["GroupId"] == "" ? 0 : Convert.ToInt32(modelDictionary.ModelDictionary["GroupId"]),
                    NameWebStore = modelDictionary.ModelDictionary["NameWebStore"],
                    NameSupplier = modelDictionary.ModelDictionary["NameSupplier"],
                    CodeWebStore = modelDictionary.ModelDictionary["CodeWebStore"],
                    CodeSupplier = modelDictionary.ModelDictionary["CodeSupplier"],
                    UnitId = Convert.ToInt32(modelDictionary.ModelDictionary["UnitId"]),
                    PriceWebStore = Convert.ToDecimal(modelDictionary.ModelDictionary["PriceWebStore"]),
                    PriceSupplier = Convert.ToDecimal(modelDictionary.ModelDictionary["PriceSupplier"]),
                    Available = modelDictionary.ModelDictionary["Available"],
                    LinkWebStore = modelDictionary.ModelDictionary["LinkWebStore"],
                    LinkSupplier = modelDictionary.ModelDictionary["LinkSupplier"],
                    Notes = modelDictionary.ModelDictionary["Notes"]
                };
                if (productDto.Id > 0) facade.UpdateProduct(productDto); else facade.AddProduct(productDto);

                EventHelper.RaiseEvent(this, SaveProductClickEventRaised, new EventArgs());
            };

            productsDetailUC.CancelProductsDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Отримання презентером форми вводу даних для створення/редагування товару
        /// </summary>
        /// <returns>Форма вводу даних для створення/редагування товару</returns>
        public IProductsDetailUC GetProductsDetailUC() => productsDetailUC;

        /// <summary>
        /// Налаштування форми вводу даних для створення нового товару
        /// </summary>
        public void SetupProductsDetailForAdd()
        {
            PrepareBindings();
            productsDetailUC.ResetControls(bindingSourceSuppliersIdNameModel, bindingSourceCategoriesIdNameModel,
                bindingSourceGroupsIdNameModel, bindingSourceUnitsIdNameModel);
            EventHelper.RaiseEvent(this, ReadyToShowProductsDetailEventRaised, new EventArgs());
        }

        /// <summary>
        /// Налаштування форми вводу даних для редагування існуючого товару
        /// </summary>
        /// <param name="id">id існуючого товару</param>
        public void SetupProductsDetailForEdit(int id)
        {
            PrepareBindings();
            Dictionary<string, string> modelDictionary = BuildModelDictionary(facade.GetProductById(id));
            productsDetailUC.SetupControls(modelDictionary, bindingSourceSuppliersIdNameModel, bindingSourceCategoriesIdNameModel,
                bindingSourceGroupsIdNameModel, bindingSourceUnitsIdNameModel);
            EventHelper.RaiseEvent(this, ReadyToShowProductsDetailEventRaised, new EventArgs());
        }

        private Dictionary<string, string> BuildModelDictionary(ProductsDtoModel model)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", model.Id.ToString() },
                { "NameWebStore", model.NameWebStore },
                { "NameSupplier", model.NameSupplier },
                { "SupplierName", model.SupplierName },
                { "CategoryName", model.CategoryName },
                { "GroupName", model.GroupName },
                { "UnitName", model.UnitName },
                { "CodeWebStore", model.CodeWebStore },
                { "CodeSupplier", model.CodeSupplier },
                { "PriceWebStore", model.PriceWebStore.ToString() },
                { "PriceSupplier", model.PriceSupplier.ToString() },
                { "Currency", model.Currency },
                { "Available", model.Available },
                { "LinkWebStore", model.LinkWebStore },
                { "LinkSupplier", model.LinkSupplier },
                { "Notes", model.Notes }
            };
            return modelDictionary;
        }

        private void PrepareBindings()
        {
            bindingSourceSuppliersIdNameModel = new BindingSource { DataSource = facade.GetSuppliersDto() };
            bindingSourceCategoriesIdNameModel = new BindingSource { DataSource = facade.GetCategoriesDto() };
            bindingSourceGroupsIdNameModel = new BindingSource { DataSource = facade.GetGroupsDto() };
            bindingSourceUnitsIdNameModel = new BindingSource { DataSource = facade.GetUnitsDto() };
        }
    }
}
