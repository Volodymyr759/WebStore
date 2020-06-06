using Services;
using System;
using System.Collections.Generic;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторій загальних довідників
    /// </summary>
    public class CommonRepository : ICommonRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Конструктр репозиторію загальних довідників
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public CommonRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Повертає словник Id:Name категорій
        /// </summary>
        /// <returns>Словник Id:Name категорій</returns>
        public Dictionary<int, string> GetCategoriesIdNames()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає словник Id:Name груп власного каталогу
        /// </summary>
        /// <returns>Словник Id:Name груп власного каталогу</returns>
        public Dictionary<int, string> GetGroupsIdNames()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає словник Id:Name товарів
        /// </summary>
        /// <returns>Словник Id:Name товарів</returns>
        public Dictionary<int, string> GetProductsIdNames()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає словник валют Id:Currency постачальників
        /// </summary>
        /// <returns>Словник валют Id:Currency постачальників</returns>
        public Dictionary<int, string> GetSuppliersIdCurrencies()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає словник Id:Name постачальників
        /// </summary>
        /// <returns>Словник Id:Name постачальників</returns>
        public Dictionary<int, string> GetSuppliersIdNames()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає словник Id:Name одиниць виміру
        /// </summary>
        /// <returns>Словник Id:Name одиниць виміру</returns>
        public Dictionary<int, string> GetUnitsIdNames()
        {
            throw new NotImplementedException();
        }
    }
}
