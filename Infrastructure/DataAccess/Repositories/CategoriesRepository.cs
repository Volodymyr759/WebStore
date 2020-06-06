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
        private readonly string connectionString;

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

                string sqlQuery = "insert into Categories(Name, SupplierId, Link, Rate, Notes) values(@Name, @SupplierId, @Link, @Rate, @Notes)";
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", categoriesModel.Name);
                cmd.Parameters.AddWithValue("@SupplierId", categoriesModel.SupplierId);
                cmd.Parameters.AddWithValue("@Link", categoriesModel.Link);
                cmd.Parameters.AddWithValue("@Rate", categoriesModel.Rate);
                cmd.Parameters.AddWithValue("@Notes", categoriesModel.Notes);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка створення категорії в базі даних.");
                }
            }
        }

        /// <summary>
        /// Видаляє категорію
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
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

                string query = "delete from Categories where Id=@Id";
                SqlCeCommand cmd = new SqlCeCommand(query, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка видалення категорії з бази даних.");
                }
            }
        }

        /// <summary>
        /// Повертає список усіх категорій
        /// </summary>
        /// <returns>Список категорій</returns>
        public IEnumerable<ICategoriesModel> GetAll()
        {
            var listcategoriesDto = new List<CategoriesModel>();
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

                string query = "select Id, Name, SupplierId, Link, Rate, Notes from Categories order by Name";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
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
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання списку категорій з бази даних.");
                    }
                }
            }
            return listcategoriesDto;
        }

        /// <summary>
        /// Повертає категорію по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        public ICategoriesModel GetById(int id)
        {
            CategoriesModel category = new CategoriesModel();
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

                string query = "select Id, Name, SupplierId, Link, Rate, Notes from Categories where Id=@Id";
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
                                category.Id = Convert.ToInt32(reader["Id"]);
                                category.Name = reader["Name"].ToString();
                                category.SupplierId = Convert.ToInt32(reader["SupplierId"]);
                                category.Link = reader["Link"].ToString();
                                category.Rate = Convert.ToDecimal(reader["Rate"]);
                                category.Notes = reader["Notes"].ToString();
                            }
                        }

                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання категорії з бази даних.");
                    }
                }
            }
            return category;
        }

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoriesModel">Екземпляр категорії</param>
        public void Update(ICategoriesModel categoriesModel)
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

                string sqlQuery = "update Categories set Name=@Name, SupplierId=@SupplierId, Link=@Link, Rate=@Rate, Notes=@Notes where Id=@Id";
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", categoriesModel.Name);
                cmd.Parameters.AddWithValue("@SupplierId", categoriesModel.SupplierId);
                cmd.Parameters.AddWithValue("@Link", categoriesModel.Link);
                cmd.Parameters.AddWithValue("@Rate", categoriesModel.Rate);
                cmd.Parameters.AddWithValue("@Notes", categoriesModel.Notes);
                cmd.Parameters.AddWithValue("@Id", categoriesModel.Id);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка оновлення категорії в базі даних.");
                }
            }
        }
    }
}
