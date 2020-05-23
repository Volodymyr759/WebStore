using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.ProductsServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення списку товарів постачальників
    /// </summary>
    public class ProductsPresenter : IProductsPresenter
    {
        private IProductsUC productsUC;

        private IProductsDetailPresenter productsDetailPresenter;

        private IStoreFacade facade;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного товару постачальника
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Конструктор презентера представлення списку товарів постачальників
        /// </summary>
        /// <param name="productsUC">Екземпляр представлення списку товарів постачальників</param>
        /// <param name="productsDetailPresenter">Екземпляр презентера представлення деталей товару</param>
        /// <param name="facade">Екземпляр фасаду</param>
        /// <param name="deleteConfirmView">Екземпляр універсальной форми підтвердження видалення запису</param>
        /// <param name="errorMessageView">Екземпляр універсальной форми повідомлення про помилку</param>
        public ProductsPresenter(IProductsUC productsUC,
            IProductsDetailPresenter productsDetailPresenter,
            IStoreFacade facade,
            IDeleteConfirmView deleteConfirmView,
            IErrorMessageView errorMessageView)
        {
            this.productsUC = productsUC;
            this.productsDetailPresenter = productsDetailPresenter;
            this.facade = facade;
            this.deleteConfirmView = deleteConfirmView;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        /// <summary>
        /// Повертає екземпляр представлення списку товарів постачальників
        /// </summary>
        /// <returns>Екземпляр представлення списку товарів постачальників</returns>
        public IProductsUC GetProductsUC()
        {
            productsUC.SetupControls(BuildDataSource(facade.GetProductsDto()));
            return productsUC;
        }

        private void SubscribeToEvents()
        {
            productsUC.AddNewProductEventRaised += (sender, e) => productsDetailPresenter.SetupProductsDetailForAdd();

            productsUC.EditProductEventRaised += (sender, e) =>
              {
                  ProductsDtoModel productDto = (ProductsDtoModel)bindingSource.Current;
                  productsDetailPresenter.SetupProductsDetailForEdit(productDto.Id);
              };

            productsUC.DeleteProductEventRaised += (sender, e) =>
              {
                  ProductsDtoModel productDto = (ProductsDtoModel)bindingSource.Current;
                  deleteConfirmView.ShowDeleteConfirmMessageView("Видалення товару",
                    $"Підтвердіть видалення товару: { productDto.NameWebStore }.", productDto.Id, "ProductsUC");
              };

            productsUC.LinkToSearchChangedInUCEventRaised += (sender, modelDictionary) =>
                EventHelper.RaiseEvent(this, LinkToSearchChangedEventRaised, modelDictionary);

            productsUC.SortProductsByBindingPropertyNameEventRaised += (sender, sortParameters) =>
               OnSortProductsByBindingPropertyNameEventRaised(sender, sortParameters);
        }

        private void OnSortProductsByBindingPropertyNameEventRaised(object sender, DataEventArgs sortParameters)
        {
            var productsDtos = (IEnumerable<ProductsDtoModel>)bindingSource.DataSource;
            switch (sortParameters.ModelDictionary["PropertyName"])
            {
                case "NameWebStore":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.NameWebStore) :
                        productsDtos.OrderByDescending(p => p.NameWebStore);
                    break;
                case "NameSupplier":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.NameSupplier) :
                        productsDtos.OrderByDescending(p => p.NameSupplier);
                    break;
                case "SupplierName":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.SupplierName) :
                        productsDtos.OrderByDescending(p => p.SupplierName);
                    break;
                case "CategoryName":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.CategoryName) :
                        productsDtos.OrderByDescending(p => p.CategoryName);
                    break;
                case "GroupName":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.GroupName) :
                        productsDtos.OrderByDescending(p => p.GroupName);
                    break;
                case "UnitName":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.UnitName) :
                        productsDtos.OrderByDescending(p => p.UnitName);
                    break;
                case "CodeWebStore":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.CodeWebStore) :
                        productsDtos.OrderByDescending(p => p.CodeWebStore);
                    break;
                case "CodeSupplier":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.CodeSupplier) :
                        productsDtos.OrderByDescending(p => p.CodeSupplier);
                    break;
                case "PriceWebStore":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.PriceWebStore) :
                        productsDtos.OrderByDescending(p => p.PriceWebStore);
                    break;
                case "PriceSupplier":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.PriceSupplier) :
                        productsDtos.OrderByDescending(p => p.PriceSupplier);
                    break;
                case "Currency":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.Currency) :
                        productsDtos.OrderByDescending(p => p.Currency);
                    break;
                case "Available":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.Available) :
                        productsDtos.OrderByDescending(p => p.Available);
                    break;
                case "LinkWebStore":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.LinkWebStore) :
                        productsDtos.OrderByDescending(p => p.LinkWebStore);
                    break;
                case "LinkSupplier":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.LinkSupplier) :
                        productsDtos.OrderByDescending(p => p.LinkSupplier);
                    break;
                case "Notes":
                    productsDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? productsDtos.OrderBy(p => p.Notes) :
                        productsDtos.OrderByDescending(p => p.Notes);
                    break;
            }
            bindingSource.DataSource = productsDtos;
            productsUC.SetupControls(bindingSource);
        }

        /// <summary>
        /// Завантаження списку нових товарів з джерел постачальників
        /// </summary>
        /// <returns>>Екземпляр представлення списку товарів постачальників</returns>
        public IProductsUC GetNewProducts()
        {
            facade.GetNewProducts();
            productsUC.SetupControls(BuildDataSource(facade.GetProductsDto()));
            return productsUC;
        }

        /// <summary>
        /// Перевіряє наявність збережених товарів у джерелах постачальників
        /// </summary>
        /// <returns>>Екземпляр представлення списку товарів постачальників</returns>
        public IProductsUC CheckAvailability()
        {
            facade.CheckAvailabilityProducts();
            productsUC.SetupControls(BuildDataSource(facade.GetProductsDto()));
            return productsUC;
        }

        /// <summary>
        /// Перевіряє ціни збережених товарів у джерелах постачальників
        /// </summary>
        /// <returns>>Екземпляр представлення списку товарів постачальників</returns>
        public IProductsUC CheckPrices()
        {
            facade.CheckPricesProducts();
            productsUC.SetupControls(BuildDataSource(facade.GetProductsDto()));
            return productsUC;
        }

        private BindingSource BuildDataSource(IEnumerable<ProductsDtoModel> productsModels)
        {
            var bindingList = new BindingList<ProductsDtoModel>();
            foreach (ProductsDtoModel product in productsModels) bindingList.Add(product);
            bindingSource = new BindingSource { DataSource = bindingList };
            return bindingSource;
        }
    }
}
