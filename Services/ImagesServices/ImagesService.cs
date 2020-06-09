using System;
using System.Collections.Generic;
using AutoMapper;
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ImagesDtoModel, ImagesModel>()).CreateMapper();
            ImagesModel image = mapper.Map<ImagesModel>(imageDto);

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
        public void DeleteImageById(int id) => imagesRepository.DeleteById(id);

        /// <summary>
        /// Повертає екземпляр зображення за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        public ImagesDtoModel GetImageById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ImagesModel, ImagesDtoModel>()).CreateMapper();
            ImagesDtoModel imageDto = mapper.Map<ImagesDtoModel>(imagesRepository.GetById(id));
            imageDto.ProductName = commonRepository.GetProductsIdNames()[imageDto.ProductId];

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

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ImagesModel, ImagesDtoModel>()).CreateMapper();

            foreach (ImagesModel image in imagesRepository.GetAll())
            {
                ImagesDtoModel imagesDto = mapper.Map<ImagesDtoModel>(image);
                imagesDto.ProductName = productsIdNames[image.ProductId];
                imagesDtos.Add(imagesDto);
            }

            return imagesDtos;
        }

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        public void UpdateImage(ImagesDtoModel imageDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ImagesDtoModel, ImagesModel>()).CreateMapper();
            ImagesModel image = mapper.Map<ImagesModel>(imageDto);

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
