using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Categories;
using Domain.Models.Groups;
using Domain.Models.Products;
using Domain.Models.Suppliers;
using Domain.Models.Units;
using Services.ProductsService;

namespace DataAccess.RepositoriesSqlCE
{
    public class ProductsRepository : IProductsRepository
    {
        private string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IProductsModel model)
        {
            string sqlQuery = "insert into Products(SupplierId, CategoryId, GroupId, NameWebStore, NameSupplier, CodeWebStore, " +
                "CodeSupplier, UnitId, PriceWebStore, PriceSupplier, Available, LinkWebStore, LinkSupplier, Notes) " +
                "values(@SupplierId, @CategoryId, @GroupId, @NameWebStore, @NameSupplier,  @CodeWebStore, @CodeSupplier, " +
                "@UnitId, @PriceWebStore, @PriceSupplier, @Available, @LinkWebStore, @LinkSupplier, @Notes)";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@SupplierId", model.SupplierId);
                cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                cmd.Parameters.AddWithValue("@GroupId", model.GroupId);
                cmd.Parameters.AddWithValue("@NameWebStore", model.NameWebStore);
                cmd.Parameters.AddWithValue("@NameSupplier", model.NameSupplier);
                cmd.Parameters.AddWithValue("@CodeWebStore", model.CodeWebStore);
                cmd.Parameters.AddWithValue("@CodeSupplier", model.CodeSupplier);
                cmd.Parameters.AddWithValue("@UnitId", model.UnitId);
                cmd.Parameters.AddWithValue("@PriceWebStore", model.PriceWebStore);
                cmd.Parameters.AddWithValue("@PriceSupplier", model.PriceSupplier);
                cmd.Parameters.AddWithValue("@Available", model.Available);
                cmd.Parameters.AddWithValue("@LinkWebStore", model.LinkWebStore);
                cmd.Parameters.AddWithValue("@LinkSupplier", model.LinkSupplier);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);

                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteById(int id)
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

        public IEnumerable<IProductsModel> GetAll()
        {
            List<ProductsModel> products = new List<ProductsModel>();
            string query = "select Id, SupplierId, CategoryId, GroupId, UnitId, NameWebStore, CodeWebStore, " +
                "CodeSupplier, PriceWebStore, PriceSupplier, p.Available, LinkWebStore, LinkSupplier, Notes " +
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
                                GroupId = Convert.ToInt32(reader["GroupId"]),
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

        public IProductsModel GetById(int id)
        {
            ProductsModel product = new ProductsModel();
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                string query = "select Id, SupplierId, CategoryId, GroupId, UnitId, NameWebStore, CodeWebStore, " +
                "CodeSupplier, PriceWebStore, PriceSupplier, p.Available, LinkWebStore, LinkSupplier, Notes " +
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
                            product.GroupId = Convert.ToInt32(reader["GroupId"]);
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

        public void Update(IProductsModel model)
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
                cmd.Parameters.AddWithValue("@SupplierId", model.SupplierId);
                cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                cmd.Parameters.AddWithValue("@GroupId", model.GroupId);
                cmd.Parameters.AddWithValue("@NameWebStore", model.NameWebStore);
                cmd.Parameters.AddWithValue("@NameSupplier", model.NameSupplier);
                cmd.Parameters.AddWithValue("@CodeWebStore", model.CodeWebStore);
                cmd.Parameters.AddWithValue("@CodeSupplier", model.CodeSupplier);
                cmd.Parameters.AddWithValue("@UnitId", model.UnitId);
                cmd.Parameters.AddWithValue("@PriceWebStore", model.PriceWebStore);
                cmd.Parameters.AddWithValue("@PriceSupplier", model.PriceSupplier);
                cmd.Parameters.AddWithValue("@Available", model.Available);
                cmd.Parameters.AddWithValue("@LinkWebStore", model.LinkWebStore);
                cmd.Parameters.AddWithValue("@LinkSupplier", model.LinkSupplier);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public IEnumerable<IProductsModel> GetProductsWithoutParameters()
        {
            throw new NotImplementedException();
        }
    }
}
