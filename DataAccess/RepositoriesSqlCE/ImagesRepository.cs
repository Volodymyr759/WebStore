using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Images;
using Domain.Models.Products;
using Services.ImagesService;

namespace DataAccess.RepositoriesSqlCE
{
    public class ImagesRepository : IImagesRepository
    {
        private string connectionString;

        public ImagesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IImagesModel model)
        {
            string sqlQuery = "insert into Images(ProductId, FileName, LinkWebStore, LinkSupplier, LocalPath) " +
                "values(@ProductId, @FileName, @LinkWebStore, @LinkSupplier, @LocalPath)";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                cmd.Parameters.AddWithValue("@FileName", model.FileName);
                cmd.Parameters.AddWithValue("@LinkWebStore", model.LinkWebStore);
                cmd.Parameters.AddWithValue("@LinkSupplier", model.LinkSupplier);
                cmd.Parameters.AddWithValue("@LocalPath", model.LocalPath);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteById(int id)
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

        public IEnumerable<IImagesModel> GetAll()
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
                                ProductId =Convert.ToInt32(reader["ProductId"]),
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

        public IImagesModel GetById(int id)
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

        public void Update(IImagesModel model)
        {
            var sqlQuery = "update Images set ProductId=@ProductId, FileName=@FileName, LinkWebStore=@LinkWebStore, " +
                "LinkSupplier=@LinkSupplier, LocalPath=@LocalPath where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                cmd.Parameters.AddWithValue("@FileName", model.FileName);
                cmd.Parameters.AddWithValue("@LinkWebStore", model.LinkWebStore);
                cmd.Parameters.AddWithValue("@LinkSupplier", model.LinkSupplier);
                cmd.Parameters.AddWithValue("@LocalPath", model.LocalPath);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
