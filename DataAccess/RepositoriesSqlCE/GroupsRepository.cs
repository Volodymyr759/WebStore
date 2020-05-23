using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Groups;
using Services.GroupsService;

namespace DataAccess.RepositoriesSqlCE
{
    public class GroupsRepository : IGroupsRepository
    {
        private string connectionString;

        public GroupsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IGroupsModel model)
        {
            string sqlQuery = "insert into Groups(Name, Number, Identifier, AncestorNumber, AncestorIdentifier, ProductType, Link, Notes) " + 
                "values(@Name, @Number, @Identifier, @AncestorNumber, @AncestorIdentifier, @ProductType, @Link, @Notes)";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Number", model.Number);
                cmd.Parameters.AddWithValue("@Identifier", model.Identifier);
                cmd.Parameters.AddWithValue("@AncestorNumber", model.AncestorNumber);
                cmd.Parameters.AddWithValue("@AncestorIdentifier", model.AncestorIdentifier);
                cmd.Parameters.AddWithValue("@ProductType", model.ProductType);
                cmd.Parameters.AddWithValue("@Link", model.Link);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);

                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteById(int id)
        {
            string query = "delete from Groups where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(query, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public IEnumerable<IGroupsModel> GetAll()
        {
            var listgroupsModel = new List<GroupsModel>();
            string query = "select * from Groups";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GroupsModel group = new GroupsModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Number = reader["Number"].ToString(),
                                Identifier = reader["Identifier"].ToString(),
                                AncestorNumber = reader["AncestorNumber"].ToString(),
                                AncestorIdentifier = reader["AncestorIdentifier"].ToString(),
                                ProductType = reader["ProductType"].ToString(),
                                Link = reader["Link"].ToString(),
                                Notes = reader["Notes"].ToString()
                            };
                            listgroupsModel.Add(group);
                        }
                    }
                }
                db.Close();
            }
            return listgroupsModel;
        }

        public IGroupsModel GetById(int id)
        {
            GroupsModel group = new GroupsModel();
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                string query = "select Id, Name, Number, Identifier, AncestorNumber, AncestorIdentifier, ProductType, Link, Notes from Groups where Id=@Id";
                using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            group.Id = Convert.ToInt32(reader["Id"]);
                            group.Name = reader["Name"].ToString();
                            group.Number = reader["Number"].ToString();
                            group.Identifier = reader["Identifier"].ToString();
                            group.AncestorNumber = reader["AncestorNumber"].ToString();
                            group.AncestorIdentifier = reader["AncestorIdentifier"].ToString();
                            group.ProductType = reader["ProductType"].ToString();
                            group.Link = reader["Link"].ToString();
                            group.Notes = reader["Notes"].ToString();
                        }
                    }
                }
                db.Close();
            }
            return group;
        }

        public void Update(IGroupsModel model)
        {
            var sqlQuery = "update Groups set Name=@Name, Number=@Number, Identifier=@Identifier, AncestorNumber=@AncestorNumber, "+
                "AncestorIdentifier=@AncestorIdentifier, ProductType=@ProductType, Link=@Link,  Notes=@Notes where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Number", model.Number);
                cmd.Parameters.AddWithValue("@Identifier", model.Identifier);
                cmd.Parameters.AddWithValue("@AncestorNumber", model.AncestorNumber);
                cmd.Parameters.AddWithValue("@AncestorIdentifier", model.AncestorIdentifier);
                cmd.Parameters.AddWithValue("@ProductType", model.ProductType);
                cmd.Parameters.AddWithValue("@Link", model.Link);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.Parameters.AddWithValue("@Id", model.Id);

                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
