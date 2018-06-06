using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Zadacha.Models
{
    public class DbContext
    {
        public string ConnectionString { get; set; }
        public string Table=null;

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Album> GetAllAlbums()
        {
            Table = "equipmenttype";
          
            List<Album> list = new List<Album>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from "+Table.ToString()+"", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Album()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<eqpm> GetAllEqpm(int searchcriteria)
        {
            Table = "equipment";
            List<eqpm> list = new List<eqpm>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from " + Table.ToString() + " WHERE equipmentType="+searchcriteria+"", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new eqpm()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            equipmentType = Convert.ToInt32(reader["equipmentType"]),
                            name = reader["name"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
