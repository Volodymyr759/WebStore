using System.Collections.Generic;

namespace Services
{
    /// <summary>
    /// Інтерфейс репозиторію загальних довідників
    /// </summary>
    public interface ICommonRepository
    {
        /// <summary>
        /// Повертає словник Id:Name категорій
        /// </summary>
        /// <returns>Словник Id:Name категорій</returns>
        Dictionary<int, string> GetCategoriesIdNames();

        /// <summary>
        /// Повертає словник Id:Name груп власного каталогу
        /// </summary>
        /// <returns>Словник Id:Name груп власного каталогу</returns>
        Dictionary<int, string> GetGroupsIdNames();

        /// <summary>
        /// Повертає словник Id:Name товарів
        /// </summary>
        /// <returns>Словник Id:Name товарів</returns>
        Dictionary<int, string> GetProductsIdNames();

        /// <summary>
        /// Повертає словник валют Id:Currency постачальників
        /// </summary>
        /// <returns>Словник валют Id:Currency постачальників</returns>
        Dictionary<int, string> GetSuppliersIdCurrencies();

        /// <summary>
        /// Повертає словник Id:Name постачальників
        /// </summary>
        /// <returns>Словник Id:Name постачальників</returns>
        Dictionary<int, string> GetSuppliersIdNames();

        /// <summary>
        /// Повертає словник Id:Name одиниць виміру
        /// </summary>
        /// <returns>Словник Id:Name одиниць виміру</returns>
        Dictionary<int, string> GetUnitsIdNames();
    }
}
