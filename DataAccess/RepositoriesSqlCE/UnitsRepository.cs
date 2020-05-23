using System;
using System.Collections.Generic;
using Services.UnitsService;
using Domain.Models.Units;
using System.Data.SqlServerCe;

namespace DataAccess.RepositoriesSqlCE
{
    public class UnitsRepository : IUnitsRepository
    {
        private string connectionString;

        #region Constructors

        public UnitsRepository()
        {
        }

        public UnitsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        public void Add(IUnitsModel model)
        {
            string sqlQuery = "insert into Units(Name, Notes) values(@Name, @Notes)";
            using (var db = new SqlCeConnection(connectionString))
            {
                var cmd = new SqlCeCommand(sqlQuery, db);
                db.Open();
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        public void DeleteById(int id)
        {
            string query = "delete from Units where Id=@Id";
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

        public IEnumerable<IUnitsModel> GetAll()
        {
            List<UnitsModel> units = new List<UnitsModel>();
            string query = "select * from Units";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UnitsModel unit = new UnitsModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Notes = reader["Notes"].ToString()
                            };
                            units.Add(unit);
                        }
                    }
                }
                db.Close();
            }
            return units;
        }

        public IUnitsModel GetById(int id)
        {
            UnitsModel unit = new UnitsModel();
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                string query = "select Id, Name, Notes from Units where Id=@Id";
                using (SqlCeCommand cmd = new SqlCeCommand(query, db))
                {
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            unit.Id = Convert.ToInt32(reader["Id"]);
                            unit.Name = reader["Name"].ToString();
                            unit.Notes = reader["Notes"].ToString();
                        }
                    }
                }
                db.Close();
            }
            return unit;
        }

        public void Update(IUnitsModel model)
        {
            var sqlQuery = "update Units set Name=@Name, Notes=@Notes where Id=@Id";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                var cmd = new SqlCeCommand(sqlQuery, db);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
