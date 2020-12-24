using DogGo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Repositories
{
    public class WalkStatusRepository : IWalkStatusRepository
    {
        //////////// Begin Config ////////////
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalkStatusRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        ///////////// End Config /////////////
        
        public List<WalkStatus> GetWalkStatuses()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Description FROM WalkStatus";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<WalkStatus> walkStatuses = new List<WalkStatus>();
                    while (reader.Read())
                    {
                        WalkStatus walkStatus = new WalkStatus
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Description = reader.GetString(reader.GetOrdinal("Description"))
                        };
                        walkStatuses.Add(walkStatus);
                    }
                    reader.Close();
                    return walkStatuses;
                }
            }
        }

    }
}
