using System;
using System.Collections.Generic;
using Services.UnitsServices;
using Domain.Models.Units;
using System.Data.SqlServerCe;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Інтерфейс репозиторію одиниць виміру
    /// </summary>
    public class UnitsRepository : IUnitsRepository
    {
        private readonly string connectionString;

        #region Constructors

        /// <summary>
        /// Конструктор репозиторію одиниць виміру
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public UnitsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        /// <summary>
        /// Додає одиницю виміру
        /// </summary>
        /// <param name="unitsModel">Екземпляр одиниці виміру</param>
        public void Add(IUnitsModel unitsModel)
        {
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

                string sqlQuery = "insert into Units(Name, Notes) values(@Name, @Notes)";
                var cmd = new SqlCeCommand(sqlQuery, db);

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", unitsModel.Name);
                cmd.Parameters.AddWithValue("@Notes", unitsModel.Notes);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка додавання одиниці виміру в базу даних.");
                }
            }
        }

        /// <summary>
        /// Видаляє одиницю виміру
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        public void DeleteById(int id)
        {
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

                string query = "delete from Units where Id=@Id";
                SqlCeCommand cmd = new SqlCeCommand(query, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка оновлення одиниці виміру в базі даних.");
                }
            }
        }

        /// <summary>
        /// Повертає список усіх одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        public IEnumerable<IUnitsModel> GetAll()
        {
            List<UnitsModel> units = new List<UnitsModel>();
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

                string query = "select * from Units";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitsModel unit = new UnitsModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Notes = reader["Notes"].ToString()
                                };
                                units.Add(unit);
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання списку одиниць виміру з бази даних.");
                    }
                }
            }
            return units;
        }

        /// <summary>
        /// Повертає одиницю виміру по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр одиниці виміру</returns>
        public IUnitsModel GetById(int id)
        {
            UnitsModel unit = new UnitsModel();
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

                string query = "select Id, Name, Notes from Units where Id=@Id";
                using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        using (SqlCeDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                unit.Id = Convert.ToInt32(reader["Id"]);
                                unit.Name = reader["Name"].ToString();
                                unit.Notes = reader["Notes"].ToString();
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання одиниці виміру з бази даних.");
                    }
                }
            }
            return unit;
        }

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitsModel">Екземпляр одиниці виміру</param>
        public void Update(IUnitsModel unitsModel)
        {
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

                var sqlQuery = "update Units set Name=@Name, Notes=@Notes where Id=@Id";
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", unitsModel.Name);
                cmd.Parameters.AddWithValue("@Notes", unitsModel.Notes);
                cmd.Parameters.AddWithValue("@Id", unitsModel.Id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка оновлення одиниці виімру в базі даних.");
                }
            }
        }
    }
}
