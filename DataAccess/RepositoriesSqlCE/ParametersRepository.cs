using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Parameters;
using Domain.Models.Products;
using Domain.Models.Units;
using Services.ParametersService;

namespace DataAccess.RepositoriesSqlCE
{
    public class ParametersRepository : IParametersRepository
    {
        private string connectionString;

        public ParametersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IParametersModel model)
        {
            string sqlQuery = "insert into Parameters(ProductId, Name, UnitId, Value) values(@ProductId, @Name, @UnitId, @Value)";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@UnitId", model.UnitId);
                cmd.Parameters.AddWithValue("@Value", model.Value);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteById(int id)
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

        public IEnumerable<IParametersModel> GetAll()
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

        public IParametersModel GetById(int id)
        {
            ParametersModel parameter = new ParametersModel();
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                string query = "select Id, ProductId, Name, UnitId, Value " +
                    "from Parameters where par.Id=@Id";
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

        public void Update(IParametersModel model)
        {
            var sqlQuery = "update Parameters set Name=@Name, ProductId=@ProductId, UnitId=@UnitId, Value=@Value where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@UnitId", model.UnitId);
                cmd.Parameters.AddWithValue("@Value", model.Value);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
