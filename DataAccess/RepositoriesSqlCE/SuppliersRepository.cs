using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Suppliers;
using Services.SuppliersService;

namespace DataAccess.RepositoriesSqlCE
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private string connectionString;

        #region Constructors

        public SuppliersRepository()
        {
        }

        public SuppliersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        public void Add(ISuppliersModel model)
        {
            string sqlQuery = "insert into Suppliers(Name, Link, Currency, Notes) values(@Name, @Link, @Currency, @Notes)";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Link", model.Link);
                cmd.Parameters.AddWithValue("@Currency", model.Currency);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteById(int id)
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

        public IEnumerable<ISuppliersModel> GetAll()
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

        public ISuppliersModel GetById(int id)
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

        public void Update(ISuppliersModel model)
        {
            var sqlQuery = "update Suppliers set Name=@Name, Link=@Link, Currency=@Currency, Notes=@Notes where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Link", model.Link);
                cmd.Parameters.AddWithValue("@Currency", model.Currency);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
