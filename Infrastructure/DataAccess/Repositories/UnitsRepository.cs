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
            try
            {
                string sqlQuery = "insert into Units(Name, Notes) values(@Name, @Notes)";
                using (var db = new SqlCeConnection(connectionString))
                {
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    db.Open();
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", unitsModel.Name);
                    cmd.Parameters.AddWithValue("@Notes", unitsModel.Notes);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка додавання одиниці виміру в базу даних.");
            }
        }

        /// <summary>
        /// Видаляє одиницю виміру
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        public void DeleteById(int id)
        {
            try
            {
                string query = "delete from Units where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    SqlCeCommand cmd = new SqlCeCommand(query, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення одиниці виміру в базі даних.");
            }
        }

        /// <summary>
        /// Повертає список усіх одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        public IEnumerable<IUnitsModel> GetAll()
        {
            try
            {
                List<UnitsModel> units = new List<UnitsModel>();
                string query = "select * from Units";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    using (SqlCeCommand command = new SqlCeCommand(query, db))
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
                    db.Close();
                }
                return units;
            }
            catch
            {
                throw new Exception("Помилка отримання списку одиниць виміру з бази даних.");
            }
        }

        /// <summary>
        /// Повертає одиницю виміру по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр одиниці виміру</returns>
        public IUnitsModel GetById(int id)
        {
            try
            {
                UnitsModel unit = new UnitsModel();
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    string query = "select Id, Name, Notes from Units where Id=@Id";
                    using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", id);
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
                    db.Close();
                }
                return unit;
            }
            catch
            {
                throw new Exception("Помилка отримання одиниці виміру з бази даних.");
            }
        }

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitsModel">Екземпляр одиниці виміру</param>
        public void Update(IUnitsModel unitsModel)
        {
            try
            {
                var sqlQuery = "update Units set Name=@Name, Notes=@Notes where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", unitsModel.Name);
                    cmd.Parameters.AddWithValue("@Notes", unitsModel.Notes);
                    cmd.Parameters.AddWithValue("@Id", unitsModel.Id);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення одиниці виімру в базі даних.");
            }
        }
    }
}
