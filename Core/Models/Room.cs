using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Core.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int AdultBeds { get; set; }
        public int ChildrenBeds { get; set; }
        public int State { get; set; }

        public Room()
        {
        }

        public Room( SqlDataReader reader)
        {
            HotelId = reader.GetInt32( reader.GetOrdinal( "hotelId"));
            RoomId = reader.GetInt32( reader.GetOrdinal( "roomId"));
            Name = reader["name"].ToString();
            AdultBeds = reader.GetInt32( reader.GetOrdinal( "adultBeds"));
            ChildrenBeds = reader.GetInt32( reader.GetOrdinal( "childrenBeds"));            
            State = reader.GetInt32( reader.GetOrdinal( "state"));
        }

        public void SetData( SqlDataReader reader)
        {
            this.HotelId = reader.GetInt32( reader.GetOrdinal( "hotelId"));
            this.RoomId = reader.GetInt32( reader.GetOrdinal( "roomId"));
            this.Name = reader["name"].ToString();
            this.AdultBeds = reader.GetInt32( reader.GetOrdinal( "adultBeds"));
            this.ChildrenBeds = reader.GetInt32( reader.GetOrdinal( "childrenBeds"));
            this.State= reader.GetInt32( reader.GetOrdinal( "state"));
        }


        public static void Delete( int id)
        {
            using ( SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@roomId", SqlDbType.Int).Value = id;
                cmd.CommandText = @"DELETE FROM Rooms WHERE roomId = @roomId";
                using ( SqlCommand command = cmd)
                {
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Save()
        {
            using ( SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@hotelId", SqlDbType.Int).Value = this.HotelId;
                cmd.Parameters.Add( "@roomName", SqlDbType.VarChar).Value = this.Name;
                cmd.Parameters.Add( "@adultBeds", SqlDbType.Int).Value = this.AdultBeds;                
                cmd.Parameters.Add( "@state", SqlDbType.Int).Value = this.State;
                cmd.Parameters.Add( "@childrenBeds", SqlDbType.Int).Value = this.ChildrenBeds;
                cmd.Parameters.Add( "@roomId", SqlDbType.Int).Value = this.RoomId;

                cmd.CommandText = ( @"UPDATE Rooms 
                                   SET name = @roomName, 
                                    hotelId = @hotelId, 
                                    adultBeds = @adultBeds, 
                                    childrenBeds = @childrenBeds, 
                                    state = @state  
                                   WHERE roomId = @roomId");
                cmd.ExecuteReader();
            }
        }

        public void Add()
        {
            using ( SqlConnection connection = DBConfiguration.GetConnection())
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add( "@hotelId", SqlDbType.Int).Value = this.HotelId;
                cmd.Parameters.Add( "@roomName", SqlDbType.VarChar).Value = this.Name;
                cmd.Parameters.Add( "@adultBeds", SqlDbType.Int).Value = this.AdultBeds;
                cmd.Parameters.Add( "@state", SqlDbType.Int).Value = this.State;
                cmd.Parameters.Add( "@childrenBeds", SqlDbType.Int).Value = this.ChildrenBeds;
                cmd.Parameters.Add( "@roomId", SqlDbType.Int).Value = this.RoomId;

                cmd.CommandText = ( @"INSERT INTO Rooms ( hotelId, name, adultBeds, childrenBeds, state) 
                                    VALUES ( @hotelId, @roomName, @adultBeds, @childrenBeds, @state)");
                cmd.ExecuteReader();
            }
        }
         

    }
}
