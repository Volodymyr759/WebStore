using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Suppliers;
using Services.SuppliersServices;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторій постачальників
    /// </summary>
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly string connectionString;

        #region Constructors

        /// <summary>
        /// Конструктор репозиторію постачальників
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public SuppliersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        /// <summary>
        /// Додає постачальника
        /// </summary>
        /// <param name="suppliersModel">Екземпляр постачальника</param>
        public void Add(ISuppliersModel suppliersModel)
        {
            try
            {
                string sqlQuery = "insert into Suppliers(Name, Link, Currency, Notes) values(@Name, @Link, @Currency, @Notes)";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", suppliersModel.Name);
                    cmd.Parameters.AddWithValue("@Link", suppliersModel.Link);
                    cmd.Parameters.AddWithValue("@Currency", suppliersModel.Currency);
                    cmd.Parameters.AddWithValue("@Notes", suppliersModel.Notes);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка створення постачальника в базі даних.");
            }
        }

        /// <summary>
        /// Видаляє постачальника
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        public void DeleteById(int id)
        {
            try
            {
                string query = "delete from Suppliers where Id=@Id";
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
                throw new Exception("Помилка видалення постачальника з бази даних.");
            }
        }

        /// <summary>
        /// Повертає список усіх постачальників
        /// </summary>
        /// <returns>Список постачальників</returns>
        public IEnumerable<ISuppliersModel> GetAll()
        {
            try
            {
                List<SuppliersModel> suppliers = new List<SuppliersModel>();
                string query = "select * from Suppliers";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    using (SqlCeCommand command = new SqlCeCommand(query, db))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SuppliersModel supplier = new SuppliersModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Link = reader["Link"].ToString(),
                                    Currency = reader["Currency"].ToString(),
                                    Notes = reader["Notes"].ToString()
                                };
                                suppliers.Add(supplier);
                            }
                        }
                    }
                    db.Close();
                }
                return suppliers;
            }
            catch
            {
                throw new Exception("Помилка отримання списку постачальників з бази даних.");
            }
        }

        /// <summary>
        /// Повертає постачальника по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        /// <returns>Екземпляр постачальника</returns>
        public ISuppliersModel GetById(int id)
        {
            try
            {
                SuppliersModel supplier = new SuppliersModel();
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    string query = "select Id, Name, Link, Currency, Notes from Suppliers where Id=@Id";
                    using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlCeDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                supplier.Id = Convert.ToInt32(reader["Id"]);
                                supplier.Name = reader["Name"].ToString();
                                supplier.Link = reader["Link"].ToString();
                                supplier.Currency = reader["Currency"].ToString();
                                supplier.Notes = reader["Notes"].ToString();
                            }
                        }
                    }
                    db.Close();
                }
                return supplier;
            }
            catch
            {
                throw new Exception("Помилка отримання постачальника з бази даних.");
            }
        }

        /// <summary>
        /// Оновлює постачальника
        /// </summary>
        /// <param name="suppliersModel">Екземпляр постачальника</param>
        public void Update(ISuppliersModel suppliersModel)
        {
            try
            {
                var sqlQuery = "update Suppliers set Name=@Name, Link=@Link, Currency=@Currency, Notes=@Notes where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", suppliersModel.Name);
                    cmd.Parameters.AddWithValue("@Link", suppliersModel.Link);
                    cmd.Parameters.AddWithValue("@Currency", suppliersModel.Currency);
                    cmd.Parameters.AddWithValue("@Notes", suppliersModel.Notes);
                    cmd.Parameters.AddWithValue("@Id", suppliersModel.Id);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення постачальника в базі даних.");
            }
        }
    }
}
