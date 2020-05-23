using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common;
using Presentation.Views.UserControls;
using Services;
using Services.ImagesServices;

namespace Presentation.Presenters.UserControls
{
    /// <summary>
    /// Презентер представлення списку зображень товарів
    /// </summary>
    public class ImagesPresenter : IImagesPresenter
    {
        private IImagesUC imagesUC;

        private IImagesDetailPresenter imagesDetailPresenter;

        private IStoreFacade facade;

        private IDeleteConfirmView deleteConfirmView;

        private IErrorMessageView errorMessageView;

        private BindingSource bindingSource;

        /// <summary>
        /// Подія зміни посилання на сторінку обраного зображення товару
        /// </summary>
        public event EventHandler<DataEventArgs> LinkToSearchChangedEventRaised;

        /// <summary>
        /// Конструктор презентера представлення списку зображень товарів
        /// </summary>
        /// <param name="imagesUC">Екземпляр представлення списку зображень</param>
        /// <param name="imagesDetailPresenter">Екземпляр презентера представлення деталей зображення</param>
        /// <param name="facade">Екземпляр фасаду</param>
        /// <param name="deleteConfirmView">Екземпляр універсальної форми підтвердження видалення запису</param>
        /// <param name="errorMessageView">Екземпляр універсальної форми відображення повідомлення про помилку</param>
        public ImagesPresenter(IImagesUC imagesUC, 
            IImagesDetailPresenter imagesDetailPresenter, 
            IStoreFacade facade,
            IDeleteConfirmView deleteConfirmView, 
            IErrorMessageView errorMessageView)
        {
            this.imagesUC = imagesUC;
            this.imagesDetailPresenter = imagesDetailPresenter;
            this.facade = facade;
            this.deleteConfirmView = deleteConfirmView;
            this.errorMessageView = errorMessageView;

            SubscribeToEvents();
        }

        /// <summary>
        /// Повертає екземпляр представлення списку зображень товарів
        /// </summary>
        /// <returns>Екземпляр представлення списку зображень</returns>
        public IImagesUC GetImagesUC()
        {
            imagesUC.SetupControls(BuildDataSource(facade.GetImagesDto()));
            return imagesUC;
        }

        /// <summary>
        /// Повертає екземпляр представлення списку зображень товарів після завантаження файлів з джерел постачальників
        /// </summary>
        /// <param name="localFolder">Адреса локальної папки для збереження файлів</param>
        /// <returns>Екземпляр представлення списку зображень</returns>
        public IImagesUC LoadImages(string localFolder)
        {
            facade.GetExternalImages(localFolder);
            imagesUC.SetupControls(BuildDataSource(facade.GetImagesDto()));
            return imagesUC;
        }

        private void SubscribeToEvents()
        {
            imagesUC.AddNewImageEventRaised += (sender, e) => imagesDetailPresenter.SetupImagesDetailForAdd();

            imagesUC.EditImageEventRaised += (sender, e) =>
            {
                ImagesDtoModel imageDto = (ImagesDtoModel)bindingSource.Current;
                imagesDetailPresenter.SetupImagesDetailForEdit(imageDto.Id);
            };

            imagesUC.DeleteImageEventRaised += (sender, e) =>
            {
                ImagesDtoModel imageDto = (ImagesDtoModel)bindingSource.Current;
                deleteConfirmView.ShowDeleteConfirmMessageView("Видалення зображення",
                    $"Підтвердіть видалення зображення: { imageDto.FileName }.", imageDto.Id, "ImagesUC");
            };

            imagesUC.LinkToSearchChangedInUCEventRaised += (sender, modelDictionary) =>
                EventHelper.RaiseEvent(this, LinkToSearchChangedEventRaised, modelDictionary);

            imagesUC.SortImagesByBindingPropertyNameEventRaised += (sender, sortParameters) =>
               OnSortImagesByBindingPropertyNameEventRaised(sender, sortParameters);
        }

        private void OnSortImagesByBindingPropertyNameEventRaised(object sender, DataEventArgs sortParameters)
        {
            var imagesDtos = facade.GetImagesDto();
            switch (sortParameters.ModelDictionary["PropertyName"])
            {
                case "FileName":
                    imagesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? imagesDtos.OrderBy(i => i.FileName) :
                        imagesDtos.OrderByDescending(i => i.FileName);
                    break;
                case "ProductName":
                    imagesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? imagesDtos.OrderBy(i => i.ProductName) :
                        imagesDtos.OrderByDescending(i => i.ProductName);
                    break;
                case "LinkWebStore":
                    imagesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? imagesDtos.OrderBy(i => i.LinkWebStore) :
                        imagesDtos.OrderByDescending(i => i.LinkWebStore);
                    break;
                case "LinkSupplier":
                    imagesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? imagesDtos.OrderBy(i => i.LinkSupplier) :
                        imagesDtos.OrderByDescending(i => i.LinkSupplier);
                    break;
                case "LocalPath":
                    imagesDtos = sortParameters.ModelDictionary["OrderOfSort"] == "Ascending" ? imagesDtos.OrderBy(i => i.LocalPath) :
                        imagesDtos.OrderByDescending(i => i.LocalPath);
                    break;
            }
            bindingSource.DataSource = imagesDtos;
            imagesUC.SetupControls(bindingSource);
        }

        private BindingSource BuildDataSource(IEnumerable<ImagesDtoModel> imagesDtos)
        {
            var bindingList = new BindingList<ImagesDtoModel>();
            foreach (ImagesDtoModel image in imagesDtos) bindingList.Add(image);
            bindingSource = new BindingSource { DataSource = bindingList };
            return bindingSource;
        }
    }
}
