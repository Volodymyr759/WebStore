using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Domain.Models.Groups;
using Services.GroupsServices;

namespace Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторій груп товарів власного каталогу
    /// </summary>
    public class GroupsRepository : IGroupsRepository
    {
        private string connectionString;

        /// <summary>
        /// Конструктор репозиторію груп товарів
        /// </summary>
        /// <param name="connectionString">Строка підключення</param>
        public GroupsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Додає групу
        /// </summary>
        /// <param name="groupsModel">Екземпляр групи</param>
        public void Add(IGroupsModel groupsModel)
        {
            try
            {
                string sqlQuery = "insert into Groups(Name, Number, Identifier, AncestorNumber, AncestorIdentifier, ProductType, Link, Notes) " +
            "values(@Name, @Number, @Identifier, @AncestorNumber, @AncestorIdentifier, @ProductType, @Link, @Notes)";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", groupsModel.Name);
                    cmd.Parameters.AddWithValue("@Number", groupsModel.Number);
                    cmd.Parameters.AddWithValue("@Identifier", groupsModel.Identifier);
                    cmd.Parameters.AddWithValue("@AncestorNumber", groupsModel.AncestorNumber);
                    cmd.Parameters.AddWithValue("@AncestorIdentifier", groupsModel.AncestorIdentifier);
                    cmd.Parameters.AddWithValue("@ProductType", groupsModel.ProductType);
                    cmd.Parameters.AddWithValue("@Link", groupsModel.Link);
                    cmd.Parameters.AddWithValue("@Notes", groupsModel.Notes);

                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка створення групи в базі даних.");
            }
        }

        /// <summary>
        /// Видаляє групу
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        public void DeleteById(int id)
        {
            try
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
            catch
            {
                throw new Exception("Помилка видалення групи з бази даних.");
            }
        }

        /// <summary>
        /// Повертає список усіх груп
        /// </summary>
        /// <returns>Список груп</returns>
        public IEnumerable<IGroupsModel> GetAll()
        {
            try
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
            catch
            {
                throw new Exception("Помилка отримання списку груп з бази даних.");
            }
        }

        /// <summary>
        /// Повертає групу по ідентифікатору
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        /// <returns>Екземпляр групи</returns>
        public IGroupsModel GetById(int id)
        {
            try
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
            catch
            {
                throw new Exception("Помилка отримання групи з бази даних.");
            }
        }

        /// <summary>
        /// Оновлює групу
        /// </summary>
        /// <param name="groupsModel">Екземпляр групи</param>
        public void Update(IGroupsModel groupsModel)
        {
            try
            {
                var sqlQuery = "update Groups set Name=@Name, Number=@Number, Identifier=@Identifier, AncestorNumber=@AncestorNumber, " +
            "AncestorIdentifier=@AncestorIdentifier, ProductType=@ProductType, Link=@Link,  Notes=@Notes where Id=@Id";
                using (var db = new SqlCeConnection(connectionString))
                {
                    db.Open();
                    var cmd = new SqlCeCommand(sqlQuery, db);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Name", groupsModel.Name);
                    cmd.Parameters.AddWithValue("@Number", groupsModel.Number);
                    cmd.Parameters.AddWithValue("@Identifier", groupsModel.Identifier);
                    cmd.Parameters.AddWithValue("@AncestorNumber", groupsModel.AncestorNumber);
                    cmd.Parameters.AddWithValue("@AncestorIdentifier", groupsModel.AncestorIdentifier);
                    cmd.Parameters.AddWithValue("@ProductType", groupsModel.ProductType);
                    cmd.Parameters.AddWithValue("@Link", groupsModel.Link);
                    cmd.Parameters.AddWithValue("@Notes", groupsModel.Notes);
                    cmd.Parameters.AddWithValue("@Id", groupsModel.Id);

                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            catch
            {
                throw new Exception("Помилка оновлення групи в базі даних.");
            }
        }
    }
}
