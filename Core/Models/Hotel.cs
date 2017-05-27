using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Web.Script.Serialization;
using System.Data;

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

        public Hotel()
        {
        }


        private void Update( SqlConnection connection )
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.Parameters.Add( "@hotelId", SqlDbType.Int ).Value = this.HotelId;
            cmd.Parameters.Add( "@hotelName", SqlDbType.VarChar ).Value = this.Name;
            cmd.Parameters.Add( "@phone", SqlDbType.VarChar ).Value = this.Phone;
            cmd.Parameters.Add( "@state", SqlDbType.Int ).Value = this.State;
            cmd.Parameters.Add( "@address", SqlDbType.VarChar ).Value = this.Address;
            cmd.Parameters.Add( "@email", SqlDbType.VarChar ).Value = this.Email;
            cmd.CommandText = ( @"UPDATE Hotels 
                                   SET name = @hotelName, 
                                    addres = @address, 
                                    phone = @phone, 
                                    email = @email,   
                                    state = @state 
                                   WHERE hotelId = @hotelId" );
            using ( cmd.ExecuteReader() )
            {
            }
        }
        public void Add( SqlConnection connection )
        { 
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@hotelName", SqlDbType.VarChar ).Value = this.Name;
                cmd.Parameters.Add( "@phone", SqlDbType.VarChar ).Value = this.Phone;
                cmd.Parameters.Add( "@state", SqlDbType.Int ).Value = this.State;
                cmd.Parameters.Add( "@address", SqlDbType.VarChar ).Value = this.Address;
                cmd.Parameters.Add( "@email", SqlDbType.VarChar ).Value = this.Email;

                cmd.CommandText = ( @"INSERT INTO Hotels ( name, addres, phone, email, state )
                                    VALUES ( @hotelName, @address, @phone, @email, @state )" );
            using ( cmd.ExecuteReader() )
            {
            }
        }


        public void Save()
        {
            using ( SqlConnection connection = DBConfiguration.GetConnection() )
            {
                SqlCommand cmd = connection.CreateCommand();

                cmd.Parameters.Add( "@hotelId", SqlDbType.Int ).Value = this.HotelId;
                cmd.CommandText = ( @"SELECT hotelId
                                     FROM Hotels
                                     WHERE hotelId = @hotelId" );
                bool hasRows = false;
                using ( SqlDataReader reader = cmd.ExecuteReader() )
                {
                    hasRows = reader.HasRows;
                    
                }
                if ( hasRows )
                {
                    Update( connection );
                }
                else
                {
                    Add( connection );
                }


            }
        }

       /* public void Save()
        {
            using ( SqlConnection connection = DBConfiguration.GetConnection() )
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@hotelId", SqlDbType.Int ).Value = this.HotelId;
                cmd.Parameters.Add( "@hotelName", SqlDbType.VarChar ).Value = this.Name;
                cmd.Parameters.Add( "@phone", SqlDbType.VarChar ).Value = this.Phone;
                cmd.Parameters.Add( "@state", SqlDbType.Int ).Value = this.State;
                cmd.Parameters.Add( "@address", SqlDbType.VarChar ).Value = this.Address;
                cmd.Parameters.Add( "@email", SqlDbType.VarChar ).Value = this.Email;

                cmd.CommandText = ( @"UPDATE Hotels 
                                   SET name = @hotelName, 
                                    addres = @address, 
                                    phone = @phone, 
                                    email = @email,   
                                    state = @state 
                                   WHERE hotelId = @hotelId" );
                cmd.ExecuteReader();
            }
        }*/
       
        public static void Delete( int hotelId )
        {
            using ( SqlConnection connection = DBConfiguration.GetConnection() )
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@hotelId", SqlDbType.Int ).Value = hotelId;
                cmd.CommandText = @"DELETE FROM Hotels WHERE hotelId = @hotelId";
                using ( SqlCommand command = cmd )
                {
                    command.ExecuteNonQuery();
                }
            }
         
        }

        public Hotel( SqlDataReader reader )
        {
            Name = reader["name"].ToString();
            Address = reader["addres"].ToString();
            Phone = reader["phone"].ToString();
            HotelId = reader.GetInt32( reader.GetOrdinal( "hotelId" ) );
            Email = reader["email"].ToString();
            State = reader.GetInt32( reader.GetOrdinal( "state" ) );
        }

        public void SetData( SqlDataReader reader )
        {
            this.Name = reader["name"].ToString();
            this.Address = reader["addres"].ToString();
            this.Phone = reader["phone"].ToString();
            this.HotelId = reader.GetInt32( reader.GetOrdinal( "hotelId" ) );
            this.Email = reader["email"].ToString();
            this.State = reader.GetInt32( reader.GetOrdinal( "state" ) );
        }
        
    }
}
