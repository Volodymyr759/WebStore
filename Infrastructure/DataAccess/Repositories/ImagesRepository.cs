using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Images;
using Services.ImagesServices;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторій зображень
    /// </summary>
    public class ImagesRepository : IImagesRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Конструктор репозиторію зображень
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public ImagesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Додає зображення
        /// </summary>
        /// <param name="imagesModel">Екземпляр зображення</param>
        public void Add(IImagesModel imagesModel)
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

                string sqlQuery = "insert into Images(ProductId, FileName, LinkWebStore, LinkSupplier, LocalPath) " +
                    "values(@ProductId, @FileName, @LinkWebStore, @LinkSupplier, @LocalPath)";
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ProductId", imagesModel.ProductId);
                cmd.Parameters.AddWithValue("@FileName", imagesModel.FileName);
                cmd.Parameters.AddWithValue("@LinkWebStore", imagesModel.LinkWebStore);
                cmd.Parameters.AddWithValue("@LinkSupplier", imagesModel.LinkSupplier);
                cmd.Parameters.AddWithValue("@LocalPath", imagesModel.LocalPath);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка створення зображення в базі даних.");
                }
            }
        }

        /// <summary>
        /// Видаляє зображення
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
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

                string query = "delete from Images where Id=@Id";
                SqlCeCommand cmd = new SqlCeCommand(query, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException)
                {
                    throw new Exception("Помилка видалення зображення з бази даних.");
                }
            }
        }

        /// <summary>
        /// Повертає список усіх зображень
        /// </summary>
        /// <returns>Список зображень</returns>
        public IEnumerable<IImagesModel> GetAll()
        {
            List<ImagesModel> images = new List<ImagesModel>();
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

                string query = "select Id, ProductId, FileName, LinkWebStore, LinkSupplier, LocalPath from Images";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    try
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ImagesModel image = new ImagesModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    FileName = reader["FileName"].ToString(),
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    LinkWebStore = reader["LinkWebStore"].ToString(),
                                    LinkSupplier = reader["LinkSupplier"].ToString(),
                                    LocalPath = reader["LocalPath"].ToString()
                                };
                                images.Add(image);
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання списку зображень з бази даних.");
                    }
                }
            }
            return images;
        }

        /// <summary>
        /// Повертає зображення по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        public IImagesModel GetById(int id)
        {
            ImagesModel image = new ImagesModel();
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

                string query = "select Id, ProductId, FileName, LinkWebStore, LinkSupplier, LocalPath " +
                    "from Images where Id=@Id";
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
                                image.Id = Convert.ToInt32(reader["Id"]);
                                image.FileName = reader["FileName"].ToString();
                                image.ProductId = Convert.ToInt32(reader["ProductId"]);
                                image.LinkWebStore = reader["LinkWebStore"].ToString();
                                image.LinkSupplier = reader["LinkSupplier"].ToString();
                                image.LocalPath = reader["LocalPath"].ToString();
                            }
                        }
                    }
                    catch (SqlCeException)
                    {
                        throw new Exception("Помилка отримання зображення з бази даних.");
                    }
                }
            }
            return image;
        }

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imagesModel">Екземпляр зображення</param>
        public void Update(IImagesModel imagesModel)
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

                var sqlQuery = "update Images set ProductId=@ProductId, FileName=@FileName, LinkWebStore=@LinkWebStore, " +
                    "LinkSupplier=@LinkSupplier, LocalPath=@LocalPath where Id=@Id";
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ProductId", imagesModel.ProductId);
                cmd.Parameters.AddWithValue("@FileName", imagesModel.FileName);
                cmd.Parameters.AddWithValue("@LinkWebStore", imagesModel.LinkWebStore);
                cmd.Parameters.AddWithValue("@LinkSupplier", imagesModel.LinkSupplier);
                cmd.Parameters.AddWithValue("@LocalPath", imagesModel.LocalPath);
                cmd.Parameters.AddWithValue("@Id", imagesModel.Id);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new Exception("Помилка оновлення зображення в базі даних.");
                }
            }
        }
    }
}
