using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Products;
using Services.ProductsServices;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторій товарів
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {
        private string connectionString;

        /// <summary>
        /// Конструктор репозиторію товарів
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Додає товар
        /// </summary>
        /// <param name="productsModel">Екземпляр товару</param>
        public void Add(IProductsModel productsModel)
        {
            try
            {
                string sqlQuery = "insert into Products(SupplierId, CategoryId, GroupId, NameWebStore, NameSupplier, CodeWebStore, " +
            "CodeSupplier, UnitId, PriceWebStore, PriceSupplier, Available, LinkWebStore, LinkSupplier, Notes) " +
            "values(@SupplierId, @CategoryId, @GroupId, @NameWebStore, @NameSupplier,  @CodeWebStore, @CodeSupplier, " +
            "@UnitId, @PriceWebStore, @PriceSupplier, @Available, @LinkWebStore, @LinkSupplier, @Notes)";
                if (productsModel.GroupId == null)
                {
                    sqlQuery = sqlQuery.Replace("@GroupId, ", "");
                    sqlQuery = sqlQuery.Replace("GroupId, ", "");
                }
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@SupplierId", productsModel.SupplierId);
                    cmd.Parameters.AddWithValue("@CategoryId", productsModel.CategoryId);
                    if (productsModel.GroupId != null) cmd.Parameters.AddWithValue("@GroupId", productsModel.GroupId);
                    cmd.Parameters.AddWithValue("@NameWebStore", productsModel.NameWebStore);
                    cmd.Parameters.AddWithValue("@NameSupplier", productsModel.NameSupplier);
                    cmd.Parameters.AddWithValue("@CodeWebStore", productsModel.CodeWebStore);
                    cmd.Parameters.AddWithValue("@CodeSupplier", productsModel.CodeSupplier);
                    cmd.Parameters.AddWithValue("@UnitId", productsModel.UnitId);
                    cmd.Parameters.AddWithValue("@PriceWebStore", productsModel.PriceWebStore);
                    cmd.Parameters.AddWithValue("@PriceSupplier", productsModel.PriceSupplier);
                    cmd.Parameters.AddWithValue("@Available", productsModel.Available);
                    cmd.Parameters.AddWithValue("@LinkWebStore", productsModel.LinkWebStore);
                    cmd.Parameters.AddWithValue("@LinkSupplier", productsModel.LinkSupplier);
                    cmd.Parameters.AddWithValue("@Notes", productsModel.Notes);

                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка створення товару в базі даних.");
            }
        }

        /// <summary>
        /// Видаляє товар
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        public void DeleteById(int id)
        {
            try
            {
                string query = "delete from Products where Id=@Id";
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
                throw new Exception("Помилка видалення товару з бази даних.");
            }
        }

        /// <summary>
        /// Повертає список усіх товарів
        /// </summary>
        /// <returns>Список товарів</returns>
        public IEnumerable<IProductsModel> GetAll()
        {
            try
            {
                List<ProductsModel> products = new List<ProductsModel>();
                string query = "select Id, SupplierId, CategoryId, GroupId, UnitId, NameWebStore, NameSupplier, CodeWebStore, " +
                    "CodeSupplier, PriceWebStore, PriceSupplier, Available, LinkWebStore, LinkSupplier, Notes " +
                    "from Products";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    using (SqlCeCommand command = new SqlCeCommand(query, db))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductsModel product = new ProductsModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    SupplierId = Convert.ToInt32(reader["SupplierId"]),
                                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                    GroupId = reader.IsDBNull(reader.GetOrdinal("GroupId")) ? 0 : Convert.ToInt32(reader["GroupId"]),
                                    UnitId = Convert.ToInt32(reader["UnitId"]),
                                    NameWebStore = reader["NameWebStore"].ToString(),
                                    NameSupplier = reader["NameSupplier"].ToString(),
                                    CodeWebStore = reader["CodeWebStore"].ToString(),
                                    CodeSupplier = reader["CodeSupplier"].ToString(),
                                    PriceWebStore = Convert.ToDecimal(reader["PriceWebStore"]),
                                    PriceSupplier = Convert.ToDecimal(reader["PriceSupplier"]),
                                    Available = reader["Available"].ToString(),
                                    LinkWebStore = reader["LinkWebStore"].ToString(),
                                    LinkSupplier = reader["LinkSupplier"].ToString(),
                                    Notes = reader["Notes"].ToString()
                                };
                                products.Add(product);
                            }
                        }
                    }
                    db.Close();
                }
                return products;
            }
            catch (Exception)
            {
                throw new Exception("Помилка отримання списку товарів з бази даних.");
            }
        }

        /// <summary>
        /// Повертає товар по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        /// <returns>Екземпляр товару</returns>
        public IProductsModel GetById(int id)
        {
            try
            {
                ProductsModel product = new ProductsModel();
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    string query = "select Id, SupplierId, CategoryId, GroupId, UnitId, NameWebStore, NameSupplier, CodeWebStore, " +
                    "CodeSupplier, PriceWebStore, PriceSupplier, Available, LinkWebStore, LinkSupplier, Notes " +
                    "from Products where Id=@Id";
                    using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlCeDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                product.Id = Convert.ToInt32(reader["Id"]);
                                product.SupplierId = Convert.ToInt32(reader["SupplierId"]);
                                product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                                product.GroupId = reader.IsDBNull(reader.GetOrdinal("GroupId")) ? 0 : Convert.ToInt32(reader["GroupId"]);
                                product.UnitId = Convert.ToInt32(reader["UnitId"]);
                                product.NameWebStore = reader["NameWebStore"].ToString();
                                product.NameSupplier = reader["NameSupplier"].ToString();
                                product.CodeWebStore = reader["CodeWebStore"].ToString();
                                product.CodeSupplier = reader["CodeSupplier"].ToString();
                                product.PriceWebStore = Convert.ToDecimal(reader["PriceWebStore"]);
                                product.PriceSupplier = Convert.ToDecimal(reader["PriceSupplier"]);
                                product.Available = reader["Available"].ToString();
                                product.LinkWebStore = reader["LinkWebStore"].ToString();
                                product.LinkSupplier = reader["LinkSupplier"].ToString();
                                product.Notes = reader["Notes"].ToString();
                            }
                        }
                    }
                    db.Close();
                }
                return product;
            }
            catch (Exception)
            {
                throw new Exception("Помилка отримання товару з бази даних.");
            }
        }

        /// <summary>
        /// Оновлює товар
        /// </summary>
        /// <param name="productsModel">Екземпляр товару</param>
        public void Update(IProductsModel productsModel)
        {
            try
            {
                var sqlQuery = "update Products set SupplierId=@SupplierId, CategoryId=@CategoryId, GroupId=@GroupId, " +
            "NameWebStore=@NameWebStore, NameSupplier=@NameSupplier, CodeWebStore=@CodeWebStore, CodeSupplier=@CodeSupplier, " +
            "UnitId=@UnitId, PriceWebStore=@PriceWebStore, PriceSupplier=@PriceSupplier, Available=@Available, " +
            "LinkWebStore=@LinkWebStore, LinkSupplier=@LinkSupplier, Notes=@Notes where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@SupplierId", productsModel.SupplierId);
                    cmd.Parameters.AddWithValue("@CategoryId", productsModel.CategoryId);
                    if (productsModel.GroupId != null) cmd.Parameters.AddWithValue("@GroupId", productsModel.GroupId);
                    cmd.Parameters.AddWithValue("@NameWebStore", productsModel.NameWebStore);
                    cmd.Parameters.AddWithValue("@NameSupplier", productsModel.NameSupplier);
                    cmd.Parameters.AddWithValue("@CodeWebStore", productsModel.CodeWebStore);
                    cmd.Parameters.AddWithValue("@CodeSupplier", productsModel.CodeSupplier);
                    cmd.Parameters.AddWithValue("@UnitId", productsModel.UnitId);
                    cmd.Parameters.AddWithValue("@PriceWebStore", productsModel.PriceWebStore);
                    cmd.Parameters.AddWithValue("@PriceSupplier", productsModel.PriceSupplier);
                    cmd.Parameters.AddWithValue("@Available", productsModel.Available);
                    cmd.Parameters.AddWithValue("@LinkWebStore", productsModel.LinkWebStore);
                    cmd.Parameters.AddWithValue("@LinkSupplier", productsModel.LinkSupplier);
                    cmd.Parameters.AddWithValue("@Notes", productsModel.Notes);
                    cmd.Parameters.AddWithValue("@Id", productsModel.Id);

                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення товару в базі даних.");
            }
        }
    }
}
