using System;
using System.Collections.Generic;
using AutoMapper;
using Domain.Models.Suppliers;
using Services.Validators;

namespace Services.SuppliersServices
{
    /// <summary>
    /// Клас сервісу постачальників
    /// </summary>
    public class SuppliersService : ISuppliersService
    {
        ISuppliersRepository suppliersRepository;
        SuppliersValidator suppliersValidator = new SuppliersValidator();

        /// <summary>
        /// Конструктор сервісу постачальників
        /// </summary>
        /// <param name="suppliersRepository">Екземпляр репозиторію постачальників</param>
        public SuppliersService(ISuppliersRepository suppliersRepository)
        {
            this.suppliersRepository = suppliersRepository;
        }

        /// <summary>
        /// Додає постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        public void AddSupplier(SuppliersDtoModel supplierDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SuppliersDtoModel, SuppliersModel>()).CreateMapper();
            SuppliersModel supplier = mapper.Map<SuppliersModel>(supplierDto);

            var results = suppliersValidator.Validate(supplier);
            if (results.IsValid)
            {
                suppliersRepository.Add(supplier);
            }
            else
            {
                throw new Exception("Помилка валідації постачальника:" + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }

        /// <summary>
        /// Видаляє постачальника
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        public void DeleteSupplierById(int id) => suppliersRepository.DeleteById(id);

        /// <summary>
        /// Повертає екземпляр постачальника за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        /// <returns>Екземпляр постачальника</returns>
        public SuppliersDtoModel GetSupplierById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SuppliersModel, SuppliersDtoModel>()).CreateMapper();

            return mapper.Map<SuppliersDtoModel>(suppliersRepository.GetById(id));
        }

        /// <summary>
        /// Повертає список постачальників
        /// </summary>
        /// <returns>Список постачальників</returns>
        public IEnumerable<SuppliersDtoModel> GetSuppliers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SuppliersModel, SuppliersDtoModel>()).CreateMapper();

            return mapper.Map<IEnumerable<SuppliersDtoModel>>(suppliersRepository.GetAll());
        }

        /// <summary>
        /// Оновлює постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        public void UpdateSupplier(SuppliersDtoModel supplierDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SuppliersDtoModel, SuppliersModel>()).CreateMapper();
            SuppliersModel supplier = mapper.Map<SuppliersModel>(supplierDto);

            var results = suppliersValidator.Validate(supplier);
            if (results.IsValid)
            {
                suppliersRepository.Update(supplier);
            }
            else
            {
                throw new Exception("Помилка валідації постачальника:" + Environment.NewLine +
                    ValidationResultsHelper.GetValidationErrors(results));
            }
        }
    }
}
