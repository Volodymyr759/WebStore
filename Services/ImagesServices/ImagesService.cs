using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Images;
using Services.ProductsServices;
using Services.Validators;

namespace Services.ImagesServices
{
    /// <summary>
    /// Клас сервісу зображень
    /// </summary>
    public class ImagesService : IImagesService
    {
        IImagesRepository imagesRepository;
        IProductsService productsService;
        ImagesValidator imagesValidator = new ImagesValidator();

        /// <summary>
        /// Конструктор сервісу зображень
        /// </summary>
        /// <param name="imagesRepository">Екземпляр репозиторію зображень</param>
        /// <param name="productsService">Екземпляр сервісу товарів</param>
        public ImagesService(IImagesRepository imagesRepository, IProductsService productsService)
        {
            this.imagesRepository = imagesRepository;
            this.productsService = productsService;
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
                ProductName = productsService.GetProductById(image.ProductId)?.NameWebStore,
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
            List<ProductsDtoModel> products = productsService.GetProducts().ToList();
            foreach (ImagesModel image in imagesRepository.GetAll())
            {
                imagesDtos.Add(new ImagesDtoModel
                {
                    Id = image.Id,
                    ProductId = image.ProductId,
                    ProductName = products.Where(p => p.Id == image.ProductId).FirstOrDefault().NameWebStore,
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
