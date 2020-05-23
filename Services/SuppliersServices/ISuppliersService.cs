using System.Collections.Generic;

namespace Services.SuppliersServices
{
    /// <summary>
    /// Інтерфейс сервісу постачальників
    /// </summary>
    public interface ISuppliersService
    {
        /// <summary>
        /// Додає постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        void AddSupplier(SuppliersDtoModel supplierDto);

        /// <summary>
        /// Видаляє постачальника
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        void DeleteSupplierById(int id);

        /// <summary>
        /// Повертає список постачальників
        /// </summary>
        /// <returns>Список постачальників</returns>
        IEnumerable<SuppliersDtoModel> GetSuppliers();

        /// <summary>
        /// Повертає екземпляр постачальника за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        /// <returns>Екземпляр постачальника</returns>
        SuppliersDtoModel GetSupplierById(int id);

        /// <summary>
        /// Оновлює постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        void UpdateSupplier(SuppliersDtoModel supplierDto);
    }
}
