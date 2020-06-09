using System;
using System.Collections.Generic;
using Services.Validators;
using Domain.Models.Parameters;
using AutoMapper;

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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ParametersDtoModel, ParametersModel>()).CreateMapper();
            ParametersModel parameter = mapper.Map<ParametersModel>(parameterDto);

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
        public void DeleteParameterById(int id) => parametersRepository.DeleteById(id);

        /// <summary>
        /// Повертає екземпляр характеристики за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        /// <returns>Екземпляр характеристики</returns>
        public ParametersDtoModel GetParameterById(int id)
        {
            var parameter = parametersRepository.GetById(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ParametersModel, ParametersDtoModel>()).CreateMapper();
            ParametersDtoModel parametersDto = mapper.Map<ParametersDtoModel>(parameter);
            parametersDto.ProductName = commonRepository.GetProductsIdNames()[parameter.ProductId];
            parametersDto.UnitName = commonRepository.GetUnitsIdNames()[parameter.UnitId];

            return parametersDto;
        }

        /// <summary>
        /// Повертає список характеристик
        /// </summary>
        /// <returns>Список характеристик</returns>
        public IEnumerable<ParametersDtoModel> GetParameters()
        {
            List<ParametersDtoModel> parametersDtos = new List<ParametersDtoModel>();
            Dictionary<int, string> productsIdNames = commonRepository.GetProductsIdNames();
            Dictionary<int, string> unitsIdNames = commonRepository.GetUnitsIdNames();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ParametersModel, ParametersDtoModel>()).CreateMapper();

            foreach (ParametersModel parameter in parametersRepository.GetAll())
            {
                ParametersDtoModel parametersDto = mapper.Map<ParametersDtoModel>(parameter);
                parametersDto.ProductName = productsIdNames[parameter.ProductId];
                parametersDto.UnitName = unitsIdNames[parameter.UnitId];
                parametersDtos.Add(parametersDto);
            }

            return parametersDtos;
        }

        /// <summary>
        /// Оновлює характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        public void UpdateParameter(ParametersDtoModel parameterDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ParametersDtoModel, ParametersModel>()).CreateMapper();
            ParametersModel parameter = mapper.Map<ParametersModel>(parameterDto);

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
