using System;
using System.Collections.Generic;
using Services.Validators;
using Domain.Models.Parameters;

namespace Services.ParametersServices
{
    /// <summary>
    /// Клас сервісу характеристик
    /// </summary>
    public class ParametersService : IParametersService
    {
        private readonly IParametersRepository parametersRepository;

        private readonly ICommonRepository commonRepository;

        private readonly ParametersValidator parametersValidator = new ParametersValidator();

        /// <summary>
        /// Конструктор сервісу характеристик
        /// </summary>
        /// <param name="parametersRepository">Екземпляр репозиторію характеристик</param>
        /// <param name="commonRepository">Екземпляр репозиторію загальних довідників</param>
        public ParametersService(IParametersRepository parametersRepository, ICommonRepository commonRepository)
        {
            this.parametersRepository = parametersRepository;
            this.commonRepository = commonRepository;
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
                ProductName = commonRepository.GetProductsIdNames()[parameter.ProductId],
                UnitId = parameter.UnitId,
                UnitName = commonRepository.GetUnitsIdNames()[parameter.UnitId],
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
            //List<ProductsDtoModel> products = productsService.GetProducts().ToList();
            Dictionary<int, string> productsIdNames = commonRepository.GetProductsIdNames();
            //List<UnitsDtoModel> units = unitsService.GetUnits().ToList();
            Dictionary<int, string> unitsIdNames = commonRepository.GetUnitsIdNames();
            foreach (ParametersModel parameter in parametersRepository.GetAll())
            {
                parametersDtos.Add(new ParametersDtoModel
                {
                    Id = parameter.Id,
                    Name = parameter.Name,
                    ProductId = parameter.ProductId,
                    ProductName = productsIdNames[parameter.ProductId],
                    UnitId = parameter.UnitId,
                    UnitName = unitsIdNames[parameter.UnitId],
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
