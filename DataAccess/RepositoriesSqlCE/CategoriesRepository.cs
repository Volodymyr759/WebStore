using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Categories;
using Domain.Models.Suppliers;
using Services.CategoriesService;

namespace DataAccess.RepositoriesSqlCE
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private string connectionString;

        public CategoriesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(ICategoriesModel model)
        {
            string sqlQuery = "insert into Categories(Name, SupplierId, Link, Rate, Notes) values(@Name, @SupplierId, @Link, @Rate, @Notes)";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@SupplierId", model.SupplierId);
                cmd.Parameters.AddWithValue("@Link", model.Link);
                cmd.Parameters.AddWithValue("@Rate", model.Rate);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteById(int id)
        {
            string query = "delete from Categories where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                SqlCeCommand cmd = new SqlCeCommand(query, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ICategoriesModel> GetAll()
        {
            var listcategoriesDto = new List<CategoriesModel>();
            string query = "select Id, Name, SupplierId, Link, Rate, Notes from Categories order by Name";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoryDto = new CategoriesModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                SupplierId =Convert.ToInt32(reader["SupplierId"]),
                                Link = reader["Link"].ToString(),
                                Rate = Convert.ToDecimal(reader["Rate"]),
                                Notes = reader["Notes"].ToString()
                            };
                            listcategoriesDto.Add(categoryDto);
                        }
                    }
                }
                db.Close();
            }
            return listcategoriesDto;
        }

        public ICategoriesModel GetById(int id)
        {
            CategoriesModel category = new CategoriesModel();
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                string query = "select Id, Name, SupplierId, Link, Rate, Notes from Categories where c.Id=@Id";
                using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            category.Id = Convert.ToInt32(reader["Id"]);
                            category.Name = reader["Name"].ToString();
                            category.SupplierId =Convert.ToInt32(reader["SupplierId"]);
                            category.Link = reader["Link"].ToString();
                            category.Rate = Convert.ToDecimal(reader["Rate"]);
                            category.Notes = reader["Notes"].ToString();
                        }
                    }
                }
                db.Close();
            }
            return category;
        }

        public void Update(ICategoriesModel model)
        {
            var sqlQuery = "update Categories set Name=@Name, SupplierId=@SupplierId, Link=@Link, Rate=@Rate, Notes=@Notes where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@SupplierId", model.SupplierId);
                cmd.Parameters.AddWithValue("@Link", model.Link);
                cmd.Parameters.AddWithValue("@Rate", model.Rate);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
