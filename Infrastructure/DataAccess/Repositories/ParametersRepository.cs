using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Parameters;
using Services.ParametersServices;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторій характеристик товару
    /// </summary>
    public class ParametersRepository : IParametersRepository
    {
        private string connectionString;

        /// <summary>
        /// Конструктор характеристики товару
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public ParametersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Додає характеристику товару
        /// </summary>
        /// <param name="parametersModel">Екземпляр характеристики товару</param>
        public void Add(IParametersModel parametersModel)
        {
            try
            {
                string sqlQuery = "insert into Parameters(ProductId, Name, UnitId, Value) values(@ProductId, @Name, @UnitId, @Value)";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ProductId", parametersModel.ProductId);
                    cmd.Parameters.AddWithValue("@Name", parametersModel.Name);
                    cmd.Parameters.AddWithValue("@UnitId", parametersModel.UnitId);
                    cmd.Parameters.AddWithValue("@Value", parametersModel.Value);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка створення характеристики в базі даних.");
            }
        }

        /// <summary>
        /// Видаляє характеристику товару
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики товару</param>
        public void DeleteById(int id)
        {
            try
            {
                string query = "delete from Parameters where Id=@Id";
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
                throw new Exception("Помилка видалення характеристики з бази даних.");
            }
        }

        /// <summary>
        /// Повертає список усіх характеристик товару
        /// </summary>
        /// <returns>Список характеристик товару</returns>
        public IEnumerable<IParametersModel> GetAll()
        {
            try
            {
                List<ParametersModel> parameters = new List<ParametersModel>();
                string query = "select Id, ProductId, Name, UnitId, Value from Parameters";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    using (SqlCeCommand command = new SqlCeCommand(query, db))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ParametersModel parameter = new ParametersModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    UnitId = Convert.ToInt32(reader["UnitId"]),
                                    Value = reader["Value"].ToString(),
                                };
                                parameters.Add(parameter);
                            }
                        }
                    }
                    db.Close();
                }
                return parameters;
            }
            catch (Exception)
            {
                throw new Exception("Помилка отримання списку характеристик з бази даних.");
            }
        }

        /// <summary>
        /// Повертає характеристику товару по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики товару</param>
        /// <returns>Екземпляр характеристики товару</returns>
        public IParametersModel GetById(int id)
        {
            try
            {
                ParametersModel parameter = new ParametersModel();
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    string query = "select Id, ProductId, Name, UnitId, Value " +
                        "from Parameters where Id=@Id";
                    using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlCeDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                parameter.Id = Convert.ToInt32(reader["Id"]);
                                parameter.Name = reader["Name"].ToString();
                                parameter.ProductId = Convert.ToInt32(reader["ProductId"]);
                                parameter.UnitId = Convert.ToInt32(reader["UnitId"]);
                                parameter.Value = reader["Value"].ToString();
                            }
                        }
                    }
                    db.Close();
                }
                return parameter;
            }
            catch (Exception)
            {
                throw new Exception("Помилка отримання характеристики з бази даних.");
            }
        }

        /// <summary>
        /// Оновлює характеристику товару
        /// </summary>
        /// <param name="parametersModel">Екземпляр характеристики товару</param>
        public void Update(IParametersModel parametersModel)
        {
            try
            {
                var sqlQuery = "update Parameters set Name=@Name, ProductId=@ProductId, UnitId=@UnitId, Value=@Value where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ProductId", parametersModel.ProductId);
                    cmd.Parameters.AddWithValue("@Name", parametersModel.Name);
                    cmd.Parameters.AddWithValue("@UnitId", parametersModel.UnitId);
                    cmd.Parameters.AddWithValue("@Value", parametersModel.Value);
                    cmd.Parameters.AddWithValue("@Id", parametersModel.Id);

                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення характеристики в базі даних.");
            }
        }
    }
}
