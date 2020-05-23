using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.ImagesServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення деталей зображення товару
    /// </summary>
    public class ImagesDetailPresenter : IImagesDetailPresenter
    {
        private IImagesDetailUC imagesDetailUC;

        private IStoreFacade facade;

        /// <summary>
        /// Подія готовності до відображення представлення деталей зображення товару
        /// </summary>
        public event EventHandler ReadyToShowImagesDetailEventRaised;

        /// <summary>
        /// Подія відміни у представленні деталей зображення товару
        /// </summary>
        public event EventHandler CancelClickEventRaised;

        /// <summary>
        /// Подія збереження запису обраного зображення товару
        /// </summary>
        public event EventHandler SaveImageClickEventRaised;

        /// <summary>
        /// Конструктор презентера представлення деталей зображення товару
        /// </summary>
        /// <param name="imagesDetailUC">Екземпляр представлення деталей зображення</param>
        /// <param name="facade">Екземпляр фасаду</param>
        public ImagesDetailPresenter(IImagesDetailUC imagesDetailUC, IStoreFacade facade)
        {
            this.imagesDetailUC = imagesDetailUC;
            this.facade = facade;
            SubscribeToEvents();
        }

        /// <summary>
        /// Налаштування представлення деталей зображення для створення нового запису
        /// </summary>
        public void SetupImagesDetailForAdd()
        {
            imagesDetailUC.ResetControls(PrepareBindings());
            EventHelper.RaiseEvent(this, ReadyToShowImagesDetailEventRaised, new EventArgs());
        }

        /// <summary>
        /// Налаштування представлення деталей зображення для редагування обраного запису
        /// </summary>
        /// <param name="id">Ідентифікатор зображення товару</param>
        public void SetupImagesDetailForEdit(int id)
        {
            Dictionary<string, string> modelDictionary = BuildModelDictionary(facade.GetImageById(id));
            imagesDetailUC.SetupControls(modelDictionary, PrepareBindings());
            EventHelper.RaiseEvent(this, ReadyToShowImagesDetailEventRaised, new EventArgs());
        }

        private void SubscribeToEvents()
        {
            imagesDetailUC.SaveImagesDetailEventRaised += (sender, modelDictionary) =>
            {
                ImagesDtoModel imageDto = new ImagesDtoModel
                {
                    Id = modelDictionary.ModelDictionary["Id"] == "" ? 0 : int.Parse(modelDictionary.ModelDictionary["Id"]),
                    ProductId = Convert.ToInt32(modelDictionary.ModelDictionary["ProductId"]),
                    ProductName = modelDictionary.ModelDictionary["ProductName"],
                    FileName = modelDictionary.ModelDictionary["FileName"],
                    LinkWebStore = modelDictionary.ModelDictionary["LinkWebStore"],
                    LinkSupplier = modelDictionary.ModelDictionary["LinkSupplier"],
                    LocalPath = modelDictionary.ModelDictionary["LocalPath"]
                };
                if (imageDto.Id > 0) facade.UpdateImage(imageDto); else facade.AddImage(imageDto);

                EventHelper.RaiseEvent(this, SaveImageClickEventRaised, new EventArgs());
            };

            imagesDetailUC.CancelImagesDetailEventRaised += (sender, e) => EventHelper.RaiseEvent(this, CancelClickEventRaised, new EventArgs());
        }

        /// <summary>
        /// Повертає екземпляр представлення деталей зображення товару
        /// </summary>
        /// <returns>Екземпляр представлення деталей зображення</returns>
        public IImagesDetailUC GetImagesDetailUC() => imagesDetailUC;

        private Dictionary<string, string> BuildModelDictionary(ImagesDtoModel model)
        {
            var modelDictionary = new Dictionary<string, string>()
            {
                { "Id", model.Id.ToString() },
                { "FileName", model.FileName },
                { "ProductName", model.ProductName },
                { "LinkWebStore", model.LinkWebStore },
                { "LinkSupplier", model.LinkSupplier },
                { "LocalPath", model.LocalPath }
            };
            return modelDictionary;
        }

        private BindingSource PrepareBindings() => new BindingSource { DataSource = facade.GetProductsDto() };
    }
}
