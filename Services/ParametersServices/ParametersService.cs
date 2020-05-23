using System;
using System.Collections.Generic;
using System.Linq;
using Services.ProductsServices;
using Services.UnitsServices;
using Services.Validators;
using Domain.Models.Parameters;

namespace Services.ParametersServices
{
    /// <summary>
    /// Клас сервісу характеристик
    /// </summary>
    public class ParametersService : IParametersService
    {
        IParametersRepository parametersRepository;
        IProductsService productsService;
        IUnitsService unitsService;
        ParametersValidator parametersValidator = new ParametersValidator();

        /// <summary>
        /// Конструктор сервісу характеристик
        /// </summary>
        /// <param name="parametersRepository">Екземпляр репозиторію характеристик</param>
        /// <param name="productsService">Екземпляр сервісу товарів</param>
        /// <param name="unitsService">Екземпляр сервісу одиниць виміру</param>
        public ParametersService(IParametersRepository parametersRepository, IProductsService productsService, IUnitsService unitsService)
        {
            this.parametersRepository = parametersRepository;
            this.productsService = productsService;
            this.unitsService = unitsService;
        }

        /// <summary>
        /// Додає характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        public void AddParameter(ParametersDtoModel parameterDto)
        {
            ParametersModel parameter = new ParametersModel
            {
                ProductId = parameterDto.ProductId,
                Name = parameterDto.Name,
                UnitId = parameterDto.UnitId,
                Value = parameterDto.Value
            };
            var results = parametersValidator.Validate(parameter);
            if (results.IsValid)
            {
                parametersRepository.Add(parameter);
            }
            else
            {
                throw new Exception("Помилка валідації характеристики: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }

        /// <summary>
        /// Видаляє характеристику
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        public void DeleteParameterById(int id)
        {
            parametersRepository.DeleteById(id);
        }

        /// <summary>
        /// Повертає екземпляр характеристики за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        /// <returns>Екземпляр характеристики</returns>
        public ParametersDtoModel GetParameterById(int id)
        {
            var parameter = parametersRepository.GetById(id);
            ParametersDtoModel parametersDto = new ParametersDtoModel
            {
                Id = id,
                Name = parameter.Name,
                ProductId = parameter.ProductId,
                ProductName = productsService.GetProductById(parameter.ProductId).NameWebStore,
                UnitId = parameter.UnitId,
                UnitName = unitsService.GetUnitById(parameter.UnitId).Name,
                Value = parameter.Value
            };
            return parametersDto;
        }

        /// <summary>
        /// Повертає список характеристик
        /// </summary>
        /// <returns>Список характеристик</returns>
        public IEnumerable<ParametersDtoModel> GetParameters()
        {
            List<ParametersDtoModel> parametersDtos = new List<ParametersDtoModel>();
            List<ProductsDtoModel> products = productsService.GetProducts().ToList();
            List<UnitsDtoModel> units = unitsService.GetUnits().ToList();
            foreach (ParametersModel parameter in parametersRepository.GetAll())
            {
                parametersDtos.Add(new ParametersDtoModel
                {
                    Id = parameter.Id,
                    Name = parameter.Name,
                    ProductId = parameter.ProductId,
                    ProductName = products.Where(p => p.Id == parameter.ProductId).FirstOrDefault().NameWebStore,
                    UnitId = parameter.UnitId,
                    UnitName = units.Where(p => p.Id == parameter.UnitId).FirstOrDefault().Name,
                    Value = parameter.Value
                });
            }
            return parametersDtos;
        }

        /// <summary>
        /// Оновлює характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        public void UpdateParameter(ParametersDtoModel parameterDto)
        {
            ParametersModel parameter = new ParametersModel
            {
                Id = parameterDto.Id,
                ProductId = parameterDto.ProductId,
                Name = parameterDto.Name,
                UnitId = parameterDto.UnitId,
                Value = parameterDto.Value
            };
            var results = parametersValidator.Validate(parameter);
            if (results.IsValid)
            {
                parametersRepository.Update(parameter);
            }
            else
            {
                throw new Exception("Помилка валідації характеристики: " + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }
    }
}
