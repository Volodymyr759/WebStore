using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Models.Categories;
using Services.Validators;

namespace Services.CategoriesServices
{
    /// <summary>
    /// Клас сервісу категорій
    /// </summary>
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;

        private readonly ICommonRepository commonRepository;

        CategoriesValidator categoriesValidator = new CategoriesValidator();

        /// <summary>
        /// Конструктор сервісу категорій
        /// </summary>
        /// <param name="categoriesRepository">Екземпляр репозиторію категорії</param>
        /// <param name="commonRepository">Екземпляр репозиторію загальних довідників</param>
        public CategoriesService(ICategoriesRepository categoriesRepository, ICommonRepository commonRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.commonRepository = commonRepository;
        }

        /// <summary>
        /// Додає категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        public void AddCategory(CategoriesDtoModel categoryDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoriesDtoModel, CategoriesModel>()).CreateMapper();
            CategoriesModel category = mapper.Map<CategoriesModel>(categoryDto);
            var results = categoriesValidator.Validate(category);
            if (results.IsValid)
            {
                categoriesRepository.Add(category);
            }
            else
            {
                throw new Exception("Помилка валідації категорії: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }

        /// <summary>
        /// Видаляє категорію
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        public void DeleteCategoryById(int id) => categoriesRepository.DeleteById(id);

        /// <summary>
        /// Повертає екземпляр категорії за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        public CategoriesDtoModel GetCategoryById(int id)
        {
            var category = categoriesRepository.GetById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoriesModel, CategoriesDtoModel>()).CreateMapper();
            CategoriesDtoModel categoriesDto = mapper.Map<CategoriesDtoModel>(category);
            categoriesDto.SupplierName = commonRepository.GetSuppliersIdNames()[category.SupplierId];

            return categoriesDto;
        }

        /// <summary>
        /// Повертає список категорій Dto
        /// </summary>
        /// <returns>Список категорій</returns>
        public IEnumerable<CategoriesDtoModel> GetCategories()
        {
            List<CategoriesDtoModel> categoriesDtos = new List<CategoriesDtoModel>();
            Dictionary<int, string> suppliersIdNames = commonRepository.GetSuppliersIdNames();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoriesModel, CategoriesDtoModel>()).CreateMapper();

            foreach (CategoriesModel category in categoriesRepository.GetAll())
            {
                CategoriesDtoModel categoriesDto = mapper.Map<CategoriesDtoModel>(category);
                categoriesDto.SupplierName = suppliersIdNames[category.SupplierId];
                categoriesDtos.Add(categoriesDto);
            }

            return categoriesDtos;
        }

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        public void UpdateCategory(CategoriesDtoModel categoryDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoriesDtoModel, CategoriesModel>()).CreateMapper();
            CategoriesModel category = mapper.Map<CategoriesModel>(categoryDto);

            var results = categoriesValidator.Validate(category);
            if (results.IsValid)
            {
                categoriesRepository.Update(category);
            }
            else
            {
                throw new Exception("Помилка валідації категорії: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }
    }
}
