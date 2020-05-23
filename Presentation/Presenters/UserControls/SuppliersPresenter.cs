using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.SuppliersServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення списку постачальників
    /// </summary>
    public class SuppliersPresenter : ISuppliersPresenter
    {
        private ISuppliersUC suppliersUC;

        private ISuppliersDetailPresenter suppliersDetailPresenter;

        private IStoreFacade facade;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного постачальника
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Конструктор презертера представлення списку постачальників
        /// </summary>
        /// <param name="suppliersUC">Екземпляр представлення списку постачальників</param>
        /// <param name="suppliersDetailPresenter">Екземпляр презентера представлення деталей постачальника</param>
        /// <param name="facade">Екземпляр фасаду</param>
        /// <param name="deleteConfirmView">Екземпляр форми підтвердження видалення запису</param>
        /// <param name="errorMessageView">Екземпляр форми повідомлення про помилку</param>
        public SuppliersPresenter(ISuppliersUC suppliersUC,
            ISuppliersDetailPresenter suppliersDetailPresenter,
            IStoreFacade facade,
            IDeleteConfirmView deleteConfirmView,
            IErrorMessageView errorMessageView)
        {
            this.suppliersUC = suppliersUC;
            this.suppliersDetailPresenter = suppliersDetailPresenter;
            this.facade = facade;
            this.deleteConfirmView = deleteConfirmView;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        /// <summary>
        /// Повертає екземпляр представлення списку постачальників
        /// </summary>
        /// <returns>Екземпляр представлення списку постачальників</returns>
        public ISuppliersUC GetSuppliersUC()
        {
            suppliersUC.SetupControls(BuildDataSource());
            return suppliersUC;
        }

        private void SubscribeToEvents()
        {
            suppliersUC.AddNewSupplierEventRaised += (sender, e) => suppliersDetailPresenter.SetupSuppliersDetailForAdd();

            suppliersUC.EditSupplierEventRaised += (sender, e) =>
            {
                SuppliersDtoModel supplierDto = (SuppliersDtoModel)bindingSource.Current;
                suppliersDetailPresenter.SetupSuppliersDetailForEdit(supplierDto.Id);
            };

            suppliersUC.DeleteSupplierEventRaised += (sender, e) =>
            {
                SuppliersDtoModel supplier = (SuppliersDtoModel)bindingSource.Current;
                deleteConfirmView.ShowDeleteConfirmMessageView("Видалення постачальника",
                    $"Підтвердіть видалення постачальника: { supplier.Name }.", supplier.Id, "SuppliersUC");
            };

            suppliersUC.LinkToSearchChangedInUCEventRaised += (sender, modelDictionary) =>
                EventHelper.RaiseEvent(this, LinkToSearchChangedEventRaised, modelDictionary);

            suppliersUC.SortSuppliersByBindingPropertyNameEventRaised += (sender, sortParameters) =>
               OnSortSuppliersByBindingPropertyNameEventRaised(sender, sortParameters);
        }

        private void OnSortSuppliersByBindingPropertyNameEventRaised(object sender, DataEventArgs sortParameters)
        {
            var suppliersDtos = facade.GetSuppliersDto();
            switch (sortParameters.ModelDictionary["PropertyName"])
            {
                case "Name":
                    suppliersDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? suppliersDtos.OrderBy(s => s.Name) :
                        suppliersDtos.OrderByDescending(s => s.Name);
                    break;
                case "Link":
                    suppliersDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? suppliersDtos.OrderBy(s => s.Link) :
                        suppliersDtos.OrderByDescending(s => s.Link);
                    break;
                case "Currency":
                    suppliersDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? suppliersDtos.OrderBy(s => s.Currency) :
                        suppliersDtos.OrderByDescending(s => s.Currency);
                    break;
                case "Notes":
                    suppliersDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? suppliersDtos.OrderBy(s => s.Notes) :
                        suppliersDtos.OrderByDescending(s => s.Notes);
                    break;
            }
            bindingSource.DataSource = suppliersDtos;
            suppliersUC.SetupControls(bindingSource);
        }

        private BindingSource BuildDataSource()
        {
            var bindingList = new BindingList<SuppliersDtoModel>();
            foreach (SuppliersDtoModel supplier in facade.GetSuppliersDto()) bindingList.Add(supplier);
            bindingSource = new BindingSource { DataSource = bindingList };
            return bindingSource;
        }
    }
}
