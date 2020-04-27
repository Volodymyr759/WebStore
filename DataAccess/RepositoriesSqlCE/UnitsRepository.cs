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

        public void Add(IUnitsModel unitsModel)
        {
            string sqlQuery = $"insert into Units(Name, Notes) values('{unitsModel.Name}', '{unitsModel.Notes}')";
            using (var db = new SqlCeConnection(connectionString))
            {
                var cmd = new SqlCeCommand(sqlQuery, db);
                db.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteById(int id)
        {
            string query = $"delete from Units where Id={id}";
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                SqlCeCommand command = new SqlCeCommand(query, db);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<IUnitsModel> GetAll()
        {
            var listUnitsModel = new List<UnitsModel>();
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
                            listUnitsModel.Add(unit);
                        }
                    }
                }
            }
            return listUnitsModel;
        }

        public UnitsModel GetById(int id)
        {
            UnitsModel unit = new UnitsModel();
            using (var db = new SqlCeConnection(connectionString))
            {
                db.Open();
                string query = $"select Id, Name, Notes from Units where Id={@id}";
                using (SqlCeCommand command = new SqlCeCommand(query, db))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            unit.Id = Convert.ToInt32(reader["Id"]);
                            unit.Name = reader["Name"].ToString();
                            unit.Notes = reader["Notes"].ToString();
                        }
                    }
                }
            }
            return unit;
        }

        public void Update(IUnitsModel unitsModel)
        {
            var sqlQuery = $"update Units set Name='{unitsModel.Name}', Notes='{unitsModel.Notes}' where Id={unitsModel.Id}";
            using (var db = new SqlCeConnection(connectionString))
            {
                var cmd = new SqlCeCommand(sqlQuery, db);
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }
    }
}
