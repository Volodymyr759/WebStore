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
        private string connectionString;

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
            try
            {
                string sqlQuery = "insert into Images(ProductId, FileName, LinkWebStore, LinkSupplier, LocalPath) " +
            "values(@ProductId, @FileName, @LinkWebStore, @LinkSupplier, @LocalPath)";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ProductId", imagesModel.ProductId);
                    cmd.Parameters.AddWithValue("@FileName", imagesModel.FileName);
                    cmd.Parameters.AddWithValue("@LinkWebStore", imagesModel.LinkWebStore);
                    cmd.Parameters.AddWithValue("@LinkSupplier", imagesModel.LinkSupplier);
                    cmd.Parameters.AddWithValue("@LocalPath", imagesModel.LocalPath);
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка створення зображення в базі даних.");
            }
        }

        /// <summary>
        /// Видаляє зображення
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        public void DeleteById(int id)
        {
            try
            {
                string query = "delete from Images where Id=@Id";
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
                throw new Exception("Помилка видалення зображення з бази даних.");
            }
        }

        /// <summary>
        /// Повертає список усіх зображень
        /// </summary>
        /// <returns>Список зображень</returns>
        public IEnumerable<IImagesModel> GetAll()
        {
            try
            {
                List<ImagesModel> images = new List<ImagesModel>();
                string query = "select Id, ProductId, FileName, LinkWebStore, LinkSupplier, LocalPath from Images";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    using (SqlCeCommand command = new SqlCeCommand(query, db))
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
                    db.Close();
                }
                return images;
            }
            catch
            {
                throw new Exception("Помилка отримання списку зображень з бази даних.");
            }
        }

        /// <summary>
        /// Повертає зображення по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        public IImagesModel GetById(int id)
        {
            try
            {
                ImagesModel image = new ImagesModel();
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    string query = "select Id, ProductId, FileName, LinkWebStore, LinkSupplier, LocalPath " +
                        "from Images where Id=@Id";
                    using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", id);
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
                    db.Close();
                }
                return image;
            }
            catch
            {
                throw new Exception("Помилка отримання зображення з бази даних.");
            }
        }

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imagesModel">Екземпляр зображення</param>
        public void Update(IImagesModel imagesModel)
        {
            try
            {
                var sqlQuery = "update Images set ProductId=@ProductId, FileName=@FileName, LinkWebStore=@LinkWebStore, " +
            "LinkSupplier=@LinkSupplier, LocalPath=@LocalPath where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ProductId", imagesModel.ProductId);
                    cmd.Parameters.AddWithValue("@FileName", imagesModel.FileName);
                    cmd.Parameters.AddWithValue("@LinkWebStore", imagesModel.LinkWebStore);
                    cmd.Parameters.AddWithValue("@LinkSupplier", imagesModel.LinkSupplier);
                    cmd.Parameters.AddWithValue("@LocalPath", imagesModel.LocalPath);
                    cmd.Parameters.AddWithValue("@Id", imagesModel.Id);

                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення зображення в базі даних.");
            }
        }
    }
}
