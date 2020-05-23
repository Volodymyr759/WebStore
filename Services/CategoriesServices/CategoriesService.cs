using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Categories;
using Services.SuppliersServices;
using Services.Validators;

namespace Services.CategoriesServices
{
    /// <summary>
    /// Клас сервісу категорій
    /// </summary>
    public class CategoriesService : ICategoriesService
    {
        ICategoriesRepository categoriesRepository;
        ISuppliersService suppliersService;
        CategoriesValidator categoriesValidator = new CategoriesValidator();

        /// <summary>
        /// Конструктор сервісу категорій
        /// </summary>
        /// <param name="categoriesRepository">Екземпляр репозиторію категорії</param>
        /// <param name="suppliersService">Екземпляр сервісу постачальників</param>
        public CategoriesService(ICategoriesRepository categoriesRepository, ISuppliersService suppliersService)
        {
            this.categoriesRepository = categoriesRepository;
            this.suppliersService = suppliersService;
        }

        /// <summary>
        /// Додає категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        public void AddCategory(CategoriesDtoModel categoryDto)
        {
            CategoriesModel category = new CategoriesModel
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                SupplierId = categoryDto.SupplierId,
                Link = categoryDto.Link,
                Rate = categoryDto.Rate,
                Notes = categoryDto.Notes
            };
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
        public void DeleteCategoryById(int id)
        {
            categoriesRepository.DeleteById(id);
        }

        /// <summary>
        /// Повертає екземпляр категорії за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        public CategoriesDtoModel GetCategoryById(int id)
        {
            var category = categoriesRepository.GetById(id);
            CategoriesDtoModel categoriesDto = new CategoriesDtoModel
            {
                Id = category.Id,
                Name = category.Name,
                SupplierId = category.SupplierId,
                SupplierName = suppliersService.GetSupplierById(category.SupplierId).Name,
                Link = category.Link,
                Rate = category.Rate,
                Notes = category.Notes
            };
            return categoriesDto;
        }

        /// <summary>
        /// Повертає список категорій Dto
        /// </summary>
        /// <returns>Список категорій</returns>
        public IEnumerable<CategoriesDtoModel> GetCategories()
        {
            List<CategoriesDtoModel> categoriesDtos = new List<CategoriesDtoModel>();
            List<SuppliersDtoModel> suppliers = suppliersService.GetSuppliers().ToList();
            foreach (CategoriesModel category in categoriesRepository.GetAll())
            {
                categoriesDtos.Add(new CategoriesDtoModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    SupplierId = category.SupplierId,
                    SupplierName = suppliers.Where(s => s.Id == category.SupplierId).FirstOrDefault().Name,
                    Link = category.Link,
                    Rate = category.Rate,
                    Notes = category.Notes
                });
            }
            return categoriesDtos;
        }

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        public void UpdateCategory(CategoriesDtoModel categoryDto)
        {
            CategoriesModel category = new CategoriesModel
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                SupplierId = categoryDto.SupplierId,
                Link = categoryDto.Link,
                Rate = categoryDto.Rate,
                Notes = categoryDto.Notes
            };
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
