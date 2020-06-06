using System;
using System.Collections.Generic;
using Domain.Models.Images;
using Services.Validators;

namespace Services.ImagesServices
{
    /// <summary>
    /// Клас сервісу зображень
    /// </summary>
    public class ImagesService : IImagesService
    {
        private readonly IImagesRepository imagesRepository;

        private readonly ICommonRepository commonRepository;

        private readonly ImagesValidator imagesValidator = new ImagesValidator();

        /// <summary>
        /// Конструктор сервісу зображень
        /// </summary>
        /// <param name="imagesRepository">Екземпляр репозиторію зображень</param>
        /// <param name="commonRepository">Екземпляр репозиторію загальних довідників</param>
        public ImagesService(IImagesRepository imagesRepository, ICommonRepository commonRepository)
        {
            this.imagesRepository = imagesRepository;
            this.commonRepository = commonRepository;
        }

        /// <summary>
        /// Додає зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        public void AddImage(ImagesDtoModel imageDto)
        {
            ImagesModel image = new ImagesModel()
            {
                ProductId = imageDto.ProductId,
                FileName = imageDto.FileName,
                LinkWebStore = imageDto.LinkWebStore ?? "",
                LinkSupplier = imageDto.LinkSupplier,
                LocalPath = imageDto.LocalPath
            };
            var results = imagesValidator.Validate(image);
            if (results.IsValid)
            {
                imagesRepository.Add(image);
            }
            else
            {
                throw new Exception("Помилка валідації зображення:" + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }

        /// <summary>
        /// Видаляє зображення
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        public void DeleteImageById(int id)
        {
            imagesRepository.DeleteById(id);
        }

        /// <summary>
        /// Повертає екземпляр зображення за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        public ImagesDtoModel GetImageById(int id)
        {
            var image = imagesRepository.GetById(id);
            ImagesDtoModel imageDto = new ImagesDtoModel
            {
                Id = image.Id,
                ProductId = image.ProductId,
                ProductName = commonRepository.GetProductsIdNames()[image.ProductId],
                FileName = image.FileName,
                LinkWebStore = image.LinkWebStore ?? "",
                LinkSupplier = image.LinkSupplier,
                LocalPath = image.LocalPath
            };
            return imageDto;
        }

        /// <summary>
        /// Повертає список зображень
        /// </summary>
        /// <returns>Список зображень</returns>
        public IEnumerable<ImagesDtoModel> GetImages()
        {
            List<ImagesDtoModel> imagesDtos = new List<ImagesDtoModel>();
            Dictionary<int, string> productsIdNames = commonRepository.GetProductsIdNames();
            foreach (ImagesModel image in imagesRepository.GetAll())
            {
                imagesDtos.Add(new ImagesDtoModel
                {
                    Id = image.Id,
                    ProductId = image.ProductId,
                    ProductName = productsIdNames[image.ProductId],
                    FileName = image.FileName,
                    LinkWebStore = image.LinkWebStore ?? "",
                    LinkSupplier = image.LinkSupplier,
                    LocalPath = image.LocalPath
                });
            }
            return imagesDtos;
        }

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        public void UpdateImage(ImagesDtoModel imageDto)
        {
            ImagesModel image = new ImagesModel()
            {
                Id = imageDto.Id,
                ProductId = imageDto.ProductId,
                FileName = imageDto.FileName,
                LinkWebStore = imageDto.LinkWebStore ?? "",
                LinkSupplier = imageDto.LinkSupplier,
                LocalPath = imageDto.LocalPath
            };
            var results = imagesValidator.Validate(image);
            if (imagesValidator.Validate(image).IsValid)
            {
                imagesRepository.Update(image);
            }
            else
            {
                throw new Exception("Помилка валідації зображення:" + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }
    }
}
