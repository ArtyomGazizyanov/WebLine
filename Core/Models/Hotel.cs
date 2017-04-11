using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Core.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int State { get; set; }

        public void Save(SqlString sqlString)
        {
            using (SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sqlString.ToString();
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                }
            }
        }

        public static void AddNew()
        {

        }

        public static void Delete(int id)
        {
            try
            {
                using (SqlConnection connection = DBConfiguration.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("DELETE FROM Hotels WHERE id =" + id, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        

        public void SetData(SqlDataReader reader)
        {
            Name = reader["name"].ToString();
            Address = reader["addres"].ToString();
            Phone = reader["phone"].ToString();
            HotelId = reader.GetInt32(reader.GetOrdinal("id"));
            Email = reader["email"].ToString();
            State = reader.GetInt32(reader.GetOrdinal("state"));
        }        
    }
}
