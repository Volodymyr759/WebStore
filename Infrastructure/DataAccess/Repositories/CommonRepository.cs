using Services;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;

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
            Dictionary<int, string> categoriesIdNames = new Dictionary<int, string>();
            using (var db = new SqlCeConnection(connectionString))
            {
                try
                {
                    db.Open();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Немає підключення до бази даних.");
                }

                string query = "select Id, Name from Categories";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categoriesIdNames.Add(Convert.ToInt32(reader["Id"]), reader["Name"].ToString());
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання словника Id:Name категорій з бази даних.");
                    }
                }
            }
            return categoriesIdNames;
        }

        /// <summary>
        /// Повертає словник Id:Name груп власного каталогу
        /// </summary>
        /// <returns>Словник Id:Name груп власного каталогу</returns>
        public Dictionary<int, string> GetGroupsIdNames()
        {
            Dictionary<int, string> groupsIdNames = new Dictionary<int, string>();
            using (var db = new SqlCeConnection(connectionString))
            {
                try
                {
                    db.Open();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Немає підключення до бази даних.");
                }

                string query = "select Id, Name from Groups";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                groupsIdNames.Add(Convert.ToInt32(reader["Id"]), reader["Name"].ToString());
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання словника Id:Name груп з бази даних.");
                    }
                }
            }
            return groupsIdNames;
        }

        /// <summary>
        /// Повертає словник Id:Name товарів
        /// </summary>
        /// <returns>Словник Id:Name товарів</returns>
        public Dictionary<int, string> GetProductsIdNames()
        {
            Dictionary<int, string> productsIdNames = new Dictionary<int, string>();
            using (var db = new SqlCeConnection(connectionString))
            {
                try
                {
                    db.Open();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Немає підключення до бази даних.");
                }

                string query = "select Id, Name from Products";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productsIdNames.Add(Convert.ToInt32(reader["Id"]), reader["Name"].ToString());
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання словника Id:Name товарів з бази даних.");
                    }
                }
            }
            return productsIdNames;
        }

        /// <summary>
        /// Повертає словник валют Id:Currency постачальників
        /// </summary>
        /// <returns>Словник валют Id:Currency постачальників</returns>
        public Dictionary<int, string> GetSuppliersIdCurrencies()
        {
            Dictionary<int, string> suppliersIdCurrencies = new Dictionary<int, string>();
            using (var db = new SqlCeConnection(connectionString))
            {
                try
                {
                    db.Open();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Немає підключення до бази даних.");
                }

                string query = "select Id, Currency from Suppliers";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                suppliersIdCurrencies.Add(Convert.ToInt32(reader["Id"]), reader["Currency"].ToString());
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання словника валют Id:Currency постачальників з бази даних.");
                    }
                }
            }
            return suppliersIdCurrencies;
        }

        /// <summary>
        /// Повертає словник Id:Name постачальників
        /// </summary>
        /// <returns>Словник Id:Name постачальників</returns>
        public Dictionary<int, string> GetSuppliersIdNames()
        {
            Dictionary<int, string> suppliersIdNames = new Dictionary<int, string>();
            using (var db = new SqlCeConnection(connectionString))
            {
                try
                {
                    db.Open();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Немає підключення до бази даних.");
                }

                string query = "select Id, Name from Suppliers";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                suppliersIdNames.Add(Convert.ToInt32(reader["Id"]), reader["Name"].ToString());
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання словника Id:Name постачальників з бази даних.");
                    }
                }
            }
            return suppliersIdNames;
        }

        /// <summary>
        /// Повертає словник Id:Name одиниць виміру
        /// </summary>
        /// <returns>Словник Id:Name одиниць виміру</returns>
        public Dictionary<int, string> GetUnitsIdNames()
        {
            Dictionary<int, string> unitsIdNames = new Dictionary<int, string>();
            using (var db = new SqlCeConnection(connectionString))
            {
                try
                {
                    db.Open();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Немає підключення до бази даних.");
                }

                string query = "select Id, Name from Units";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                unitsIdNames.Add(Convert.ToInt32(reader["Id"]), reader["Name"].ToString());
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання словника Id:Name одиниць виміру з бази даних.");
                    }
                }
            }
            return unitsIdNames;
        }
    }
}
