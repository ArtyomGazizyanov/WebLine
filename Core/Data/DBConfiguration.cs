using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Core
{
    class DBConfiguration
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["HotelBD"].ConnectionString;
        }
     
        public static SqlConnection GetConnection()
        {
            var sqlConnection = new SqlConnection(GetConnectionString());
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}