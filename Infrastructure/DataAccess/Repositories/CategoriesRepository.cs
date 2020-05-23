using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Categories;
using Services.CategoriesServices;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторій категорій
    /// </summary>
    public class CategoriesRepository : ICategoriesRepository
    {
        private string connectionString;

        /// <summary>
        /// Конструктор репозиторію категорій
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public CategoriesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Додає категорію
        /// </summary>
        /// <param name="categoriesModel">Екземпляр категорії</param>
        public void Add(ICategoriesModel categoriesModel)
        {
            try
            {
                string sqlQuery = "insert into Categories(Name, SupplierId, Link, Rate, Notes) values(@Name, @SupplierId, @Link, @Rate, @Notes)";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", categoriesModel.Name);
                    cmd.Parameters.AddWithValue("@SupplierId", categoriesModel.SupplierId);
                    cmd.Parameters.AddWithValue("@Link", categoriesModel.Link);
                    cmd.Parameters.AddWithValue("@Rate", categoriesModel.Rate);
                    cmd.Parameters.AddWithValue("@Notes", categoriesModel.Notes);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка створення категорії в базі даних.");
            }
        }

        /// <summary>
        /// Видаляє категорію
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        public void DeleteById(int id)
        {
            try
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
            catch
            {
                throw new Exception("Помилка видалення категорії з бази даних.");
            }
        }

        /// <summary>
        /// Повертає список усіх категорій
        /// </summary>
        /// <returns>Список категорій</returns>
        public IEnumerable<ICategoriesModel> GetAll()
        {
            try
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
                                    SupplierId = Convert.ToInt32(reader["SupplierId"]),
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
            catch
            {
                throw new Exception("Помилка отримання списку категорій з бази даних.");
            }
        }

        /// <summary>
        /// Повертає категорію по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        public ICategoriesModel GetById(int id)
        {
            try
            {
                CategoriesModel category = new CategoriesModel();
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    string query = "select Id, Name, SupplierId, Link, Rate, Notes from Categories where Id=@Id";
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
                                category.SupplierId = Convert.ToInt32(reader["SupplierId"]);
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
            catch
            {
                throw new Exception("Помилка отримання категорії з бази даних.");
            }
        }

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoriesModel">Екземпляр категорії</param>
        public void Update(ICategoriesModel categoriesModel)
        {
            try
            {
                var sqlQuery = "update Categories set Name=@Name, SupplierId=@SupplierId, Link=@Link, Rate=@Rate, Notes=@Notes where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", categoriesModel.Name);
                    cmd.Parameters.AddWithValue("@SupplierId", categoriesModel.SupplierId);
                    cmd.Parameters.AddWithValue("@Link", categoriesModel.Link);
                    cmd.Parameters.AddWithValue("@Rate", categoriesModel.Rate);
                    cmd.Parameters.AddWithValue("@Notes", categoriesModel.Notes);
                    cmd.Parameters.AddWithValue("@Id", categoriesModel.Id);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення категорії в базі даних.");
            }
        }
    }
}
